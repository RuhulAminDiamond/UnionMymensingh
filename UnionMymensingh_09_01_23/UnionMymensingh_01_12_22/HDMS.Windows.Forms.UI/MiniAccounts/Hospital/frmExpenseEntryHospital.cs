
using HDMS.Model.MiniAccount;
using HDMS.Service.MiniAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    public partial class frmExpenseEntryHospital : Form
    {
        public frmExpenseEntryHospital()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgExpenses.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgExpenses.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void frmExpenseEntry_Load(object sender, EventArgs e)
        {
            chkCheck.Checked = false;
            chkCash.Checked = true;

            dtpEntry.Value = DateTime.Now;
            LoadAccountHeadsByType(cmbType.Text);
            LoadExpensesByDate(dtp.Value);
        }

        private void LoadExpensesByDate(DateTime _date)
        {
            List<VMExpense> expenseList = new MiniAccountService().GetAllExpensesByDate(_date,2);
            var bindingList = new BindingList<VMExpense>(expenseList);
            var source = new BindingSource(bindingList, null);
            dgExpenses.AutoGenerateColumns = true;
            dgExpenses.DataSource = source;
        }

        private void LoadAccountHeadsByType(string _type)
        {
            
            cmbHead.DataSource = null;
            cmbHead.ResetText();


            cmbHead.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbHead.AutoCompleteSource = AutoCompleteSource.ListItems;

           
            List<MiniAccountHead> _accHeads = new MiniAccountService().GetAccountHeadsByType(_type);

            _accHeads.Insert(0, new MiniAccountHead() { Id = 0, Name = "Select Head" });
            cmbHead.DataSource = _accHeads;

            MiniAccountHead _acc = new MiniAccountHead();
            cmbHead.ValueMember = "Id";
            cmbHead.DisplayMember = "Name";



        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccountHeadsByType(cmbType.Text);
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            double _expenseAmount = 0; int _headId;

            double.TryParse(txtAmount.Text, out _expenseAmount);
            int.TryParse(cmbHead.ValueMember,out _headId);

            if (_expenseAmount > 0 && cmbHead.Tag != null && txtAmount.Tag==null)
            {
                Expense _exp = new Expense();
                _exp.BusinessUnitId = 2;
                _exp.AccountId = ((MiniAccountHead)cmbHead.Tag).Id;
                _exp.Amount = _expenseAmount;
                _exp.trandate = dtpEntry.Value;
                _exp.Description = txtDescription.Text;
                _exp.EntryBy = MainForm.LoggedinUser.Name;
                if(chkCash.Checked)
                {
                    _exp.PaymentBy = chkCash.Tag.ToString();
                }
                else
                {
                    _exp.PaymentBy = chkCheck.Tag.ToString();
                }

                if (new MiniAccountService().SaveExpense(_exp))
                {
                    MessageBox.Show("Expense entry successful.","HERP");
                    txtAmount.Text = "";
                }

                LoadExpensesByDate(DateTime.Now);
            }
            else if (_expenseAmount > 0 && cmbHead.Tag != null && txtAmount.Tag != null)
            {
                Expense _exp = ((Expense)txtAmount.Tag);
                _exp.AccountId = ((MiniAccountHead)cmbHead.Tag).Id;
                _exp.Amount = _expenseAmount;
                _exp.trandate = dtpEntry.Value;
                _exp.Description = txtDescription.Text;

                if (new MiniAccountService().UpdateExpense(_exp))
                {
                    MessageBox.Show("Expense entry updated successfully.", "HERP");
                    txtAmount.Text = "";
                }

                LoadExpensesByDate(DateTime.Now);
            }
            else
            {
                MessageBox.Show("Fail to save.Some required field blank.", "HERP");
            }
           
        }

        private void cmbHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHead.Tag = new MiniAccountService().GetAccountHeadObj(cmbHead.Text);
        }

        private void dgExpenses_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtAmount.Tag = new MiniAccountService().GetExpenseById(Convert.ToInt32(dgExpenses.Rows[e.RowIndex].Cells["AccId"].Value.ToString()));
            if (txtAmount.Tag != null)
            {
                Expense _expense = (Expense)txtAmount.Tag;
                MiniAccountHead _head = new MiniAccountService().GetAccountHeadByAccountId(_expense.AccountId);
                cmbType.Text = _head.Type;
                //cmbHead.SelectedIndex = _expense.AccountId; //As Test Group Id starts from 3
                //cmbHead.Text = dgExpenses.Rows[e.RowIndex].Cells["AccName"].Value.ToString();
                cmbHead.Tag = new MiniAccountService().GetAccountHeadObj(_head.Name);
                cmbHead.Text = _head.Name;
                txtDescription.Text = _expense.Description;
                txtAmount.Text = _expense.Amount.ToString();

                btnSave.Text = "Update";
              
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";

            txtAmount.Tag = null;

            txtAmount.Text = "";
            txtDescription.Text = "";

            LoadAccountHeadsByType(cmbType.Text);
        }

        private void chkCash_Click(object sender, EventArgs e)
        {
            if (chkCash.Checked)
            {
                chkCheck.Checked = false;
            }
        }

      
        private void chkCheck_Click(object sender, EventArgs e)
        {
            if (chkCheck.Checked)
            {
                chkCash.Checked = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
