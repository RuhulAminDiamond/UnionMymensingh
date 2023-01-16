using HDMS.Model;
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
    public partial class frmAddServiceType : Form
    {
        public frmAddServiceType()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtServiceName.Text))
            {
                ServiceGroup _pService = new ServiceGroup();
                _pService.Name = txtServiceName.Text;
                if (new HospitalService().SaveService(_pService))
                {
                    MessageBox.Show("Service Created Successfully.");
                    txtServiceName.Text = "";
                }
            }
            LoadServices();
        }

        

        private void frmAddServiceType_Load(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void LoadServices()
        {
            List<ServiceGroup> _serviceList = new HospitalService().GetAllServices().ToList();
            var bindingList = new BindingList<ServiceGroup>(_serviceList);
            var source = new BindingSource(bindingList, null);
            gvServiceList.AutoGenerateColumns = true;
            gvServiceList.DataSource = source;
        }

        private void gvServiceList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtServiceName.Tag = new HospitalService().GetServiceById(Convert.ToInt32(gvServiceList.Rows[e.RowIndex].Cells["Id"].Value.ToString()));

            gvServiceList.Text = gvServiceList.Rows[e.RowIndex].Cells["SName"].Value.ToString();
            
        }
    }
}
