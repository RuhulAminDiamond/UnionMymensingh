using HDMS.Model.Rx;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Service.Rx;
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

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmDefaultDoseSetup : Form
    {
        public frmDefaultDoseSetup()
        {
            InitializeComponent();
        }

        private void txtLongDoseEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && string.IsNullOrEmpty(txtLongDoseEn.Text))
            {
                HideAllDefaultHidden();
                ctrlDosageSearch.Visible = true;
                ctrlDosageSearch.LoadData();
            }

        }

        private void HideAllDefaultHidden()
        {
            ctrlDosageSearch.Visible = false;
        }

        private void frmDefaultDoseSetup_Load(object sender, EventArgs e)
        {
            ctrlDosageSearch.Location = new Point(txtLongDoseEn.Location.X, txtLongDoseEn.Location.Y + txtLongDoseEn.Height);
            ctrlDosageSearch.ItemSelected += ctrlDosageSearch_ItemSelected;

            LoadGeneric();

            LoadFormations();

        }

        private void LoadFormations()
        {
            List<Formation> fList = new PhProductClassificationService().GetFormation().ToList();
            fList.Insert(0, new Formation() { FormationId = 0, Name = "Select Formation" });
            cmbFormation.DataSource = fList;
            cmbFormation.DisplayMember = "Name";
            cmbFormation.ValueMember = "FormationId";
        }

        private void LoadGeneric()
        {
            List<Generic> gList = new PhProductClassificationService().GetGenList().ToList();
            gList.Insert(0, new Generic() { GenericId = 0, Name = "Select Generic" });
            cmbGeneric.DataSource = gList;
            cmbGeneric.DisplayMember = "Name";
            cmbGeneric.ValueMember = "GenericId";
        }

        private void ctrlDosageSearch_ItemSelected(SearchResultListControl<RxDosage> sender, RxDosage item)
        {
            txtLongDoseEn.Tag = item;
            txtLongDoseEn.Text = item.DoseEnLong;
            txtLongDoseBn.Text = item.DoseBnLong;
            txtShortDoseEn.Text = item.DoseEnShort;
            txtShortDoseBn.Text = item.DoseBnShort;

            sender.Visible = false;
        }

        private void btnSetDose_Click(object sender, EventArgs e)
        {
            Generic gen = cmbGeneric.SelectedItem as Generic;
            Formation _form = cmbFormation.SelectedItem as Formation;

            if(gen.GenericId > 0 && _form.FormationId > 0 && txtLongDoseEn.Tag != null)
            {
                if (new RxService().SetDoseAsDefaultBasedOnGenAndFormation(gen, _form, txtLongDoseEn.Tag as RxDosage))
                {
                    MessageBox.Show("Default dose setup successful.");

                    txtLongDoseEn.Tag = null;
                    txtLongDoseEn.Text = "";
                    txtLongDoseBn.Text = "";
                    txtShortDoseEn.Text = "";
                    txtShortDoseBn.Text = "";
                    txtshortkey.Text = "";

                    
                }
               
            }
            else
            {
                MessageBox.Show("Generic/Formation/Dose not selected. Plz. Check And Try again. "); return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
