using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
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
    public partial class frmMapTestWithVacutainer : Form
    {
        public frmMapTestWithVacutainer()
        {
            InitializeComponent();
        }

        private void frmMapTestWithVacutainer_Load(object sender, EventArgs e)
        {
            LoadAllPathologicalTest();

            LoadVacutainer();
        }

        private void LoadAllPathologicalTest()
        {
            List<TestItem> _testList = new TestService().GetAllPathologicalTest();
            FillTestGrid(_testList);
        }

        private void FillTestGrid(List<TestItem> testList)
        {
            gvTestlist.SuspendLayout();
            gvTestlist.Rows.Clear();

            foreach (var item in testList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(gvTestlist, item.TestId, item.TestCode, item.Name, item.ShortName, item.Specimen);

                gvTestlist.Rows.Add(row);
            }
        }

        private void LoadVacutainer()
        {
            List<VacuType> _vacuList = new TestService().GetVacuList();
            _vacuList.Insert(0, new VacuType() { VTId = 0, VType = "Select Vacu Type" });

            cmbVacuTypes.DataSource = _vacuList;
            cmbVacuTypes.DisplayMember = "VType";
            cmbVacuTypes.ValueMember = "VTId";

        }

        private void txtSearchTest_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTest.Text != "Search Test")
            {
                List<TestItem> _testList = new TestService().GetAllFilteredPathologicalTest(txtSearchTest.Text);
                FillTestGrid(_testList);
            }
        }

        private void cmbVacuTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            VacuType _vType = (VacuType)cmbVacuTypes.SelectedItem;

            txtSelectedVacu.Text = _vType.VType;

            LoadTestWithThisVacu(_vType.VTId);
        }

      

        private void gvTestlist_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvTestlist.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.gvTestlist.SelectedRows[0];
                TestItem _tItem = ((TestItem)row.Tag);

                txtSelectedTest.Text = _tItem.Name;
                txtSelectedTest.Tag = _tItem;

                VacuType _vType = (VacuType)cmbVacuTypes.SelectedItem;

                if (_vType.VTId == 0)
                {
                    MessageBox.Show("Plz. select vacu and try again."); return;
                }


                VacuWithTestSetting _vs = new TestService().FindVacuTestSettingByTestId(_tItem.TestId);
                if (_vs == null)
                {
                    AddToVacu(_tItem, _vType);

                }else
                {
                    MessageBox.Show("Already added to the list.");
                }

            }
        }

        private void AddToVacu(TestItem _tItem, VacuType _vType)
        {
            VacuWithTestSetting _vts = new VacuWithTestSetting();
            _vts.VTId = _vType.VTId;
            _vts.TestId = _tItem.TestId;

            if(new TestService().AddTestWithVacutainer(_vts))
            {
                LoadTestWithThisVacu(_vType.VTId);
            }
        }

        private void LoadTestWithThisVacu(int vTId)
        {
            List<VMVacuTestSetting> _vtList = new TestService().GetVacuWithTestList(vTId);

            FillVacuTestGrid(_vtList);
        }

        private void FillVacuTestGrid(List<VMVacuTestSetting> _vtList)
        {
            dgBL.SuspendLayout();
            dgBL.Rows.Clear();

            foreach(var item in _vtList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgBL,item.TestId,item.TestName,item.ShortName);

                dgBL.Rows.Add(row);
            }
        }

        private void dgBL_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMVacuTestSetting _SelectedItem = (VMVacuTestSetting)e.Row.Tag;
            if (new TestService().DeleteFromVacuList(_SelectedItem.VTId, _SelectedItem.TestId))
            {
                List<VMVacuTestSetting> _vtList = new TestService().GetVacuWithTestList(_SelectedItem.VTId);

                FillVacuTestGrid(_vtList);
            }
        }
    }
}
