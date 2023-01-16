using HDMS.Model.Common;
using HDMS.Service.Common;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmAccountsDashBoard : MaterialForm
    {
        public frmAccountsDashBoard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber800, Primary.Amber900, Primary.Amber500, Accent.Amber200, TextShade.WHITE);
        }

        private async void frmAccountsDashBoard_Load(object sender, EventArgs e)
        {
           await  LoadGeneralAccDashBoardInfo(dtpfromdate.Value, dtptodate.Value);
        }

        private async Task<bool>  LoadGeneralAccDashBoardInfo(DateTime _fromdate, DateTime _todate)
        {

            new CommonService().AccumulateTheDashBoardGeneralInfoItem(_fromdate, _todate);
            
            List<DashBoardAccGeneralInfo> dbItemList = new CommonService().GetDashBoardBroadHeadsList();
            if (dbItemList != null)
            {
                DashBoardAccGeneralInfo hospital = dbItemList.Where(x => x.SelectionKey == "Hp").FirstOrDefault();
                FillHpLV(lvhp, hospital);

                DashBoardAccGeneralInfo DiagIpd = dbItemList.Where(x => x.SelectionKey == "DIpd").FirstOrDefault();

                FillDiagIPDLV(lvdiagipd, DiagIpd);

                DashBoardAccGeneralInfo DiagOpd = dbItemList.Where(x => x.SelectionKey == "DOpd").FirstOrDefault();
                FillDiagOPDLV(lvdiagopd, DiagOpd);

                DashBoardAccGeneralInfo PhIpd = dbItemList.Where(x => x.SelectionKey == "PIpd").FirstOrDefault();
                FillPhIPDLV(lvphipd, PhIpd);

                DashBoardAccGeneralInfo PhOpd = dbItemList.Where(x => x.SelectionKey == "POpd").FirstOrDefault();
                FillPhOPDLV(lvphopd, PhOpd);

               
                DashBoardAccGeneralInfo Cafe = dbItemList.Where(x => x.SelectionKey == "Cafe").FirstOrDefault();

                FillCafeDLV(lvcafe, Cafe);

            }

            return await Task.FromResult(true);
        }

        private void FillCafeDLV(MaterialListView lvcafe, DashBoardAccGeneralInfo cafe)
        {
            lvcafe.Items.Clear();

            ListViewItem item = new ListViewItem(cafe.Col1.ToString());

            item.SubItems.Add(cafe.Col2.ToString());
            item.SubItems.Add(cafe.Col3.ToString());
            item.SubItems.Add(cafe.Col4.ToString());

            item.SubItems.Add(cafe.Col5.ToString());
            item.SubItems.Add(cafe.Col6.ToString());

            lvcafe.Items.Add(item);
        }

        

        private void FillPhOPDLV(MaterialListView lvphopd, DashBoardAccGeneralInfo phOpd)
        {
            lvphopd.Items.Clear();

            ListViewItem item = new ListViewItem(phOpd.Col1.ToString());

            item.SubItems.Add(phOpd.Col2.ToString());
            item.SubItems.Add(phOpd.Col3.ToString());
            item.SubItems.Add(phOpd.Col4.ToString());

            item.SubItems.Add(phOpd.Col5.ToString());
            item.SubItems.Add(phOpd.Col6.ToString());

            lvphopd.Items.Add(item);
        }

        private void FillPhIPDLV(MaterialListView lvphipd, DashBoardAccGeneralInfo phIpd)
        {
            lvphipd.Items.Clear();

            ListViewItem item = new ListViewItem(phIpd.Col1.ToString());

            item.SubItems.Add(phIpd.Col2.ToString());
            item.SubItems.Add(phIpd.Col3.ToString());
            item.SubItems.Add(phIpd.Col4.ToString());

            item.SubItems.Add(phIpd.Col5.ToString());
            item.SubItems.Add(phIpd.Col6.ToString());

            lvphipd.Items.Add(item);
        }

        private void FillDiagOPDLV(MaterialListView lvdiagopd, DashBoardAccGeneralInfo diagOpd)
        {
            lvdiagopd.Items.Clear();

            ListViewItem item = new ListViewItem(diagOpd.Col1.ToString());

            item.SubItems.Add(diagOpd.Col2.ToString());
            item.SubItems.Add(diagOpd.Col3.ToString());
            item.SubItems.Add(diagOpd.Col4.ToString());

            item.SubItems.Add(diagOpd.Col5.ToString());
            item.SubItems.Add(diagOpd.Col6.ToString());

            lvdiagopd.Items.Add(item);
        }

        private void FillDiagIPDLV(MaterialListView lvdiagipd, DashBoardAccGeneralInfo diagIpd)
        {
            lvdiagipd.Items.Clear();

            ListViewItem item = new ListViewItem(diagIpd.Col1.ToString());

            item.SubItems.Add(diagIpd.Col2.ToString());
            item.SubItems.Add(diagIpd.Col3.ToString());
            item.SubItems.Add(diagIpd.Col4.ToString());

            item.SubItems.Add(diagIpd.Col5.ToString());
            item.SubItems.Add(diagIpd.Col6.ToString());

            lvdiagipd.Items.Add(item);
        }

        private void FillHpLV(MaterialListView lvhp, DashBoardAccGeneralInfo hospital)
        {
            lvhp.Items.Clear();

            ListViewItem item = new ListViewItem(hospital.Col1.ToString());

            item.SubItems.Add(hospital.Col2.ToString());
            item.SubItems.Add(hospital.Col3.ToString());
            item.SubItems.Add(hospital.Col4.ToString());

            item.SubItems.Add(hospital.Col5.ToString());
            item.SubItems.Add(hospital.Col6.ToString());

            lvhp.Items.Add(item);
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
           await  LoadGeneralAccDashBoardInfo(dtpfromdate.Value,dtptodate.Value);
        }

        private void materialCard5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
