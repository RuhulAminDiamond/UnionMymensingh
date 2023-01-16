using HDMS.Model;
using HDMS.Model.ViewModel;
using HDMS.Model.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Service.Common;
using HDMS.Common.Utils;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmChangeReportConsultancy : Form
    {
        public frmChangeReportConsultancy()
        {
            InitializeComponent();
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Patient _patient = new PatientService().GetDiagPatientById(Convert.ToInt32(txtRegNo.Text));
                if (_patient != null)
                {
                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_patient.RegNo);
                    if (_record != null)
                    {
                        txtPatientName.Text = _record.FullName;
                        txtAge.Text = Utility.GetConcatenatedAge(_record.AgeYear, _record.AgeMonth, _record.AgeDay);
                        txtSex.Text = _record.Sex;
                    }


                    txtDate.Text = _patient.EntryDate.ToString("dd/MM/yyyy");
                    List<ViewModelReportTests> reportTests = new TestService().GetAllTestByRegNoLegacy(_patient.PatientId,((ReportConsultant)txtCurrentConsultant.Tag).RCId).ToList();
                    txtRefBy.Text = new DoctorService().GetDoctorByIdFromLegacy(_patient.DoctorId).Name;

                    Tv.Nodes.Clear();

                    TreeNode MainNode = new TreeNode();
                    MainNode.Text = "Select Test";
                    Tv.Nodes.Add(MainNode);

                    foreach (var item in reportTests)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = item.Name;
                        child.Tag = item;
                        MainNode.Nodes.Add(child);
                    }

                    Tv.ExpandAll();


                   
                }
                else
                {
                    MessageBox.Show("Patient not found.", "HERP");
                }
            }
        }

        private void frmChangeReportConsultancy_Load(object sender, EventArgs e)
        {
            IList<ReportConsultant> ReportDoctors = new DoctorService().GetlAlReportDoctorOtherThanPathologyLegay();
            if (ReportDoctors != null)
            {
                ReportDoctors.Insert(0, new ReportConsultant()
                {
                    RCId = 0,
                    Name = "Select Consulatnt"
                });
            }



            cmbNewConsultant.DataSource = ReportDoctors;
            cmbNewConsultant.DisplayMember = "Name";
        }

        private void Tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtCurrentTestName.Tag = string.Empty;
            txtCurrentTestName.Text = string.Empty;
            ReportConsultant _consultant = new DoctorService().GetCurrentConsultant( txtRegNo.Text, (ViewModelReportTests)Tv.SelectedNode.Tag);
            txtCurrentConsultant.Tag = _consultant;
            if (_consultant != null) txtCurrentConsultant.Text = _consultant.Name;

           txtCurrentTestName.Text = Tv.SelectedNode.Text;
           txtCurrentTestName.Tag = Tv.SelectedNode.Tag;
           
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
             
            ReportConsultant _newconsultant=(ReportConsultant)cmbNewConsultant.SelectedItem;
            if (txtCurrentTestName.Tag!=null && _newconsultant != null)
            {
                if (new ReportService().ChangeConsultant(txtRegNo.Text, (ViewModelReportTests)txtCurrentTestName.Tag, _newconsultant))
                {
                    MessageBox.Show("Consultant Changed Successfully.");
                }
            }
        }
    }
}
