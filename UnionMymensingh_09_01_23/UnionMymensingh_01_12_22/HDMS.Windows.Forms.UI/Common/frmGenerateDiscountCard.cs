using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Common;
using HDMS.Service.Common;
using System.Threading;
using HDMS.Windows.Forms.UI.Reports.Common;
using CrystalDecisions.Windows.Forms;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmGenerateDiscountCard : Form
    {
        public frmGenerateDiscountCard()
        {
            InitializeComponent();
        }

        private void txtConsultant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void frmGenerateDiscountCard_Load(object sender, EventArgs e)
        {

            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;

            ctlDoctorSearch.Location = new Point(txtConsultant.Location.X, txtConsultant.Location.Y+txtConsultant.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            LoadCardTypes();
        }

        private void LoadCardTypes()
        {
            List<DiscountCardType> _cardList = new CommonService().GetAllCardTypes();
            _cardList.Insert(0, new DiscountCardType() { CardTypeId = 0, Name = "Select Card Type" });

            cmbCardType.DataSource = _cardList;
            cmbCardType.DisplayMember = "Name";
            cmbCardType.ValueMember = "CardTypeId";

        }

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtConsultant.Text = item.Name;
            lblCardLabel.Text= "Honour for Patient of "+ item.Name;
            txtConsultant.Tag = item;
            cmbCardType.Focus();
            sender.Visible = false;
            LoadCardStatistics(item.DoctorId);
        }

        private void LoadCardStatistics(int doctorId)
        {
            VMDiscountCardStatistics cardstatistics = new CommonService().GetCardStatitics(doctorId);

            lblCardIssued.Text = cardstatistics.IssuedCard.ToString();
            lblCardUsed.Text = cardstatistics.UsedCard.ToString();
            lblCardUnused.Text = cardstatistics.UnusedCard.ToString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            btnGenerate.Text = "Plz. Wait..";
            btnGenerate.Enabled = false;

            int _totalCard = 0;
            int.TryParse(txtTotalCard.Text, out _totalCard);

            DiscountCardType _cType = (DiscountCardType)cmbCardType.SelectedItem;

            Doctor _d =   (Doctor)txtConsultant.Tag;

            if (_cType.CardTypeId == 0)
            {
                btnGenerate.Text = "Generate Card";
                btnGenerate.Enabled = true;
                MessageBox.Show("Card type not selected."); return;
              
            }

            if (_d == null)
            {
                btnGenerate.Text = "Generate Card";
                btnGenerate.Enabled = true;

                MessageBox.Show("Consultant not selected."); return;
            }



            DiscountCardMaster _cardm = new DiscountCardMaster();
            _cardm.DoctorId = _d.DoctorId;
            _cardm.CardTopLabel = lblCardLabel.Text;
            _cardm.CardTypeId = _cType.CardTypeId;
            _cardm.CreateDate = DateTime.Now;
            _cardm.ExpireDate = expDate.Value;
            _cardm.CreatedBy = MainForm.LoggedinUser.Name;

            long _dcmId = new CommonService().SaveDiscountCardMaster(_cardm);

            List<DiscountCard> _dCardList = new List<DiscountCard>();

            for (int count=0; count< _totalCard; count++)
            {

                string _firstCharacterOfYear= GetFirstCharacterOfYear();
                string _firstCharacterOfMonth = GetFirstCharacterOfMonth();

                string _cardNo = _firstCharacterOfYear+ _firstCharacterOfMonth+RandomDigits(5);
               

                 DiscountCard _dcard = new DiscountCard();
                _dcard.DCMId = _dcmId;
                _dcard.CardNo = _cardNo;
              

                _dCardList.Add(_dcard);

            }

            if (_dCardList.Count > 0)
            {
                new CommonService().SaveGeneratedCards(_dCardList);
                MessageBox.Show("Discount card generated successfully.");

                ViewCardList(_dcmId, lblCardLabel.Text, cmbCardType.Text);
            }

            btnGenerate.Text = "Generate Card";
            btnGenerate.Enabled = true;
        }

        private string GetFirstCharacterOfMonth()
        {
            int _month = DateTime.Now.Month;

            if (_month == 1)
            {
                return "J";
            }
            else if (_month == 2)
            {
                return "F";
            }
            else if (_month == 3)
            {
                return "M";
            }
            else if (_month == 4)
            {
                return "N";
            }
            else if (_month == 5)
            {
                return "Y";
            }
            else if (_month == 6)
            {
                return "X";
            }
            else if (_month == 7)
            {
                return "Z";
            }
            else if (_month == 8)
            {
                return "G";
            }
            else if (_month == 9)
            {
                return "S";
            }
            else if (_month == 10)
            {
                return "O";
            }
            else if (_month == 11)
            {
                return "K";
            }
            else if (_month == 12)
            {
                return "D";
            }else
            {
                return "";
            }

        }

        private string GetFirstCharacterOfYear()
        {
            int _year = DateTime.Now.Year;
            if (_year == 2018)
            {
                return "A";
            }else if (_year == 2019)
            {
                return "B";
            }
            else if (_year == 2020)
            {
                return "C";
            }
            else if (_year == 2021)
            {
                return "D";
            }else
            {
                return "E";
            }
        }

        private void ViewCardList(long _dcmId, string _topLabel, string _cardType)
        {
            new CommonService().GeneratePrintFormat(_dcmId, _topLabel, _cardType);

            DataSet ds = new CommonService().GetDiscountCards(_dcmId);

            rptDiscountCards _rpt = new rptDiscountCards();

            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            Thread.Sleep(100);
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(1,10).ToString());
            return s;
        }

        private void txtConsultant_TextChanged(object sender, EventArgs e)
        {
            lblCardLabel.Text = "Honour for Patient of "+ txtConsultant.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
