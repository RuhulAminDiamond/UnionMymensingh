using Services.POS;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Model.Common;
using HDMS.Service.Common;

namespace POS.Forms
{
    public partial class frmAddCardType : Form
    {
        public frmAddCardType()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgCardTypes.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgCardTypes.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }


        private void frmAddGroup_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {

            double _disc = 0;
            double.TryParse(txtDiscount.Text, out _disc);

            if (txtName.Tag != null)
            {
                DiscountCardType _cardType = new CommonService().GetDiscountCardTypeById(Convert.ToInt32(((DiscountCardType)txtName.Tag).CardTypeId));
                if (!string.IsNullOrEmpty(txtName.Text) && _cardType != null)
                {
                    _cardType.Name = txtName.Text;
                    _cardType.DiscountInPercent = _disc;

                    if (new CommonService().UpdateCardtype(_cardType))
                    {
                        MessageBox.Show("Update Successful.");
                        txtName.Text = "";
                        txtName.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadGroups();

                    }
                }
            }
            else
            {


                if (!String.IsNullOrEmpty(txtName.Text))
                {
                  

                    DiscountCardType _cType = new DiscountCardType();
                    _cType.Name = txtName.Text;
                    _cType.DiscountInPercent = _disc;

                    if (new CommonService().AddCardType(_cType))
                    {
                        MessageBox.Show("New card type created succesfully.");
                        txtName.Text = "";
                        txtDiscount.Text = "";
                        LoadGroups();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the group name.");
                }
            }
        }

        private void LoadGroups()
        {
            List<DiscountCardType> _pGroup = new CommonService().GetAllCardTypes();
            dgCardTypes.AutoGenerateColumns = false;
            dgCardTypes.DataSource = _pGroup;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgCardTypes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DiscountCardType _cType = new CommonService().GetDiscountCardTypeById(Convert.ToInt32(dgCardTypes.Rows[e.RowIndex].Cells["CardTypeId"].Value));
            // new ProductClassicationService().GetGenericById(Convert.ToInt32(dgFormation.Rows[e.RowIndex].Cells["FormationId"].Value));

            if (_cType != null)
            {
                txtName.Text = _cType.Name;
                txtDiscount.Text = _cType.DiscountInPercent.ToString();
                txtName.Tag = _cType;
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Tag = null;
            txtDiscount.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }
    }
}
