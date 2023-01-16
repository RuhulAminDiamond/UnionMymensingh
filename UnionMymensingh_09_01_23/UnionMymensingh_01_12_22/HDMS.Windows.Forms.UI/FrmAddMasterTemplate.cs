using HDMS.Model;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI
{
    public partial class FrmAddMasterTemplate : Form
    {
        public FrmAddMasterTemplate()
        {
            InitializeComponent();
        }

        private void btnBrowseMasterTemplate_Click(object sender, EventArgs e)
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
                txtTemplate.Text = openFileDialog1.FileName;

            }
        }

        private void btnSaveMasterTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader b = new BinaryReader(File.Open(txtTemplate.Text, FileMode.Open)))
                {
                    int length = (int)b.BaseStream.Length;
                    byte[] File1Content = new byte[length];
                    b.Read(File1Content, 0, length);

                    Template _template = new Template();
                    _template.TemplateContent = File1Content;

                    if (new TemplateService().IsMatchedSecurityCode(txtSecurityCode.Text))
                    {
                        if (new TemplateService().SaveMasterTemplate(_template, (TemplateType)cmbType.SelectedItem))
                        {
                            MessageBox.Show("Master template updated.", "HERP");
                        }
                    }
                    else
                    {
                            MessageBox.Show("Security code did not match.", "HERP");
                    }
                   

                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "HERP");
            }
        }

        private void FrmAddMasterTemplate_Load(object sender, EventArgs e)
        {
            IList<TemplateType> t_type = new TemplateService().GetMasterTemplateCategories().ToList(); //List<TemplateType>();

            t_type.Insert(0, new TemplateType()
            {
                Id = 0,
                Name = "Select Type"
            });

            cmbType.DataSource = t_type;
            cmbType.DisplayMember = "Name";
        }
    }
}
