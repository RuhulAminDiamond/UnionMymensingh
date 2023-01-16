using HDMS.Model;
using HDMS.Model.ViewModel;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;

namespace HDMS.Service.Diagonstics
{
    public class TemplateService
    {

        public IList<Template> GetAllTemplate()
        {
            return new TemplateRepository().GetAllTemplate();
        }

        public Template GetTemplateById(int id)
        {
            return new TemplateRepository().GetTemplateById(id);
        }

        public byte[] GetWordTemplateContent(int templateId)
        {
            return new TemplateRepository().GetWordTemplateContent(templateId);
        }

        public string SaveReport(MsWordReport newReport)
        {
            return new TemplateRepository().SaveReport(newReport);
        }

        public System.Data.DataTable GetReports(ReportConsultant _Consultant, long regNo, DateTime _dt, string _type)
        {
            return new TemplateRepository().GetReports(_Consultant, regNo, _dt, _type);
        }

        public string GetNewReportFilePath()
        {
           return new TemplateRepository().GetNewReportFilePath();
           
        }

        public string GetOldReportFilePath()
        {
            return new TemplateRepository().GetOldReportFilePath();

        }

        public bool SaveTemplate(Template _template)
        {
            return new TemplateRepository().SaveTemplate(_template);
        }

      
        public bool SaveMasterTemplate(Template _template,TemplateType ttype)
        {
            return new TemplateRepository().SaveMasterTemplate(_template, ttype);
        }

        public byte[] GetWordMasterTemplateContent(int _templateCategory)
        {
            return new TemplateRepository().GetWordMasterTemplateContent(_templateCategory);
        }

        public bool IsReportExists(string RegNo, ViewModelReportTests viewModelReportTests)
        {
            return new TemplateRepository().IsReportExists(RegNo, viewModelReportTests);
        }

        public string UpdateReport(MsWordReport newReport)
        {
            return new TemplateRepository().UpdateReport(newReport);
        }

        public byte[] GetPreviousReport(string[] Ids)
        {
            return new TemplateRepository().GetPreviuosReport(Ids);
        }

        public bool UpdateTemplate(Template _template, int templateId)
        {
            return new TemplateRepository().UpdateTemplate(_template, templateId);
        }

        public bool UpdateDischareTemplate(DischargeTemplate _template, int templateId)
        {
            throw new NotImplementedException();
        }

        public bool IsMatchedSecurityCode(string securityCode)
        {
            return new TemplateRepository().IsMatchedSecurityCode(securityCode);
        }

        public bool SaveDischargeTemplate(DischargeTemplate _template)
        {
            return new TemplateRepository().SaveDischargeTemplate(_template);
        }

        public IList<TemplateType> GetMasterTemplateCategories()
        {
            return new TemplateRepository().GetMasterTemplateCategories();
        }

        public IList<Template> GetItemsByType(string _templateType)
        {
            return new TemplateRepository().GetItemsByType(_templateType);
        }

        public List<DischargeTemplate> GetAllDischargeTemplates()
        {
            return new TemplateRepository().GetAllDischargeTemplates();
        }

        public TemplateType GetMasterTemplateByCategory(string calledFrom)
        {
            return new TemplateRepository().GetMasterTemplateByCategory(calledFrom);
        }

        public DataTable GetRadiologyReports(ReportConsultant _consultant, string regNo, DateTime _datetime, string _type)
        {
            return new TemplateRepository().GetRadiologyReports(_consultant, regNo, _datetime, _type);
        }

        public byte[] GetDischargeMasterTemplateContent(int _Id)
        {
            return new TemplateRepository().GetDischargeMasterTemplateContent(_Id);
        }

        public string UpdateDischargeReport(DischargeCertificateTemplateBased _dc)
        {
            throw new NotImplementedException();
        }

        public DataTable GetNonLabReports(string billNo)
        {
            return new TemplateRepository().GetNonLabReports(billNo);
        }

        public DataTable GetNonLabPdfReports(string billNo)
        {
            return new TemplateRepository().GetNonLabPdfReports(billNo);
        }

        public string SaveDischargeReport(DischargeCertificateTemplateBased _dc)
        {
            return new TemplateRepository().SaveDischargeReport(_dc);
        }

        public bool DeleteExistingDischargeCertificate(VMIPDInfo _pInfo)
        {
            return new TemplateRepository().DeleteExistingDischargeCertificate(_pInfo);
        }
    }
}
