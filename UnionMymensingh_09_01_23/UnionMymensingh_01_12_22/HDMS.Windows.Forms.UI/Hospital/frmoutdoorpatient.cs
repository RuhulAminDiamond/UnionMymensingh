using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmoutdoorpatient : Form
    {
        public frmoutdoorpatient()
        {
            InitializeComponent();
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }

        private void frmoutdoorpatient_Load(object sender, EventArgs e)
        {
            
            
            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            txtRegNo.Text = GetNextRegNo();
            txtDailyId.Text = new OutDoorPatientService().GetDailyId(dtpentrydate.Value);
        }

        
        private string GetNextRegNo()
        {
            return new OutDoorPatientService().GetNextRegNo();

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRegNo.Text) || !String.IsNullOrEmpty(txtName.Text) || !String.IsNullOrEmpty(txtAge.Text) || !String.IsNullOrEmpty(txtGurdianName.Text) || !String.IsNullOrEmpty(txtTotalAmount.Text))
            {
                double _receiveAmountCash = 0, _receiveByHCV = 0, _receiveByPoorFund=0;

                if (double.TryParse(txtPaid.Text, out _receiveAmountCash))
                {
                    _receiveAmountCash = Convert.ToDouble(txtPaid.Text);
                }

               

                if (double.TryParse(txtPoorFund.Text, out _receiveByPoorFund))
                {
                    _receiveByPoorFund = Convert.ToDouble(txtPoorFund.Text);
                }

                if ((_receiveAmountCash + _receiveByHCV + _receiveByPoorFund) != Convert.ToDouble(txtTotalAmount.Text))
                {
                    MessageBox.Show("Total amount & Payment amount should be equal.", "HERP");
                    return;
                }


                if (cmbServiceFor.Text != "General" && txtDescription.Text == "")
                {
                    MessageBox.Show("Description required.", "HERP");
                    return;
                }
                
                OutDoorPatient odp = new OutDoorPatient();

                if (txtRegNo.Tag != null)
                {

                    odp = (OutDoorPatient)txtRegNo.Tag;
                    odp.RegNo = txtRegNo.Text;
                    odp.DailyId = Convert.ToInt32(new OutDoorPatientService().GetDailyId(dtpentrydate.Value));
                    odp.ServiceFor = cmbServiceFor.Text;
                    odp.Name = txtName.Text;
                    odp.Age = txtAge.Text;
                    odp.GurdianName = txtGurdianName.Text;
                    odp.Village = txtVillage.Text;
                    odp.Union = txtUnion.Text;
                    odp.Upazilla = txtUpazilla.Text;
                    odp.MobileNo = txtMobileNo.Text;
                    odp.Description = txtDescription.Text;
                    odp.EntryDate = dtpentrydate.Value;

                    new OutDoorPatientService().UpdateOutDoorPatient(odp);


                    new OutDoorPatientService().DeleteIncomeStatements(odp.Id);

                    List<OutDoorIncome> _odiList = new List<OutDoorIncome>();

                    OutDoorIncome odrinc = new OutDoorIncome();

                    if (_receiveAmountCash >= 0)
                    {
                        odrinc.PatientId = odp.Id;
                        odrinc.PaymentType = "Cash";
                        odrinc.Amount = _receiveAmountCash;
                        odrinc.Date = DateTime.Now;
                        new OutDoorPatientService().SaveIncome(odrinc);
                        //_odiList.Add(odrinc);

                    }


                    if (_receiveByHCV > 0)
                    {
                        odrinc = new OutDoorIncome();
                        odrinc.PatientId = odp.Id;
                        odrinc.PaymentType = "HCV";
                        odrinc.Amount = _receiveByHCV;
                        odrinc.Date = DateTime.Now;
                        
                        //_odiList.Add(odrinc);
                        new OutDoorPatientService().SaveIncome(odrinc);

                        

                    }

                    if (_receiveByPoorFund > 0)
                    {
                        odrinc = new OutDoorIncome();
                        odrinc.PatientId = odp.Id;
                        odrinc.PaymentType = "PF";
                        odrinc.Amount = _receiveByPoorFund;
                        odrinc.Date = DateTime.Now;
                        
                        new OutDoorPatientService().SaveIncome(odrinc);
                        //_odiList.Add(odrinc);

                    }

                    //string msg = new OutDoorPatientService().SaveOutDoorPatientIncome(_odiList);
                    MessageBox.Show("Update Suuceesful.", "HERP");
                    txtDailyId.Text = new OutDoorPatientService().GetDailyId(dtpentrydate.Value);

                }
                else
                {
                    odp.RegNo = txtRegNo.Text;
                    odp.DailyId = Convert.ToInt32(new OutDoorPatientService().GetDailyId(dtpentrydate.Value));
                    odp.ServiceFor = cmbServiceFor.Text;
                    odp.Name = txtName.Text;
                    odp.Age = txtAge.Text;
                    odp.GurdianName = txtGurdianName.Text;
                    odp.Village = txtVillage.Text;
                    odp.Union = txtUnion.Text;
                    odp.Upazilla = txtUpazilla.Text;
                    odp.MobileNo = txtMobileNo.Text;
                    odp.Description = txtDescription.Text;
                    odp.EntryDate = dtpentrydate.Value;
                    int _patientId = new OutDoorPatientService().SaveOutDoorPatient(odp);


                    List<OutDoorIncome> _odiList = new List<OutDoorIncome>();

                    OutDoorIncome odrinc = new OutDoorIncome();

                    if (_receiveAmountCash >= 0)
                    {
                        odrinc.PatientId = _patientId;
                        odrinc.PaymentType = "Cash";
                        odrinc.Amount = _receiveAmountCash;
                        odrinc.Date = DateTime.Now;
                        new OutDoorPatientService().SaveIncome(odrinc);
                        //_odiList.Add(odrinc);

                    }


                    if (_receiveByHCV > 0)
                    {
                        odrinc = new OutDoorIncome();
                        odrinc.PatientId = _patientId;
                        odrinc.PaymentType = "HCV";
                        odrinc.Amount = _receiveByHCV;
                        odrinc.Date = DateTime.Now;
                        
                        //_odiList.Add(odrinc);
                        new OutDoorPatientService().SaveIncome(odrinc);

                       

                    }

                    if (_receiveByPoorFund > 0)
                    {
                        odrinc = new OutDoorIncome();
                        odrinc.PatientId = _patientId;
                        odrinc.PaymentType = "PF";
                        odrinc.Amount = _receiveByPoorFund;
                        odrinc.Date = DateTime.Now;
                        new OutDoorPatientService().SaveIncome(odrinc);
                        //_odiList.Add(odrinc);

                    }

                    //string msg = new OutDoorPatientService().SaveOutDoorPatientIncome(_odiList);
                    MessageBox.Show("Saved Suuceesful.", "HERP");
                    txtDailyId.Text = new OutDoorPatientService().GetDailyId(dtpentrydate.Value);

                }
               

            }
            else
            {
                MessageBox.Show("Fail to save. Some required information missing.", "HERP");
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            txtRegNo.Text = GetNextRegNo();
            txtName.Text = "";
            txtAge.Text = "";
            txtGurdianName.Text = "";
            txtVillage.Text = "";
            txtUnion.Text = "";
            txtUpazilla.Text = "";
            txtDescription.Text = "";
            
            txtPaid.Text = "";
            txtDailyId.Text = new OutDoorPatientService().GetDailyId(dtpentrydate.Value);
        }

        

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPayment_Click(object sender, EventArgs e)
        {

        }

       

        private void txtHCVSerialNo_Leave(object sender, EventArgs e)
        {
            
        }

       

        private void cmbServiceFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServiceFor.Text == "General")
            {
                txtTotalAmount.Text = "110";
            }
            else if (cmbServiceFor.Text == "ENT")
            {
                txtTotalAmount.Text = "210";
            }
            else if (cmbServiceFor.Text == "Cancer")
            {
                txtTotalAmount.Text = "420";
            }
            else
            {
                txtTotalAmount.Text = "";
                txtTotalAmount.Focus();
            }
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OutDoorPatient _outpatient = new OutDoorPatientService().GetOutDoorPatientByRegNo(txtRegNo.Text);
               
                if (_outpatient != null)
                {
                    txtRegNo.Tag = _outpatient;
                    txtName.Text = _outpatient.Name;
                    dtpentrydate.Value = _outpatient.EntryDate;
                    txtAge.Text = _outpatient.Age;
                    txtGurdianName.Text = _outpatient.GurdianName;
                    txtVillage.Text = _outpatient.Village;
                    txtUnion.Text = _outpatient.Union;
                    txtUpazilla.Text = _outpatient.Upazilla;
                    txtDescription.Text = _outpatient.Description;
                    cmbServiceFor.Text=_outpatient.ServiceFor;
                    txtMobileNo.Text=_outpatient.MobileNo;
                    txtDescription.Text=_outpatient.Description;

                    List<OutDoorIncome> _outIncome = new OutDoorPatientService().GetOutDoorIncomeByPatient(_outpatient.Id);
                    foreach (var _income in _outIncome)
                    {
                        if (_income.PaymentType.ToLower() == "cash")
                        {
                            txtPaid.Text = _income.Amount.ToString();
                        }
                        else if (_income.PaymentType.ToLower() == "pf")
                        {
                            txtPoorFund.Text = _income.Amount.ToString();
                        }
                       
                    }

                    

                }
               
            }
        }

    }
}
