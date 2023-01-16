using DocumentFormat.OpenXml.Office2010.CustomUI;
using HDMS.Model;
using HDMS.Model.Pharmacy;
using HDMS.Model.Rx;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Users;
using HDMS.Models.Pharmacy;
using HDMS.Service;
using HDMS.Service.Doctors;
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
    public partial class frmDefaultDosePersonal : Form
    {
        bool isLoaded = false;
        
        public frmDefaultDosePersonal()
        {
            InitializeComponent();
        }

        private async void frmDefaultDosePersonal_Load(object sender, EventArgs e)
        {
            ctrlDosageSearch.Location = new Point(txtLongDoseEn.Location.X, txtLongDoseEn.Location.Y + txtLongDoseEn.Height);
            ctrlDosageSearch.ItemSelected += ctrlDosageSearch_ItemSelected;

            isLoaded = false;

            LoadGeneric(0);

            LoadFormations(0);


            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_user.ChamberPractitionerId);

            this.Tag = Practitioner;

            if (Practitioner != null)
            {

                this.Text = this.Text + " -" + Practitioner.Name;
            }


            LoadDurationUnit();

            List<PhProductGroup> _groupList = new PhProductService().GetAllGroups();
            _groupList = _groupList.OrderBy(x => x.Name).ToList();


            ImageList imageList = new ImageList { ImageSize = new Size(200, 200) };
            Image img = new Bitmap(Properties.Resources.capsul);
            treeImageList.Images.Add("imgFolder", img);
            treeGGBrand.ImageList = treeImageList;


            await FillNode(_groupList, null);


            LoadGenericWithDoseList();


            isLoaded = true;

        }

        private void LoadGenericWithDoseList()
        {
            List<VMGenericWithDefaultDose> _doseList = new RxService().GetDefaultDoseWithGeneric();
            FillGenGrid(_doseList);
        }

        private void LoadDurationUnit()
        {
            List<RxDuration> _duration = new RxService().GetRxDuration();
            _duration.Insert(0, new RxDuration() { DurationId = 0, Name = "" });
            cmbDurationUnit.DataSource = _duration;
            cmbDurationUnit.DisplayMember = "Name";
            cmbDurationUnit.ValueMember = "DurationId";
        }

        private async Task<bool> FillNode(List<PhProductGroup> items, TreeNode node)
        {


            node = new TreeNode();
            node.Name = "mainNode";
            node.Text = "Explore Drug";
            treeGGBrand.Nodes.Add(node);

            var nodesCollection = treeGGBrand.Nodes;

            foreach (var item in items)
            {
                var newNode = new TreeNode();
                newNode.Name = item.Name;
                newNode.Text = item.Name;
                newNode.Tag = "Group |" + item.GroupId + "|" + item.Name;
                newNode.ImageKey = "imgFolder";
                newNode.SelectedImageKey = "";
                treeGGBrand.Nodes[0].Nodes.Add(newNode);

                List<Generic> _genList = new PhProductClassificationService().GetGenericByGroupId(item.GroupId);
                foreach (var gen in _genList)
                {
                    var genNode = new TreeNode();
                    genNode.Name = gen.Name;
                    genNode.Text = gen.Name;
                    genNode.Tag = "Generic |" + gen.GenericId + "|" + gen.Name;
                    genNode.ImageKey = "imgFolder";
                    genNode.SelectedImageKey = "";
                    treeGGBrand.Nodes[0].Nodes[newNode.Name].Nodes.Add(genNode);

                }

                // FillNode(items, newNode);
            }


            return await Task.FromResult(true);

        }

        private void ctrlDosageSearch_ItemSelected(SearchResultListControl<RxCpDosage> sender, RxCpDosage item)
        {
            txtLongDoseEn.Tag = item;
            txtLongDoseEn.Text = item.DoseEnLong;
            txtLongDoseBn.Text = item.DoseBnLong;
            txtShortDoseEn.Text = item.DoseEnShort;
            txtShortDoseBn.Text = item.DoseBnShort;

            sender.Visible = false;
        }

        private void LoadFormations(int formationId)
        {
            List<Formation> fList = new PhProductClassificationService().GetFormation().ToList();
            fList.Insert(0, new Formation() { FormationId = 0, Name = "Select Formation" });
            cmbFormation.DataSource = fList;
            cmbFormation.DisplayMember = "Name";
            cmbFormation.ValueMember = "FormationId";

            if (formationId > 0)
            {
                cmbFormation.SelectedItem = fList.Find(x => x.FormationId == formationId);

                
            }

            
        }

        private void LoadGeneric(int _genId)
        {
            List<Generic> gList = new PhProductClassificationService().GetGenList().ToList();
            gList.Insert(0, new Generic() { GenericId = 0, Name = "Select Generic" });
            cmbGeneric.DataSource = gList;
            cmbGeneric.DisplayMember = "Name";
            cmbGeneric.ValueMember = "GenericId";

            if (_genId > 0)
            {
                cmbGeneric.SelectedItem = gList.Find(q => q.GenericId == _genId);
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetDose_Click(object sender, EventArgs e)
        {
            Generic gen = cmbGeneric.SelectedItem as Generic;
            Formation _form = cmbFormation.SelectedItem as Formation;

            ChamberPractitioner _practitioner = this.Tag as ChamberPractitioner;


            if (gen.GenericId > 0 && _form.FormationId > 0 && txtLongDoseEn.Tag != null && _practitioner!=null)
            {
                int _dduration = 0;
                int.TryParse(txtDefaultDuration.Text, out _dduration);
               
                RxCpDosage _selectedDose = txtLongDoseEn.Tag as RxCpDosage;

                RxCpDosageWithGenericMapping _mappingObj = new RxCpDosageWithGenericMapping();
                _mappingObj.CpId = _practitioner.CPId;
                _mappingObj.GenericId = gen.GenericId;
                _mappingObj.FormationId = _form.FormationId;
                _mappingObj.DoseId = _selectedDose.DoseId;
                _mappingObj.DefaultDuration = _dduration;
                _mappingObj.DDUnit = cmbDurationUnit.Text;
                _mappingObj.Qty = txtQty.Text;
                if (new RxService().SaveCpPersonalDoseWithGeneric(_mappingObj))
                {
                    MessageBox.Show("Default dose setup or update successful.");

                    LoadGenericWithDoseList();

                    txtLongDoseEn.Tag = null;
                    txtLongDoseEn.Text = "";
                    txtLongDoseBn.Text = "";
                    txtShortDoseEn.Text = "";
                    txtShortDoseBn.Text = "";
                    txtshortkey.Text = "";
                    txtDefaultDuration.Text = "";
                    txtQty.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Generic/Formation/Dose not selected. Plz. Check And Try again. "); return;
            }
        }

        private void txtLongDoseEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && string.IsNullOrEmpty(txtLongDoseEn.Text))
            {
                ChamberPractitioner _practitioner = this.Tag as ChamberPractitioner;
                HideAllDefaultHidden();
                ctrlDosageSearch.Visible = true;
                ctrlDosageSearch.LoadDataByType(_practitioner.CPId.ToString());
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlDosageSearch.Visible = false;
        }

        private void treeGGBrand_DoubleClick(object sender, EventArgs e)
        {
           string[] arr  =    treeGGBrand.SelectedNode.Tag.ToString().Split('|');
           if(arr!=null && arr.Length > 0)
            {
                if(arr[0].Trim().ToLower() == "generic")
                {
                    int _genId = Convert.ToInt32(arr[1]);
                    //List<VWPhProductList> _pList = new PhProductService().GetBasicProductInfoListByGeneric(_genId).ToList();
                   
                    //if(_pList==null || _pList.Count == 0)
                    //{
                    //    MessageBox.Show("No product found under this generic"); return;
                    //}

                     LoadGeneric(_genId);

                     MessageBox.Show("Select Formation dose for default dose");

                    return;

                    //LoadDefaultDose(_genId,);

                    //  LoadGeneric((_pList.FirstOrDefault()).FormationId);

                    //  FillProdGrid(_pList);
                }
            }
          
        }

        private void FillGenGrid(List<VMGenericWithDefaultDose> prodList)
        {
            dgProducts.Rows.Clear();
            dgProducts.SuspendLayout();
            foreach(var item in prodList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgProducts, item.GenericId,item.GroupName,item.GenericName,item.Dose,item.DefaultDuration,item.DDUnit,item.Qty);
                dgProducts.Rows.Add(row);
            }
        }

        private void cmbFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

                Formation _f = cmbFormation.SelectedItem as Formation;

                if (_f != null)
                {
                    Generic _g = cmbGeneric.SelectedItem as Generic;

                    if (_g != null)
                    {
                        ChamberPractitioner _practitioner = this.Tag as ChamberPractitioner;
                        LoadDefultDose(_g.GenericId, _f.FormationId, _practitioner);
                    }
                }
            }

         
        }

        private void LoadDefultDose(int genericId, int formationId, ChamberPractitioner _practitioner)
        {
            RxCpDosageWithGenericMapping _dsm = new RxService().GetRxCpDosageWithGenericMapping(_practitioner, genericId, formationId);
            if (_dsm != null)
            {
                RxCpDosage _dose = new RxService().GetRxCPDosageByDoseId(_dsm.DoseId);
                if (_dose != null)
                {
                    txtLongDoseEn.Tag = _dose;
                    txtLongDoseEn.Text = _dose.DoseEnLong;
                    txtLongDoseBn.Text = _dose.DoseBnLong;
                    txtShortDoseEn.Text = _dose.DoseEnShort;
                    txtShortDoseBn.Text = _dose.DoseBnShort;
                }

                txtDefaultDuration.Text = _dsm.DefaultDuration.ToString();
                if (!string.IsNullOrEmpty(_dsm.DDUnit))
                {
                    cmbDurationUnit.Text = _dsm.DDUnit;
                }

                if (!string.IsNullOrEmpty(_dsm.Qty.Trim()))
                {
                    txtQty.Text = _dsm.Qty;

                }else
                {
                    txtQty.Text = "";
                }

            }
        }
    }
}
