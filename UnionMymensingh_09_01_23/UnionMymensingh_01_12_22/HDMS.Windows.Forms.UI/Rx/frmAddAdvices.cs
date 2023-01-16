using HDMS.Model;
using HDMS.Model.Rx;
using HDMS.Model.Users;
using HDMS.Service;
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
    public partial class frmAddAdvices : Form
    {
        public frmAddAdvices()
        {
            InitializeComponent();
        }

        private void frmAddAdvices_Load(object sender, EventArgs e)
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_user.ChamberPractitionerId);

            if (Practitioner != null)
            {
                btnSave.Tag = Practitioner;
                LoadAdvices(Practitioner.CPId);
            }
            else
            {
                btnSave.Tag = null;
            }

            
        }

        private void LoadAdvices(int cPId)
        {
            List<RxCPAdvice> _adviceList =new RxService().GetAdvicesByCP(cPId);

            FillGrid(_adviceList);
        }

        private void FillGrid(List<RxCPAdvice> _adviceList)
        {
            dgAdvices.SuspendLayout();
            dgAdvices.Rows.Clear();
            foreach(var item in _adviceList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgAdvices,item.RxCpAdvId,item.AdviceBn,item.AdviceEn,item.ShortKey);

                dgAdvices.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtAdviceBn.Text) && !String.IsNullOrEmpty(txtAdviceEn.Text))
            {
                int _cpId = 0;

                if (btnSave.Tag != null)
                {
                    ChamberPractitioner cp = (ChamberPractitioner)btnSave.Tag;
                    _cpId = cp.CPId;
                }


                if (txtAdviceBn.Tag != null)
                {
                    RxCPAdvice _adv = (RxCPAdvice)txtAdviceBn.Tag;
                    _adv.CPId = _cpId;
                    _adv.AdviceBn = txtAdviceBn.Text;
                    _adv.AdviceEn = txtAdviceEn.Text;
                    _adv.ShortKey = txtShortKey.Text;
                    if (new RxService().UpdateAdvices(_adv))
                    {
                        MessageBox.Show("Advice updated successfully.");
                        ClearForm();
                        LoadAdvices(_cpId);
                    }
                }
                else
                {

                    RxCPAdvice _adv = new RxCPAdvice();
                    _adv.CPId = _cpId;
                    _adv.AdviceBn = txtAdviceBn.Text;
                    _adv.AdviceEn = txtAdviceEn.Text;
                    _adv.ShortKey = txtShortKey.Text;
                    if (new RxService().AddAdvices(_adv))
                    {
                        MessageBox.Show("Advice added successfully.");
                        ClearForm();
                        LoadAdvices(_cpId);
                    }
                }
            }

        }

        private void ClearForm()
        {
            txtAdviceBn.Text = "";
            txtAdviceEn.Text = "";
            txtShortKey.Text = "";
        }

        private void dgAdvices_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgAdvices.Rows.Count > 0)
            {
                RxCPAdvice adv = dgAdvices.CurrentRow.Tag as RxCPAdvice;
                if (adv != null)
                {

                    txtAdviceBn.Tag = adv;

                    txtAdviceBn.Text = adv.AdviceBn;
                    txtAdviceEn.Text = adv.AdviceEn;
                    txtShortKey.Text = adv.ShortKey;
                    
                }
            }
        }

        private void dgAdvices_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RxCPAdvice _SelectedItem = (RxCPAdvice)e.Row.Tag;

            new RxService().DeleteAdviceFromCpPersonalDb(_SelectedItem);
        }
    }
}
