using HDMS.Model.Common;
using HDMS.Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmAvailableDoctor : Form
    {
        public frmAvailableDoctor()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            LoadDoctor(dt.Value);
        }

        private void frmAvailableDoctor_Load(object sender, EventArgs e)
        {
            LoadDoctor(dt.Value);
        }

        private void LoadDoctor(DateTime value)
        {
            List<AvailableDoctor> availableslist = new CommonService().GetAvailableDoctor(value);
            FillGrid(availableslist);
        }

        private void FillGrid(List<AvailableDoctor> availableslist)
        {
            dgDoctor.SuspendLayout();
            dgDoctor.Rows.Clear();
            foreach(var v in availableslist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = v;
                row.CreateCells(dgDoctor,v.DoctorName,v.Specialist);
                dgDoctor.Rows.Add(row);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
