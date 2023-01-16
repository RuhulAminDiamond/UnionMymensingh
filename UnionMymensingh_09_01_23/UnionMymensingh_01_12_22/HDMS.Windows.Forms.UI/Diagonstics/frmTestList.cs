using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Others;
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
    public partial class frmTestList : Form
    {
        public frmTestList()
        {
            InitializeComponent();
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            DataSet ds = new TestService().GetTestList();



            rptTestList _rptTestList = new rptTestList();
       
            _rptTestList.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();
          

            rv.crviewer.ReportSource = _rptTestList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
