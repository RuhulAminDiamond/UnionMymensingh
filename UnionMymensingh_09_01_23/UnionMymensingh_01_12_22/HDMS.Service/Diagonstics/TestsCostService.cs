using HDMS.Model;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.ViewModel;
using System.Data;

namespace HDMS.Service.Diagonstics
{
    public class TestsCostService
    {
        public bool SaveTestsCost(List<TestsCost> testsCost)
        {
           return new TestsCostRepository().SaveTestsCost(testsCost);
        }

        public TestsCost GetTestCostByTestId(long _testCostId)
        {
            return new TestsCostRepository().GetTestCostByTestId(_testCostId);
        }

        public void UpdateReportStatus(List<TestsCost> _testCostList)
        {
            new TestsCostRepository().UpdateReportStatus(_testCostList);
        }

        public DataSet GetReceivedSampleList(IList<SelectedTestItemsForPatient> _sampleCollectedTestItems)
        {
            DataTable _dt = GetTableFormat();

            foreach (SelectedTestItemsForPatient item in _sampleCollectedTestItems)
            {

                var values = new object[5];

                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                        values[i] = item.ShortBillNo;

                    if (i == 1)
                        values[i] = item.Name;

                    if (i == 2)
                        values[i] = item.SampleReceivedDate;

                    if (i == 3)
                        values[i] = item.SampleReceivedTime;

                    if (i == 4)
                    {
                        values[i] = item.SampleReceivedBy;
                        _dt.Rows.Add(values);
                    }

                }

            }

            DataSet ds = new DataSet();
            ds.Tables.Add(_dt);
            return ds;

        }

        private DataTable GetTableFormat()
        {
            DataTable dt = new DataTable("SampleData");
            dt.Columns.Add("BillNo", typeof(string));
            dt.Columns.Add("TestName", typeof(string));
            dt.Columns.Add("SampleReceivedDate", typeof(DateTime));
            dt.Columns.Add("SampleReceivedTime", typeof(string));

            dt.Columns.Add("SampleReceivedBy", typeof(string));
          

            return dt;
        }

        public TestsCost GetTestCostByPatientAndTestId(long patientId, int testId)
        {
            return new TestsCostRepository().GetTestCostByPatientAndTestId(patientId, testId);
        }

        public bool UpdateReportStatusByTest(TestsCost _tc)
        {
           return  new TestsCostRepository().UpdateReportStatusByTest(_tc);
        }
    }
}
