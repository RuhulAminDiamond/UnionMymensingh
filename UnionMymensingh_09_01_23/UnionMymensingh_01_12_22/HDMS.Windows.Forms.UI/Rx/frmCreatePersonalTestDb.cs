using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.Rx;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
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
    public partial class frmCreatePersonalTestDb : Form
    {

        bool unlocked = true;


        public frmCreatePersonalTestDb()
        {
            InitializeComponent();
        }

        private void frmCreatePersonalTestDb_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();


            LoadTestgroup(0);

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_user.ChamberPractitionerId);

            if (Practitioner != null)
            {
                lblTest.Tag = Practitioner;

                LoadCpTestDb(Practitioner.CPId);
            }

            ctlTestSearch.Location = new Point(txtTestCDb.Location.X, txtTestCDb.Location.Y);
            ctlTestSearch.ItemSelected += CtlTestSearch_ItemSelected; ;


        }

        private void LoadTestgroup(int _groupId)
        {
            List<TestGroup> _testGroup = new TestService().GetAllGroup();
            _testGroup.Insert(0, new TestGroup() { TestGroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = _testGroup;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "TestGroupId";

            if (_groupId > 0)
            {
                cmbGroup.SelectedItem = _testGroup.Find(q=>q.TestGroupId== _groupId);
            }

        }

        private void CtlTestSearch_ItemSelected(Controls.SearchResultListControl<TestItem> sender, TestItem item)
        {
            txtTestCDb.Text = item.Name.ToString();
            txtTestNamePDB.Text= item.Name.ToString();
            txtTestCDb.Tag = item;
            txtTestNamePDB.Focus();
            sender.Visible = false;
            MakeTestGroupSelected(item);
        }

        private void MakeTestGroupSelected(TestItem item)
        {
            ReportType _rType = new TestService().GetReportTypesById(item.ReportTypeId);
            if (_rType != null)
            {
                LoadTestgroup(_rType.TestGroupId);
            }
        }

        private void LoadCpTestDb(int cPId)
        {
            List<RxCPPreferredTest> _testList = new RxService().GetRxCpPreferredTestlist(cPId);
            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach(var item in _testList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgTests, item.CPPTId, item.TestName);
                dgTests.Rows.Add(row);
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _groupId = 0;
            int testId = 0;

            ChamberPractitioner _cp = (ChamberPractitioner)lblTest.Tag;


            TestGroup _group = cmbGroup.SelectedItem as TestGroup;

            _groupId = _group.TestGroupId;

            if (_groupId == 0)
            {
                MessageBox.Show("Plz. select test group."); return;
            }

            if(txtTestCDb.Tag != null)
            {
                TestItem _tItem = (TestItem)txtTestCDb.Tag;
                testId = _tItem.TestId;
            }

            if (!string.IsNullOrEmpty(txtTestNamePDB.Text))
            {
                RxCPPreferredTest _pt = new RxCPPreferredTest();
                _pt.CPId = _cp.CPId;
                _pt.TestGroupId = _groupId;
                _pt.TestId = testId;
                _pt.TestName = txtTestNamePDB.Text;

                new RxService().SaveRxCpPreferredTestInPersonalDb(_pt);

                LoadCpTestDb(_cp.CPId);

            }
            else
            {
                MessageBox.Show("Test name required.");
                txtTestNamePDB.Focus(); return;
            }

        }

        private void txtTestCDb_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtTestCDb.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtTestCDb.Text;
                    HideAllDefaultHidden();
                    ctlTestSearch.Visible = true;
                    ctlTestSearch.txtSearch.Text = _txt;
                    ctlTestSearch.txtSearch.SelectionStart = ctlTestSearch.txtSearch.Text.Length;

                    ctlTestSearch.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlTestSearch.Visible = false;
        }

        private void dgTests_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RxCPPreferredTest _SelectedItem = (RxCPPreferredTest)e.Row.Tag;

            new RxService().DeleteTestFromCpPersonalDb(_SelectedItem);
        }
    }
}
