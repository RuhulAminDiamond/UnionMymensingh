using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Rx;
using HDMS.Service.Rx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmAddPatientHistory : Form
    {

        string calledFrom = string.Empty;

        public frmAddPatientHistory()
        {
           
        }

        public frmAddPatientHistory(string _calledFrom)
        {
            InitializeComponent();
            calledFrom = _calledFrom;
            SetTitle(calledFrom);

        
        }

       

        private void SetTitle(string calledFrom)
        {
            if(RxPatientHistoryAddCalledFrom.CC.ToString()== calledFrom) this.Text = "Chief Complaints";
            if (RxPatientHistoryAddCalledFrom.CCD.ToString() == calledFrom) this.Text = "Duration";
            if (RxPatientHistoryAddCalledFrom.PrIL.ToString() == calledFrom) this.Text = "History of present illness";
            if (RxPatientHistoryAddCalledFrom.PaIL.ToString() == calledFrom) this.Text = "History of past illness";
            if (RxPatientHistoryAddCalledFrom.FaH.ToString() == calledFrom) this.Text = "Family History";
            if (RxPatientHistoryAddCalledFrom.PeH.ToString() == calledFrom) this.Text = "Personal History";
            if (RxPatientHistoryAddCalledFrom.SeH.ToString() == calledFrom) this.Text = "Socio-Economic History";
            if (RxPatientHistoryAddCalledFrom.PscyH.ToString() == calledFrom) this.Text = "Psychiatric History";
            if (RxPatientHistoryAddCalledFrom.DrH.ToString() == calledFrom) this.Text = "Drug & Treatment History";
            if (RxPatientHistoryAddCalledFrom.AH.ToString() == calledFrom) this.Text = "History of allergy";
            if (RxPatientHistoryAddCalledFrom.ImH.ToString() == calledFrom) this.Text = "History of Immunization";
            if (RxPatientHistoryAddCalledFrom.MoH.ToString() == calledFrom) this.Text = "Meanstrual & Obstetric History";
            if (RxPatientHistoryAddCalledFrom.OH.ToString() == calledFrom) this.Text = "Other History";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name required."); return;
            }

           
        }

      
    }
}
