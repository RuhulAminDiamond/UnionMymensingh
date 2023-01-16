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
    public partial class frmAddGeneralPhysicalExam : Form
    {

        string calledFrom = string.Empty;

        public frmAddGeneralPhysicalExam()
        {
           
        }

        public frmAddGeneralPhysicalExam(string _calledFrom)
        {
            InitializeComponent();
            calledFrom = _calledFrom;
            SetTitle(calledFrom);
        }

        private void SetTitle(string calledFrom)
        {
            if (RxGeneralPhysicalExamAddCalledFrom.APPR.ToString() == calledFrom) this.Text = "Appearance";
            if (RxGeneralPhysicalExamAddCalledFrom.BLD.ToString() == calledFrom) this.Text = "Build";
            if (RxGeneralPhysicalExamAddCalledFrom.NTR.ToString() == calledFrom) this.Text = "Nutrition";
            if (RxGeneralPhysicalExamAddCalledFrom.DCTBT.ToString() == calledFrom) this.Text = "Decubitus";
            if (RxGeneralPhysicalExamAddCalledFrom.COO.ToString() == calledFrom) this.Text = "Cooperation";
            if (RxGeneralPhysicalExamAddCalledFrom.ANM.ToString() == calledFrom) this.Text = "Anaemia";
            if (RxGeneralPhysicalExamAddCalledFrom.JND.ToString() == calledFrom) this.Text = "Jaundice";
            if (RxGeneralPhysicalExamAddCalledFrom.CYN.ToString() == calledFrom) this.Text = "Cyanosis";
            if (RxGeneralPhysicalExamAddCalledFrom.CLB.ToString() == calledFrom) this.Text = "Clubbing";
            if (RxGeneralPhysicalExamAddCalledFrom.KLN.ToString() == calledFrom) this.Text = "Koilonychia";
            if (RxGeneralPhysicalExamAddCalledFrom.LKN.ToString() == calledFrom) this.Text = "Leukonychia";
            if (RxGeneralPhysicalExamAddCalledFrom.ODMA.ToString() == calledFrom) this.Text = "Oedema";
            if (RxGeneralPhysicalExamAddCalledFrom.DHD.ToString() == calledFrom) this.Text = "Dehydration";

            if (RxGeneralPhysicalExamAddCalledFrom.BNTND.ToString() == calledFrom) this.Text = "Bony tenderness";
            if (RxGeneralPhysicalExamAddCalledFrom.PGT.ToString() == calledFrom) this.Text = "Pigmentation";
            if (RxGeneralPhysicalExamAddCalledFrom.LYMPHN.ToString() == calledFrom) this.Text = "Lymph nodes";
            if (RxGeneralPhysicalExamAddCalledFrom.THYGLND.ToString() == calledFrom) this.Text = "Thyroid gland";
            if (RxGeneralPhysicalExamAddCalledFrom.BRT.ToString() == calledFrom) this.Text = "Breasts";
            if (RxGeneralPhysicalExamAddCalledFrom.BH.ToString() == calledFrom) this.Text = "Body hair";

            if (RxGeneralPhysicalExamAddCalledFrom.PLS.ToString() == calledFrom) this.Text = "Pulse";
            if (RxGeneralPhysicalExamAddCalledFrom.BP.ToString() == calledFrom) this.Text = "Blood pressure";
            if (RxGeneralPhysicalExamAddCalledFrom.TMP.ToString() == calledFrom) this.Text = "Temperature";
            if (RxGeneralPhysicalExamAddCalledFrom.RSP.ToString() == calledFrom) this.Text = "Respirtaion";
            if (RxGeneralPhysicalExamAddCalledFrom.NCK.ToString() == calledFrom) this.Text = "Neck";
            if (RxGeneralPhysicalExamAddCalledFrom.AXL.ToString() == calledFrom) this.Text = "Axilla";


            if (RxGeneralPhysicalExamAddCalledFrom.HEAD.ToString() == calledFrom) this.Text = "Head";
            if (RxGeneralPhysicalExamAddCalledFrom.RASH.ToString() == calledFrom) this.Text = "Rash";
            if (RxGeneralPhysicalExamAddCalledFrom.SCM.ToString() == calledFrom) this.Text = "Scar mark";
           
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
