using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.ChamberPractitioner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmPatientSerialEntry : Form
    {

        DataSet ds;
        public frmPatientSerialEntry()
        {
            InitializeComponent();
        }

        private void lblRefBy_Click(object sender, EventArgs e)
        {

        }

        private void frmPatientSerialEntry_Load(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void LoadDoctors()
        {

            List<ChamberPractitioner> _chamberPractitioner = new ChamberPractitionerService().GetAllActivePractitioner();
            TV.Nodes.Clear();

            TreeNode MainNode = new TreeNode();
            MainNode.Text = "Select Doctor";
            TV.Nodes.Add(MainNode);

            foreach (var item in _chamberPractitioner)
            {
                TreeNode child = new TreeNode();
                child.Text = item.Name;
                child.Tag = item;
                MainNode.Nodes.Add(child);
            }

            TV.ExpandAll();
        }

        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            txtDoctor.Text = TV.SelectedNode.Text;
            txtDoctor.Tag = TV.SelectedNode.Tag;

            LoadPatientSerialByDoctor((ChamberPractitioner)txtDoctor.Tag, dtp.Value);
            lblSerialFor.Text = "Serial for: " + TV.SelectedNode.Text;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDoctor.Tag != null && !String.IsNullOrEmpty(txtPatientName.Text))
            {
                int _serialNo = new ChamberPractitionerService().GetSerialNo((ChamberPractitioner)txtDoctor.Tag, dtp.Value);
                lblSerialNo.Text = _serialNo.ToString();
                PractitionerWisePatientSerial _pSerial = new PractitionerWisePatientSerial();
                _pSerial.SerialDate = dtp.Value;
                _pSerial.SerialNo = _serialNo;
                _pSerial.ChamberPractitionerId = ((ChamberPractitioner)txtDoctor.Tag).Id;
                _pSerial.PatientName = txtPatientName.Text;
                _pSerial.MobileNo = txtCellPhone.Text;
                _pSerial.Age = txtAge.Text;
                _pSerial.Sex = cmbGender.Text;

                if (new ChamberPractitionerService().CreateNewSerial(_pSerial))
                {
                    MessageBox.Show("Serial generated successfully.");
                    txtPatientName.Text = "";
                }

                LoadPatientSerialByDoctor((ChamberPractitioner)txtDoctor.Tag,dtp.Value);
            }
            else
            {
                MessageBox.Show("Some required information missing.");
            }
        }


        private void LoadPatientSerialByDoctor(ChamberPractitioner _practitioner,DateTime _date)
        {
            List<PractitionerWisePatientSerial> _pList = new ChamberPractitionerService().LoadPatientSerialByDoctor(_practitioner.Id, _date);
            List<PatientSerial> __pSerialList = new List<PatientSerial>();
            foreach (var _patient in _pList)
            {
                PatientSerial _serial = new PatientSerial();
                _serial.SerialNo = _patient.SerialNo;
                _serial.PatientName = _patient.PatientName;
                _serial.MobileNo = _patient.MobileNo;
                __pSerialList.Add(_serial);
            }

            var bindingList = new BindingList<PatientSerial>(__pSerialList);
            var source = new BindingSource(bindingList, null);
            gvPList.AutoGenerateColumns = true;
            gvPList.DataSource = source;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = new ReportService().GetPatientSerialByDoctor(((ChamberPractitioner)txtDoctor.Tag).Id, dtp.Value);


            rptPatientSerial _patientSerial = new rptPatientSerial();

            _patientSerial.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _patientSerial.DataDefinition.FormulaFields[0].Text = "'" + dtp.Value.ToString(customFmts) + "'";
            _patientSerial.DataDefinition.FormulaFields[1].Text = "'" + txtDoctor.Text + "'";

            rv.crviewer.ReportSource = _patientSerial;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
