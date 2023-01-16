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
    public partial class frmTestSampleBarcodeLabelSetting : Form
    {
        public frmTestSampleBarcodeLabelSetting()
        {
            InitializeComponent();
        }

        private void frmTestRateAndBarcodeLabelSetting_Load(object sender, EventArgs e)
        {
            LoadAllPathologicalTest();
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

            foreach(var item in testList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(gvTestlist, item.TestId, item.TestCode, item.Name, item.ShortName, item.Specimen);

                gvTestlist.Rows.Add(row);
            }
        }

        private void txtSearchTest_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchTest.Text != "Search Test")
            {
                List<TestItem> _testList = new TestService().GetAllFilteredPathologicalTest(txtSearchTest.Text);
                FillTestGrid(_testList);
            }
        }

        private void gvTestlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvTestlist.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.gvTestlist.SelectedRows[0];
                TestItem _tItem = ((TestItem)row.Tag);

                txtSelectedTest.Text = _tItem.Name;
                txtSelectedTest.Tag = _tItem;

                txtLabelName.Focus();

                LoadBarcodeLabelSettings(_tItem);

            }
        }

        private void txtLabelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               



            }
        }

        private void LoadBarcodeLabelSettings(TestItem _tItem)
        {
            List<BarCodeLabelSettingForTest> _bcList = new TestService().GetBarcodeLabelList(_tItem.TestId);

            dgBL.SuspendLayout();
            dgBL.Rows.Clear();

            foreach(var item in _bcList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgBL, item.TestId, _tItem.Name, item.BarcodeLabel,item.CategoryId);
                dgBL.Rows.Add(row);
            }

        }

        private void dgBL_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BarCodeLabelSettingForTest _SelectedItem = (BarCodeLabelSettingForTest)e.Row.Tag;
            if (new TestService().DeleteBarcodeLabelSetting(_SelectedItem.SettingId))
            {
                TestItem _testItem = new TestService().GetTestItemById(_SelectedItem.TestId);
                LoadBarcodeLabelSettings(_testItem);
            }
        }

        private void txtCategoryId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrWhiteSpace(txtLabelName.Text))
                {
                    int _categoryId = 0;
                    int.TryParse(txtCategoryId.Text, out _categoryId);

                    TestItem _tItem = (TestItem)txtSelectedTest.Tag;


                    if (txtCategoryId.Tag != null)
                    {
                        BarCodeLabelSettingForTest _sLs = (BarCodeLabelSettingForTest)txtCategoryId.Tag;
                        _sLs.BarcodeLabel = txtLabelName.Text;
                        _sLs.CategoryId = _categoryId;

                        if (new TestService().UpdateBarCodeLabel(_sLs))
                        {
                            LoadBarcodeLabelSettings(_tItem);
                            txtLabelName.Text = "";
                            txtCategoryId.Tag = null;
                            txtCategoryId.Text = "";
                        }

                    }
                    else
                    {

                        BarCodeLabelSettingForTest _sbSetting = new BarCodeLabelSettingForTest();
                        _sbSetting.TestId = _tItem.TestId;
                        _sbSetting.BarcodeLabel = txtLabelName.Text;
                        _sbSetting.CategoryId = _categoryId;
                        if (new TestService().SaveBarCodeLabel(_sbSetting))
                        {
                            LoadBarcodeLabelSettings(_tItem);
                            txtLabelName.Text = "";
                            txtCategoryId.Tag = null;
                            txtCategoryId.Text = "";
                        }
                    }

                }
                else
                {

                    MessageBox.Show("Label Name Required."); return;

                }

            }
        }

        private void dgBL_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BarCodeLabelSettingForTest _bs = (BarCodeLabelSettingForTest)dgBL.SelectedRows[0].Tag;

            txtLabelName.Text = _bs.BarcodeLabel;
            txtCategoryId.Text = _bs.CategoryId.ToString();

            TestItem _item = new TestService().GetTestItemById(_bs.TestId);

            txtSelectedTest.Tag = _item;
            txtSelectedTest.Text = _item.Name;

            txtCategoryId.Tag = _bs;
        }
    }
}
