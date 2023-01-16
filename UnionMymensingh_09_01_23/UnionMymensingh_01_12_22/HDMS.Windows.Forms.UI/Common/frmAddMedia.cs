using HDMS.Model.Common;
using HDMS.Model.Diagnostic;
using HDMS.Model.MiniAccount;
using HDMS.Service.Common;
using HDMS.Service.Doctors;
using HDMS.Service.MiniAccounts;
using HDMS.Windows.Forms.UI.Controls;
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
    public partial class frmAddMedia : Form
    {
       List <BusinessMedia> _businessMedia = new List<BusinessMedia>();

        public frmAddMedia()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MediaCategory mediaCategory = txtMediaCategoryType.Tag as MediaCategory;
            if (!String.IsNullOrWhiteSpace(txtMediaName.Text))
            {
                BusinessMedia _media = new BusinessMedia();
                _media.Name = txtMediaName.Text;
                _media.ContactNo = txtContactNo.Text;
                _media.Address = txtAddress.Text;
                _media.MediaType = cmbMediaType.Text;
                _media.CategoryId = mediaCategory.CategoryId;
                if (new DoctorService().SaveMedia(_media))
                {
                    MessageBox.Show("Media added successfully");

                    MiniAccountHead _accHead = new MiniAccountHead();
                    _accHead.Name = _media.MediaId.ToString() + ": " + _media.Name;
                    _accHead.Type = "Expense";
                    if (new MiniAccountService().SaveAccountHead(_accHead))
                    {
                        MessageBox.Show("Account-head created successfully.", "HERP");
                    }

                    

                    txtMediaName.Text = "";
                    txtContactNo.Text = "";
                    txtAddress.Text = "";
                    cmbMediaType.Text = "";
                    txtMediaCategoryType.Text = "";

                    _businessMedia = new CommonService().GetAllMedia();
                    FillMediaList(_businessMedia);
                }
                
            }
        }

        private void ctrlMeidaCategoryController_ItemSelected(SearchResultListControl<MediaCategory> sender, MediaCategory item)
        {

            txtMediaCategoryType.Text = item.CategoryName;
            txtMediaCategoryType.Tag = item;
            sender.Visible = false;
        }
        
        private void HideAllDefaultControls()
        {
            ctrlMeidaCategoryController.Visible = false;
        }

        private void frmAddMedia_Load(object sender, EventArgs e)
        {
            HideAllDefaultControls();
            ctrlMeidaCategoryController.Location = new Point(txtMediaCategoryType.Location.X, txtMediaCategoryType.Location.Y + txtMediaCategoryType.Height);

            ctrlMeidaCategoryController.ItemSelected += ctrlMeidaCategoryController_ItemSelected;

            _businessMedia = new CommonService().GetAllMedia();
            FillMediaList(_businessMedia);
        }

        private void txtMediaCategoryType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultControls();
                ctrlMeidaCategoryController.Visible = true;
                ctrlMeidaCategoryController.LoadData();
   
            }
        }

        private void FillMediaList(List<BusinessMedia> _businessMedia)
        {
            dgMediaList.SuspendLayout();
            dgMediaList.Rows.Clear();
            foreach(var media in _businessMedia)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = media;
                row.CreateCells(dgMediaList, media.Name, media.ContactNo);
                dgMediaList.Rows.Add(row);

                lblTotal.Text = _businessMedia.Count().ToString();
            }

        }

        private void dgMediaList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgMediaList.SelectedRows[0].Tag != null)
            {
               
                BusinessMedia media = dgMediaList.SelectedRows[0].Tag as BusinessMedia;
                txtMediaName.Text = media.Name;
                txtMediaName.Tag = media;
                txtContactNo.Text = media.ContactNo;
                txtContactNo.Tag = media;
                cmbMediaType.Text = media.MediaType;
                txtAddress.Text = media.Address;

                MediaCategory c = new CommonService().GetMediaCatagory(media.CategoryId);
                txtMediaCategoryType.Text = c.CategoryName;
                //txtMediaCategoryType.Text = mediaCategory.CategoryName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MediaCategory mediaCategory=txtMediaCategoryType.Tag as MediaCategory;
            BusinessMedia _media = txtMediaName.Tag as BusinessMedia;
            _media.Name = txtMediaName.Text;
            _media.ContactNo = txtContactNo.Text;
            _media.Address = txtAddress.Text;
            _media.MediaType = cmbMediaType.Text;
            _media.CategoryId = mediaCategory.CategoryId;

            if (new CommonService().UpdateMedia(_media))
            {
                MessageBox.Show("Media Update Sucessfully !");
               
                txtMediaName.Text = "";
                txtContactNo.Text = "";
                txtAddress.Text = "";
                cmbMediaType.Text = "";
                txtMediaCategoryType.Text = "";

                FillMediaList(_businessMedia);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillMediaList(_businessMedia.Where(x => x.Name.Trim().ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList());
        }

        
    }
}
