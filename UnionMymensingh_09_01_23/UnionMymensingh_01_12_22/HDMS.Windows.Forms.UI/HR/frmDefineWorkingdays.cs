using HDMS.Model.Common;
using HDMS.Model.HR;
using HDMS.Model.HR.VM;
using HDMS.Service.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmDefineWorkingdays : Form
    {
        public frmDefineWorkingdays()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime _monthFirstDate = DateTime.Now;
            DateTime _monthLastDate = DateTime.Now;

            string _firstDayOfSelectedMonth = cmbYear.Text + "/" + cmbMonth.SelectedValue.ToString() + "/01";

            DateTime.TryParse(_firstDayOfSelectedMonth,out _monthFirstDate);

            _monthLastDate = _monthFirstDate.AddMonths(1).AddDays(-1);

            List<HrWokingDay> _wdList = new List<HrWokingDay>();

            for (DateTime _dt = _monthFirstDate; _dt <= _monthLastDate; _dt = _dt.AddDays(1))
            {
                HrWokingDay _hd = new HrWokingDay();
                _hd.WDate = _dt;
                _hd.WDay = _dt.Day;
                _hd.WMonth = _dt.Month;
                _hd.WYear = _dt.Year;
                if (_hldayList.Any(x => x.HolyDay.Date == _dt.Date))
                {
                    VMHoliday _hday = _hldayList.Where(x => x.HolyDay.Date == _dt.Date).FirstOrDefault();

                    _hd.IsPublicHoliday = true;
                    _hd.Remarks = _hday.Remarks;

                }else
                {

                    _hd.IsPublicHoliday = false;
                    _hd.Remarks = "";
                }

                _wdList.Add(_hd);
            }

            if (_wdList.Count > 0)
            {
                new HrCommonService().SaveWorkingDays(_wdList);
                MessageBox.Show("Working day define successful");

                ClearFields();
            }

            


        }

        private void ClearFields()
        {
            txtDescription.Text = "";
            dgHolydays.Rows.Clear();
        }

        private IList<VMHoliday> _hldayList;
        private void frmDefineWorkingdays_Load(object sender, EventArgs e)
        {
            _hldayList = new List<VMHoliday>();

            LoadMonths();
        }

        private void LoadMonths()
        {
            List<MonthsOfYear> _mList = Utils.GetMonthsOfYear();
            cmbMonth.DataSource = _mList;
            cmbMonth.DisplayMember = "Name";
            cmbMonth.ValueMember = "Id";
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescription.Text) && dtpto.Value >= dtfrm.Value)
            {
                new HrCommonService().HolyDayList(_hldayList, txtDescription.Text,dtfrm.Value,dtpto.Value);
                FillGridItem(_hldayList);

            }
        }

        private void FillGridItem(IList<VMHoliday> _hldayList)
        {
            dgHolydays.SuspendLayout();
            dgHolydays.Rows.Clear();
            foreach (var item in _hldayList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgHolydays, item.HolyDay.ToString("dd/MM/yyyy"), item.Remarks);
                dgHolydays.Rows.Add(row);
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _hldayList = new List<VMHoliday>();
             new HrCommonService().GetHolyDayList(_hldayList, cmbYear.Text, cmbMonth.SelectedValue.ToString());
            FillGridItem(_hldayList);
        }
    }
}
