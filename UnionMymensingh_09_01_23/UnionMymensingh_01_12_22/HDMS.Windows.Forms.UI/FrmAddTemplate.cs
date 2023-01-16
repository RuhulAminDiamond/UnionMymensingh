using HDMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Service.Doctors;
using HDMS.Model.Enums;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using HDMS.Common.Utils;
using HDMS.Service.Diagonstics;
namespace HDMS.Windows.Forms.UI
{
    public partial class FrmAddTemplate : Form
    {

        SqlConnection con;
        int templateId;
        List<int> processesbeforegen = new List<int>();
        List<int> processesaftergen = new List<int>();
        public FrmAddTemplate()
        {
            InitializeComponent();

            con = new SqlConnection();
            con.ConnectionString = Utility.GetLabDbConnectionString();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmAddTemplate_Load(object sender, EventArgs e)
        {
            IList<ReportConsultant> ReportDoctors = new DoctorService().GetAllConsultants();  //new DoctorService().GetlAlReportDoctorOtherThanPathology();
            ReportDoctors.Insert(0, new ReportConsultant()
            {
                RCId = 0,
                Name = "None"
            });
            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "RCId";
            IList<TemplateType> t_type = new List<TemplateType>();

            t_type.Add(new TemplateType() { Id = 0, Name = "Select Type" });
            t_type.Add(new TemplateType() { Id=1, Name="Path"});
            t_type.Add(new TemplateType() { Id=2, Name="Othrs"});
           

            cmbType.DataSource = t_type;
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Id";

            this.LoadData();
            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            ReportConsultant doc = (ReportConsultant)cmbConsultant.SelectedItem;

            if(doc == null || doc.RCId <=0)
            {
                MessageBox.Show("Place Select Consultant Name");
                return;
            }

            try
            {
              using (BinaryReader b = new BinaryReader(File.Open(txtFileName.Text, FileMode.Open)))
              {
                int length = (int)b.BaseStream.Length;
                byte[] File1Content = new byte[length];
                b.Read(File1Content, 0, length);

                string[] fileName = new string[2];
                fileName = Path.GetFileName(txtFileName.Text).Split('.');
               // ReportConsultant doc = (ReportConsultant)cmbConsultant.SelectedItem;
                TemplateType ttype = (TemplateType)cmbType.SelectedItem;

                Template _template = new Template();

                _template.DoctorId = doc.RCId;
                _template.GroupName = ttype.Name;
                _template.FileName = fileName[0];
                _template.TemplateName = txtTemplateName.Text;
                _template.TemplateContent = File1Content;
                  
                if ((txtTemplateName.Tag!=null) && (Int32.TryParse(txtTemplateName.Tag.ToString(), out templateId)))
                {
                    if (new TemplateService().UpdateTemplate(_template, templateId))
                    {
                        MessageBox.Show("Template Updated.", "HERP");
                    }
                }
                else
                {
                    if (new TemplateService().SaveTemplate(_template))
                    {
                        MessageBox.Show("Template Saved.", "HERP");
                    }
                }
                

               
               } 
           }catch(Exception ex){
                MessageBox.Show(ex.Message, "HERP");
            }

            this.LoadData();
	

        }

        private void LoadData()
        {
             con.Open();
              SqlDataAdapter da = new SqlDataAdapter("select * from Templates", con);
              DataTable dt = new DataTable();
              da.Fill(dt);
            con.Close();
            lvTemplates.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr[0].ToString());
                listitem.SubItems.Add(dr[2].ToString().PadLeft(3));
                listitem.SubItems.Add(dr[1].ToString());
                listitem.SubItems.Add(dr[4].ToString());
                listitem.SubItems.Add(dr[3].ToString());
                lvTemplates.Items.Add(listitem);
            }
        }

       
        private void ShowTemplate(int templateId)
        {

            bool isFileInUse;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateContent FROM dbo.Templates WHERE ID=" + templateId.ToString(), con);
            byte[] img = (byte[])cmd.ExecuteScalar();

            if (File.Exists("D:\\template.docx"))
            {
                string filePath = "D:\\template.docx";
                isFileInUse = Utility.FileInUse(filePath);
                // Then you can do some checking
                if (isFileInUse)
                {

                    MessageBox.Show("File is open. Please close it first.", "File In Use");
                    con.Close();
                    return;

                }
                else
                    Console.WriteLine("File is not in use");
               
            }

            FileStream fs = new FileStream("D:\\template.docx", FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(img);
            fs.Dispose();
            con.Close();

              
               Process.Start("WINWORD.EXE", "D:\\template.docx");

        }

        private void lvTemplates_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Docx Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Word Files|*.doc;*.docx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;

            }
        }

        private void btnBrowseMasterTemplate_Click(object sender, EventArgs e)
        {
            //string s = "";
        }

        private void lvTemplates_DoubleClick(object sender, EventArgs e)
        {
            if (lvTemplates.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lvTemplates.SelectedItems;

                ListViewItem lvItem = items[0];
                string[] Ids = lvItem.Text.Split('-');

                txtTemplateName.Text = lvTemplates.Items[lvTemplates.SelectedIndices[0]].SubItems[3].Text;
                txtTemplateName.Tag = Ids[0];
                cmbType.Text = lvTemplates.Items[lvTemplates.SelectedIndices[0]].SubItems[1].Text;
                cmbConsultant.Text = "None"; //Need to do proper coding here if the template is consulted orientd.

                btnDelete.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTemplateName.Tag != null)
            {
                int _templateId=0;
                int.TryParse(txtTemplateName.Tag.ToString(), out _templateId);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete  FROM dbo.Templates WHERE ID=" + _templateId.ToString(), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Template deleted successfully.");
                    LoadData();
                }
                catch
                {
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

       
      
    }
}
