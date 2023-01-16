using HDMS.Model.Accounting.VModel;
using HDMS.Model.Common;
using HDMS.Model.Common.VW;
using HDMS.Service.Common;
using HDMS.Windows.Forms.UI.Controls;
using Models.Accounting;
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
    public partial class frmGroupsForAccountHeadMapping : Form
    {
        bool unlocked = true;

        public frmGroupsForAccountHeadMapping()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAccountHead_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountHead.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtAccountHead.Text;
                    HideAllDefaultHidden();
                    ctrlAccHeadSearch.Visible = true;
                    ctrlAccHeadSearch.txtSearch.Text = _txt;
                    ctrlAccHeadSearch.txtSearch.SelectionStart = ctrlAccHeadSearch.txtSearch.Text.Length;

                    ctrlAccHeadSearch.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlAccHeadSearch.Visible = false;
        }

        private void frmGroupsForAccountHeadMapping_Load(object sender, EventArgs e)
        {
            ctrlAccHeadSearch.Location = new Point(txtAccountHead.Location.X, txtAccountHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected; ;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadDeptGroupWithAccountHeadMapping();
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

            ctrl.BackColor = Color.NavajoWhite;
        }

        private void CtrlAccHeadSearch_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtAccountHead.Text = item.AccountHeadName;
            txtAccountHead.Tag = item;
            btnSave.Focus();
            sender.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VMAccountHeads accheadObj = txtAccountHead.Tag as VMAccountHeads;
            if (accheadObj != null)
            {
                DeptGroupWithAccountMapping AccObj = new DeptGroupWithAccountMapping();
                AccObj.DeptName = txtDeptName.Text;
                AccObj.DeptCode = txtDeptCode.Text;
                AccObj.AccountHeadId = accheadObj.AccId;
                if(new CommonService().SaveDeptWithAccountGroupMapping(AccObj))
                {
                    MessageBox.Show("Dept Saved Successfully.");
                    LoadDeptGroupWithAccountHeadMapping();
                }
            }

        }

        private void LoadDeptGroupWithAccountHeadMapping()
        {
            List<VMDeptGroupAccountHeadMapping> accgrpList = new CommonService().GetDeptGroupAccountHeadMappingList();
            dgDepts.SuspendLayout();
            dgDepts.Rows.Clear();
            int count = 1;
            foreach(var item in accgrpList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgDepts, count, item.DeptName, item.AccountHeadName,item.GroupName);
                dgDepts.Rows.Add(row);
                count = count + 1;
            }
        }

        private void ctrlAccHeadSearch_SearchEsacaped(bool IsEscaped)
        {
            if(IsEscaped)
            {
                txtAccountHead.Focus();
            }
        }
    }
}
