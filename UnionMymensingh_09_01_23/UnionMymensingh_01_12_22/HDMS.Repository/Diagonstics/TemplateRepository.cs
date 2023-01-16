using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model;
using HDMS.Common.Utils;
using System.Data;
using HDMS.Model.ViewModel;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;

namespace HDMS.Repository.Diagonstics
{
    public class TemplateRepository
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        string sql = string.Empty;
        public IList<Template> GetAllTemplate()
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLabDbConnectionString();
            con.Open();
            da = new SqlDataAdapter("select * from dbo.Templates",con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<Template> listTemplates = new List<Template>();

            listTemplates = new List<Template>(
                (from dRow in dt.AsEnumerable()
                 select (GetTemplateDataTableRow(dRow)))
                );

            return listTemplates;
        }

        private Template GetTemplateDataTableRow(DataRow dr)
        {
            Template ttype = new Template();
            ttype.Id =Convert.ToInt32(dr["Id"]);
            ttype.DoctorId = Convert.ToInt32(dr["DoctorId"]);
            ttype.GroupName = dr["GroupName"].ToString();
            ttype.FileName = dr["FileName"].ToString();
            ttype.TemplateName = dr["TemplateName"].ToString();

            return ttype;
        }


       
        public Template GetTemplateById(int id)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLabDbConnectionString();
            con.Open();
            da = new SqlDataAdapter("select * from dbo.Templates where Id="+id.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            return GetTemplateDataTableRow(dt.Rows[0]);
        }


        public byte[] GetWordTemplateContent(int id)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TemplateContent FROM dbo.Templates WHERE ID=" + id.ToString(), con);
                byte[] img = (byte[])cmd.ExecuteScalar();
                con.Close();

                return img;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveTemplate(Template _template)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Templates (DoctorId,GroupName,FileName, TemplateName,TemplateContent) VALUES (@DoctorId, @GroupName,@FileName,@TemplateName, @TemplateContent)");
                cmd.Parameters.Add(new SqlParameter("@DoctorId", SqlDbType.Int, 8));
                cmd.Parameters.Add(new SqlParameter("@GroupName", SqlDbType.NVarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@TemplateName", SqlDbType.NVarChar, 50));
                SqlParameter contentParameter = null;
                contentParameter = new SqlParameter("@TemplateContent", SqlDbType.VarBinary);
                contentParameter.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(contentParameter);


                cmd.Parameters["@DoctorId"].Value = _template.DoctorId;
                cmd.Parameters["@GroupName"].Value = _template.GroupName;
                cmd.Parameters["@FileName"].Value = _template.FileName;
                cmd.Parameters["@TemplateName"].Value = _template.TemplateName;
                cmd.Parameters["@TemplateContent"].Value = _template.TemplateContent;

                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch(Exception ex) {
                con.Close();
                return false;
            }
            
        }

        public List<DischargeTemplate> GetAllDischargeTemplates()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DischargeTemplates.ToList();
            }
        }

        public DataTable GetNonLabReports(string billNo)
        {
            string sql = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();


                sql = string.Format("select * from dbo.Reports where RegNo = '{0}' and ReportType<>'Path'", billNo);

                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {

                return dt;
            }
        }

        public bool DeleteExistingDischargeCertificate(VMIPDInfo _pInfo)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Delete from DischargeCertificateTemplateBaseds Where BillNo={0}", _pInfo.BillNo);
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public string SaveDischargeReport(DischargeCertificateTemplateBased _dc)
        {

            using (DBEntities entities = new DBEntities())
            {
                entities.DischargeCertificateTemplateBaseds.Add(_dc);
                entities.SaveChanges();
                return "Success";
            }
        }

        public DataTable GetNonLabPdfReports(string billNo)
        {
            string sql = string.Empty;
            DataTable dt = new DataTable();

            long _billNo = 0;
            long.TryParse(billNo, out _billNo);

            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();


                sql = string.Format("select * from dbo.ImageOrPdfReport where BillNo = {0}", _billNo);

                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {

                return dt;
            }
        }

        public bool SaveDischargeTemplate(DischargeTemplate _template)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.DischargeTemplates.Add(_template);
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public TemplateType GetMasterTemplateByCategory(string calledFrom)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLabDbConnectionString();
            con.Open();
            sql = string.Format("select * from dbo.MasterTemplateCategory Where Name='{0}'", calledFrom);
            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<TemplateType> listMasterTemplatetypes = new List<TemplateType>();


            listMasterTemplatetypes = new List<TemplateType>(
                (from dRow in dt.AsEnumerable()
                 select (GetMasterTemplateTypeDataTableRow(dRow)))
                );

            return listMasterTemplatetypes.FirstOrDefault();
        }

        public string SaveReport(MsWordReport newReport)
        {

            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT into dbo.Reports (PatientId,TestId,TestName,ReportContent,PreparedBy,PreparedDate,PreparedTime,ReportType,ConsultantId) VALUES (@RegNo,@TestId,@TestName,@ReportContent,@PreparedBy,@PreparedDate,@PreparedTime,@ReportType,@ConsultantId)");
                cmd.Parameters.Add(new SqlParameter("@RegNo", SqlDbType.NVarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@TestId", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@TestName", SqlDbType.NVarChar, 250));
                cmd.Parameters.Add(new SqlParameter("@PreparedBy", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@PreparedDate", SqlDbType.Date));
                cmd.Parameters.Add(new SqlParameter("@PreparedTime", SqlDbType.NVarChar,50));
                cmd.Parameters.Add(new SqlParameter("@ReportType", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@ConsultantId", SqlDbType.Int));
                SqlParameter contentParameter = null;
                contentParameter = new SqlParameter("@ReportContent", SqlDbType.VarBinary);
                contentParameter.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(contentParameter);

                cmd.Parameters["@RegNo"].Value = newReport.RegNo;
                cmd.Parameters["@TestId"].Value = newReport.TestInfo.Id;
                cmd.Parameters["@TestName"].Value = newReport.TestInfo.Name;
                cmd.Parameters["@ReportContent"].Value = newReport.ReportContent;
                cmd.Parameters["@PreparedBy"].Value = newReport.PreparedBy;
                cmd.Parameters["@PreparedDate"].Value = newReport.PreparedDate;
                cmd.Parameters["@PreparedTime"].Value = newReport.Preparedtime;
                cmd.Parameters["@ReportType"].Value = newReport.ReportType;
                cmd.Parameters["@ConsultantId"].Value = newReport._ReportDoctor.RCId;

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

                //Set Consultant

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                cmd = new SqlCommand("Update TestsCost set ConsultantId=@ConsultantId Where PatientId=@PatientId and TestId=@TestId");
                cmd.Parameters.Add(new SqlParameter("@ConsultantId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PatientId", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@TestId", SqlDbType.NVarChar, 50));
                cmd.Parameters["@ConsultantId"].Value = newReport._ReportDoctor.RCId;
                cmd.Parameters["@PatientId"].Value = newReport.PatientId;
                cmd.Parameters["@TestId"].Value = newReport.TestInfo.Id;

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

                return "Success";
            }
            catch(Exception ex) {
                return "Fail";
            }
        }


        public DataTable GetRadiologyReports(ReportConsultant _Consultant, string regNo, DateTime _dt, string _type)
        {
            string sql = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                if (String.IsNullOrEmpty(regNo))
                {
                    
                        if (_Consultant == null)
                        {
                            sql = string.Format("select * from dbo.Reports where PreparedDate = '{0}' and ReportType='{1}'", _dt.ToString("MM/dd/yyyy"), _type);
                        }
                        else
                        {
                            sql = string.Format("select * from dbo.Reports where PreparedDate = '{0}' and ReportType='{1}' and ConsultantId={2}", _dt.ToString("MM/dd/yyyy"), _type, _Consultant.RCId);
                        }

              
                }
                else
                {
                    if (!String.IsNullOrEmpty(_type))
                    {
                        sql = string.Format("select * from dbo.Reports where RegNo = '{0}' and ReportType='{1}'", regNo, _type);
                    }
                    else
                    {
                        sql = string.Format("select * from dbo.Reports where RegNo = '{0}'", regNo);
                    }
                }

                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {

                return dt;
            }
        }


        public DataTable GetReports(ReportConsultant _Consultant, long regNo, DateTime _dt, string _type)
        {
            string sql = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                if (regNo != 0)
                {
                    if (_type == "NonPath")
                    {
                        if (_Consultant == null) {
                            sql = string.Format("select * from dbo.Reports where PreparedDate = '{0}' and ReportType<>'Path'", _dt.ToString("MM/dd/yyyy"));
                        }
                        else
                        {
                            sql = string.Format("select * from dbo.Reports where PreparedDate = '{0}' and ReportType<>'Path' and ConsultantId={1}", _dt.ToString("MM/dd/yyyy"), _Consultant.RCId);
                        }
                        
                    }
                    else
                    {
                        sql = string.Format("select * from dbo.Reports where PreparedDate = '{0}' and ReportType='Path'", _dt.ToString("MM/dd/yyyy"), _type);
                    }
                    
                }
                else
                {
                    if (_type == "NonPath")
                    {
                        if (_Consultant == null)
                        {
                            sql = string.Format("select * from dbo.Reports where RegNo = '{0}' and ReportType<>'Path'", regNo, _type);
                        }else
                        {
                            sql = string.Format("select * from dbo.Reports where RegNo = '{0}' and ReportType<>'Path' and ConsultantId={1}", regNo, _Consultant.RCId);
                        }

                    }
                    else
                    {
                        sql = string.Format("select * from dbo.Reports where RegNo = '{0}'", regNo);
                    }
                }
                
                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }catch(Exception ex){
               
                return dt;
            }
        }

        public string GetNewReportFilePath()
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("select FilePath from dbo.FilePath where Id = '1'");
                cmd = new SqlCommand(sql, con);
                string _path = cmd.ExecuteScalar().ToString();
                con.Close();
                return _path;
            }
            catch
            {
                return "";
            }

        }


        public string GetOldReportFilePath()
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("select FilePath from dbo.FilePath where Id = '2'");
                cmd = new SqlCommand(sql, con);
                string _path = cmd.ExecuteScalar().ToString();
                con.Close();
                return _path;
            }
            catch
            {
                return "";
            }

        }

        public bool SaveMasterTemplate(Template _template, TemplateType ttype)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand();

                if (IsMasterTemplateExists(ttype))
                {
                    cmd = new SqlCommand("UPDATE dbo.MasterTemplate SET Contents=@Contents Where CategoryId=@CategoryId");
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
                    cmd.Parameters["@CategoryId"].Value = ttype.Id;
                    SqlParameter contentParameter = null;
                    contentParameter = new SqlParameter("@Contents", SqlDbType.VarBinary);
                    contentParameter.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(contentParameter);

                    cmd.Parameters["@Contents"].Value = _template.TemplateContent;
                }
                else
                {
                    cmd = new SqlCommand("Insert into dbo.MasterTemplate(Contents,CategoryId) Values(@Contents,@CategoryId)");
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
                    cmd.Parameters["@CategoryId"].Value = ttype.Id;
                    SqlParameter contentParameter = null;
                    contentParameter = new SqlParameter("@Contents", SqlDbType.VarBinary);
                    contentParameter.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(contentParameter);

                    cmd.Parameters["@Contents"].Value = _template.TemplateContent;
                }

                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        private bool IsMasterTemplateExists(TemplateType ttype)
        {
            int count = 0;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("select Count(Id) as totalCount  from dbo.MasterTemplate where Id = '{0}'", ttype.Id);
                cmd = new SqlCommand(sql, con);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                
            }

            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public byte[] GetWordMasterTemplateContent(int _templateCategory)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Contents FROM dbo.MasterTemplate WHERE CategoryId=@CategoryId", con);
                cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
                cmd.Parameters["@CategoryId"].Value = _templateCategory;
                byte[] img = (byte[])cmd.ExecuteScalar();
                con.Close();

                return img;
            }
            catch
            {
                return null;
            }
        }

        public byte[] GetDischargeMasterTemplateContent(int _templateId)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TemplateContent FROM dbo.DischargeTemplates WHERE TId=@TId", con);
                cmd.Parameters.Add(new SqlParameter("@TId", SqlDbType.Int));
                cmd.Parameters["@TId"].Value = _templateId;
                byte[] img = (byte[])cmd.ExecuteScalar();
                con.Close();

                return img;
            }
            catch
            {
                return null;
            }
        }

        public bool IsReportExists(string RegNo, ViewModelReportTests viewModelReportTests)
        {
           int count=0;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("select Count(RegNo) as totalCount  from dbo.Reports where RegNo = '{0}' and TestId='{1}'", RegNo, viewModelReportTests.Id.ToString());
                cmd = new SqlCommand(sql, con);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
               
            }
            catch (Exception ex)
            {

            }

            if (count == 0) 
            { 
                 return false;
            }
            else
            {
                return true;
            }
        }

        public string UpdateReport(MsWordReport newReport)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE dbo.Reports SET TestName=@TestName,ReportContent=@ReportContent,PreparedBy=@PreparedBy,ReportType=@ReportType,ConsultantId=@ConsultantId Where PatientId=@PatientId and TestId=@TestId");

                cmd.Parameters.Add(new SqlParameter("@TestName", SqlDbType.NVarChar, 250));
                cmd.Parameters.Add(new SqlParameter("@PreparedBy", SqlDbType.NVarChar, 50));
               // cmd.Parameters.Add(new SqlParameter("@PreparedDate", SqlDbType.Date));
               // cmd.Parameters.Add(new SqlParameter("@PreparedTime", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@ReportType", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@PatientId", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@RegNo", SqlDbType.NVarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@TestId", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@ConsultantId", SqlDbType.Int));




                SqlParameter contentParameter = null;
                contentParameter = new SqlParameter("@ReportContent", SqlDbType.VarBinary);
                contentParameter.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(contentParameter);

                
                cmd.Parameters["@TestName"].Value = newReport.TestInfo.Name;
                cmd.Parameters["@ReportContent"].Value = newReport.ReportContent;
                cmd.Parameters["@PreparedBy"].Value = newReport.PreparedBy;
                //cmd.Parameters["@PreparedDate"].Value = newReport.PreparedDate;
               // cmd.Parameters["@PreparedTime"].Value = newReport.Preparedtime;
                cmd.Parameters["@ReportType"].Value = newReport.ReportType;
                cmd.Parameters["@RegNo"].Value = newReport.RegNo;
                cmd.Parameters["@TestId"].Value = newReport.TestInfo.Id;
                cmd.Parameters["@ConsultantId"].Value = newReport._ReportDoctor.RCId;
                cmd.Parameters["@PatientId"].Value = newReport.PatientId;

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

                return "Success";
            }
            catch (Exception ex)
            {
                con.Close();
                return "Fail";
                
            }
        }

        public byte[] GetPreviuosReport(string[] Ids)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("SELECT ReportContent FROM dbo.Reports WHERE PatientId='{0}' and TestId='{1}'", Ids[0],Ids[1]);
                SqlCommand cmd = new SqlCommand(sql, con);
                byte[] img = (byte[])cmd.ExecuteScalar();
                con.Close();

                return img;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateTemplate(Template _template, int templateId)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE  dbo.Templates SET DoctorId=@DoctorId, GroupName=@GroupName,FileName=@FileName,TemplateName=@TemplateName,TemplateContent=@TemplateContent Where Id=@templateId");
                cmd.Parameters.Add(new SqlParameter("@DoctorId", SqlDbType.Int, 8));
                cmd.Parameters.Add(new SqlParameter("@GroupName", SqlDbType.NVarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@TemplateName", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@templateId", SqlDbType.Int, 8));
                
                SqlParameter contentParameter = null;
                contentParameter = new SqlParameter("@TemplateContent", SqlDbType.VarBinary);
                contentParameter.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(contentParameter);


                cmd.Parameters["@DoctorId"].Value = _template.DoctorId;
                cmd.Parameters["@GroupName"].Value = _template.GroupName;
                cmd.Parameters["@FileName"].Value = _template.FileName;
                cmd.Parameters["@TemplateName"].Value = _template.TemplateName;
                cmd.Parameters["@TemplateContent"].Value = _template.TemplateContent;
                cmd.Parameters["@templateId"].Value = templateId;

                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public bool IsMatchedSecurityCode(string securityCode)
        {
             try{
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("SELECT SecurityCode FROM dbo.MasterTemplate WHERE Id='1'");
                SqlCommand cmd = new SqlCommand(sql, con);
                string code = cmd.ExecuteScalar().ToString();
                con.Close();
               
                 if (code==securityCode){
                     return true;
                 }else{
                      return false;
                 }
                
               
            }
            catch
            {
                return false;
            }
        }

        public IList<TemplateType> GetMasterTemplateCategories()
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLabDbConnectionString();
            con.Open();
            da = new SqlDataAdapter("select * from dbo.MasterTemplateCategory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<TemplateType> listMasterTemplatetypes = new List<TemplateType>();

           
            listMasterTemplatetypes = new List<TemplateType>(
                (from dRow in dt.AsEnumerable()
                 select (GetMasterTemplateTypeDataTableRow(dRow)))
                );

            return listMasterTemplatetypes;
        }


        private TemplateType GetMasterTemplateTypeDataTableRow(DataRow dr)
        {
            TemplateType ttype = new TemplateType();
            ttype.Id = Convert.ToInt32(dr["Id"]);
            ttype.Name = dr["Name"].ToString();
          

            return ttype;
        }

        public IList<Template> GetItemsByType(string _templateType)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLabDbConnectionString();
            con.Open();

            int.TryParse(_templateType, out int _convertToInt);
            string sql;

            //if (_convertToInt > 0)
            //{
            //    sql = string.Format(@"select * from dbo.Templates Where DoctorId = {0}", Convert.ToInt32(_templateType));
            //}
            //{
            //    sql = string.Format("select * from dbo.Templates Where GroupName=" + "'" + _templateType + "'", con);

            //}


            sql = string.Format(@"select * from dbo.Templates Where DoctorId = {0}", Convert.ToInt32(_templateType));

            //da = new SqlDataAdapter("select * from dbo.Templates Where GroupName="+"'"+ _templateType + "'", con);

            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<Template> listTemplates = new List<Template>();

            listTemplates = new List<Template>(
                (from dRow in dt.AsEnumerable()
                 select (GetTemplateDataTableRow(dRow)))
                );

            return listTemplates;
        }
    }
}
