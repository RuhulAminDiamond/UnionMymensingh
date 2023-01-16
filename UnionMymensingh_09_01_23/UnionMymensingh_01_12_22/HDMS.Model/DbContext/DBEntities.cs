using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using HDMS.Model;
using HDMS.Model.Users;

using HDMS.Model.Diagnostic;
using HDMS.Model.Location;
using HDMS.Model.Common;
using HDMS.Model.Rx;
using Models.Accounting;
using HDMS.Model.Store;
using HDMS.Model.Pharmacy;
using HDMS.Models.Pharmacy;   
using HDMS.Model.Hospital;
using HDMS.Model.OPD;
using HDMS.Model.HR;
using Models.Canteen;
using HRM.Models;
using Models.Store;
using HDMS.Model.MiniAccount;
using HDMS.Model.LIS;
using HDMS.Model.FoodAndBeverage;
using Models.FoodAndBeverage;
using HDMS.Model.Marketing;
using HDMS.Model.Accounting;
using HDMS.Model.SCM;
using HDMS.Model.ShareHolder;
using HDMS.Model.Vehicle;
using HDMS.Model.Media;

public partial class DBEntities : DbContext
{
    public DBEntities()
            : base("name=DBEntities")
    {
        //this.Configuration.LazyLoadingEnabled = false;
         Database.SetInitializer<DBEntities>(null);
        var adapter = (System.Data.Entity.Infrastructure.IObjectContextAdapter)this;
        var objectContext = adapter.ObjectContext;
        objectContext.CommandTimeout = 120; //2 minutes
    }

    protected override void OnModelCreating(DbModelBuilder builder)
    {
        //builder.Configurations.Add(new UserMapping());
        //builder.Configurations.Add(new RoleMapping());
   
    }


    // Org Setting

    public virtual DbSet<OrgSetting> OrgSettings { get; set; }


    //LIS Module


   public virtual DbSet<TEMPLISPatientRecord> TEMPLISPatientRecords { get; set; }
    public virtual DbSet<TEMPLISResultRecord> TEMPLISResultRecords { get; set; }


    //End of LIS Module

    // Food And Beverage Module

    public virtual DbSet<FoodAndBeverageDept> FoodAndBeverageDepts { get; set; }
    public virtual DbSet<FoodAndBeverageGroup> FoodAndBeverageGroups { get; set; }
    public virtual DbSet<FoodAndBeverageInvoice> FoodAndBeverageInvoices { get; set; }
    public virtual DbSet<FoodAndBeverageInvoiceDetail> FoodAndBeverageInvoiceDetails { get; set; }

    public virtual DbSet<FoodAndBeverageItemUsesMaster> FoodAndBeverageItemUsesMasters { get; set; }
    public virtual DbSet<FoodAndBeverageMasterGroup> FoodAndBeverageMasterGroups { get; set; }
    public virtual DbSet<FoodAndBeverageProductInfo> FoodAndBeverageProductInfos { get; set; }
    public virtual DbSet<FoodAndBeverageReceive> FoodAndBeverageReceives { get; set; }

    public virtual DbSet<FoodAndBeverageReceiveDetail> FoodAndBeverageReceiveDetails { get; set; }
    public virtual DbSet<FoodAndBeverageRequisition> FoodAndBeverageRequisitions { get; set; }

    // End Of Food And Beverage Module

    public DbSet<ReportFee> ReportFees { get; set; }

    public virtual DbSet<LabInfo> LabInfoes { get; set; }
    public virtual DbSet<LabStockInfo> LabStockInfoes { get; set; }
    public virtual DbSet<LabRequisition> LabRequisitions { get; set; }
    public virtual DbSet<LabRequisitionDetail> LabRequisitionDetails { get; set; }


    public virtual DbSet<CantGroup> CantGroups { get; set; }
    public virtual DbSet<CantProductInfo> CantProductInfos { get; set; }
   
    public virtual DbSet<CantSaleLedger> CantSaleLedgers { get; set; }

    public virtual DbSet<CantInvoice> CantInvoices { get; set; }
    public virtual DbSet<CantInvoiceDetail> CantInvoiceDetails { get; set; }

    //public virtual DbSet<OrderSource> OrderSources { get; set; }

    public virtual DbSet<CantReceive> CantReceives { get; set; }
    public virtual DbSet<CantReceiveDetail> CantReceviceDetails { get; set; }

    public virtual DbSet<CantMemberInfo> CantMemberInfoes { get; set; }

    public virtual DbSet<CantMemberLedger> CantMemberLedgers { get; set; }

    public virtual DbSet<DischargeTemplate> DischargeTemplates { get; set; }
    public virtual DbSet<DischargeCertificateMaster> DischargeCertificateMasters { get; set; }
    public virtual DbSet<DischargeCertificateDetail> DischargeCertificateDetails { get; set; }
    public virtual DbSet<TreatmentOnDischarge> TreatmentOnDischarges { get; set; }
    

    public virtual DbSet<FloorServiceDeleteLog> FloorServiceDeleteLogs { get; set; }
    

    public virtual DbSet<DiscountCardMaster> DiscountCardMasters { get; set; }
    public virtual DbSet<DiscountCardType> DiscountCardTypes { get; set; }
    public virtual DbSet<DiscountCard> DiscountCards { get; set; }
    public virtual DbSet<DiscountCardPrintView> DiscountCardPrintViews { get; set; }

    // Diag Media

    public virtual DbSet<BusinessMedia> BusinessMedias { get; set; }
    public virtual DbSet<MediaLedger> MediaLedgers { get; set; }
    public virtual DbSet<ConsultentLedger> ConsultentLedgers { get; set; }

    //Member
    public virtual DbSet<PhMemberInfo> PhMemberInfoes { get; set; }
     public virtual DbSet<MemberInfo> MemberInfos { get; set; }
     public virtual DbSet<MemberLedger> MemberLedgers { get; set; }
     public virtual DbSet<MediaCategoryReportTypeCommission> MediaCategoryReportTypeCommissions { get; set; }

    //HR Modules
    public virtual DbSet<EmployeeEducationalQualification> EmployeeEducationalQualifications { get; set; }

    //HR Modules
    public virtual DbSet<TimedAttendanceLogPullHistory> TimedAttendanceLogPullHistories { get; set; }
    public virtual DbSet<TimedAttendanceLog> TimedAttendanceLogs { get; set; }
    public virtual DbSet<TempGAttendanceLogData> TempGAttendanceLogDatas { get; set; }
    public virtual DbSet<EmployeeLeaveRecord> EmployeeLeaveRecords { get; set; }
    public virtual DbSet<LeaveApprovalSetting> LeaveApprovalSettings { get; set; }
    public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }
    public virtual DbSet<HrWokingDay> HrWokingDays { get; set; }
    public virtual DbSet<EmpAttendanceRecord> EmpAttendanceRecords { get; set; }
    public virtual DbSet<HRPolicy> HRPolicies { get; set; }
    public virtual DbSet<EmpLoanInfo> EmpLoanInfoes { get; set; }
    public virtual DbSet<LoanInstallmentCollection> LoanInstallmentCollections { get; set; }
    public virtual DbSet<JobCV> JobCVs { get; set; }
    public virtual DbSet<JobCirculation> JobCirculations { get; set; }
    public virtual DbSet<HRSalaryPolicy> HRSalaryPolicy { get; set; }
    public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }
    public virtual DbSet<EmpDesignation> EmpDesignations { get; set; }
    public virtual DbSet<EmpDepartment> EmpDepartments { get; set; }
    public virtual DbSet<PhMemberLedger> PhMemberLedgers { get; set; }


    public virtual DbSet<EmpDivision> EmpDivisions { get; set; }
    public virtual DbSet<BloodGroup> BloodGroups { get; set; }
    public virtual DbSet<MaritalStatus> MaritulStatus { get; set; }

    public virtual DbSet<MediaCategory> MediaCategories { get; set; }


    public virtual DbSet<Religion> Religions { get; set; }
    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<EmployeeRoster> EmployeeRosters { get; set; }


    public virtual DbSet<EmployeeRosterMasterInfo> EmployeeRosterMasterInfos { get; set; }


    // HOSPITAL MODULES


    public virtual DbSet<ModifiedCabinCharge> ModifiedCabinCharges { get; set; }
    public virtual DbSet<FloorAndDeptMapping> FloorAndDeptMappings { get; set; }
    public virtual DbSet<HpPackage> HpPackages { get; set; }
    public virtual DbSet<HpPkgSubItem> HpPkgSubItems { get; set; }

    public virtual DbSet<OPDProcedureServiceBill> OPDProcedureServiceBills { get; set; }
    public virtual DbSet<OPDProcedureServiceBillDetail> OPDProcedureServiceBillDetails { get; set; }
    public virtual DbSet<DisplaySetting> DisplaySettings { get; set; }

    public virtual DbSet<HpDayWiseBill> HpDayWiseBills { get; set; }
    public virtual DbSet<HpDayWiseBillDetail> HpDayWiseBillDetails { get; set; }
    public virtual DbSet<HPDayWiseBillingLedger> HPDayWiseBillingLedgers { get; set; }

    //RoughBill Modules
    public virtual DbSet<HospitalRoughBill> HospitalRoughBills { get; set; }
    public virtual DbSet<HospitalRoughBillDetail> HospitalRoughBillDetails { get; set; }
    public virtual DbSet<HpPatientLedgerRough> HpPatientLedgerRoughs { get; set; }
    //End of Rough Bill Modules

    public virtual DbSet<HpOPDBill> HpOPDBills { get; set; }
    public virtual DbSet<HpOPDBillDetail> HpOPDBillDetails { get; set; }

    public virtual DbSet<OPDDoctorServiceBillDetail> OPDDoctorServiceBillDetails { get; set; }
    public virtual DbSet<HpOPDServiceBill> HpOPDServiceBills { get; set; }
    public virtual DbSet<OPDServiceBillDetail> OPDServiceBillDetails { get; set; }
    public virtual DbSet<OPDServiceCost> OPDServiceCosts { get; set; }
    public virtual DbSet<OPDPatientLedger> OPDPatientLedgers { get; set; }
    public virtual DbSet<OPDPatientRecord> OPDPatientRecords { get; set; }
    public virtual DbSet<OPDServiceGroup> OPDServiceGroups { get; set; }
    public virtual DbSet<OPDServiceSubGroup> OPDServiceSubGroups { get; set; }

    public virtual DbSet<OPDServiceHead> OPDServiceHeads { get; set; }

    public virtual DbSet<OPDPatientVisitType> OPDPatientVisitTypes { get; set; }
    public virtual DbSet<OPDPatientLedgerRough> OPDPatientLedgerRoughs { get; set; }
    public virtual DbSet<OpdProcedureBill> OpdProcedureBills { get; set; }
    public virtual DbSet<OpdProcedureBillDetails> OpdProcedureBillDetails { get; set; }
    public virtual DbSet<OpdProcedurepatientLedger> OpdProcedurepatientLedgers { get; set; }

    public virtual DbSet<OpdProcedureBillDistributionDetail> OpdProcedureBillDistributionDetails { get; set; }
    public virtual DbSet<OpdProcedureBillDistribution> OpdProcedureBillDistributions { get; set; }

    public virtual DbSet<HpOPDConsultantCategory> HpOPDConsultantCategories { get; set; }

    public virtual DbSet<RegUniqueKeyTracker> RegUniqueKeyTrackers { get; set; }

    public virtual DbSet<HpAdvancePayment> HpAdvancePayments { get; set; }
    public virtual DbSet<OPDAdvancePayment> OPDAdvancePayments { get; set; }
    
    public virtual DbSet<HpCabinCharge> HpCabinCharges { get; set; }

    public virtual DbSet<HpPatientLedgerFinal> HpPatientLedgerFinals { get; set; }
    public virtual DbSet<HpMedicineReturnInednt> HpMedicineReturnInednts { get; set; }

    public virtual DbSet<HpMedicineReturnIndentDetail> HpMedicineReturnIndentDetails { get; set; }
    public virtual DbSet<HpPatientAccomodationInfo> HpPatientAccomodationInfoes { get; set; }
    public virtual DbSet<HpDoctorServiceBill> HpDoctorServiceBills { get; set; }
    public virtual DbSet<HpServiceBill> HpServiceBills { get; set; }
    public virtual DbSet<HpPatientAccomodationType> HpPatientAccomodationTypes { get; set; }
    public virtual DbSet<FloorInfo> FloorInfos { get; set; }
    public virtual DbSet<HpRequisitionType> HpRequisitionTypes { get; set; }
    public virtual DbSet<HpDepartment> HpDepartments { get; set; }
    public virtual DbSet<HpMedicineRequisition> HpMedicineRequisitions { get; set; }
    public virtual DbSet<HpMedicineRequisitionDetail> HpMedicineRequisitionDetails { get; set; }

    public virtual DbSet<HpCabinChargeSegmantMaster> HpCabinChargeSegmantMasters { get; set; }

    public virtual DbSet<HpCabinChargeSegmantDetail> HpCabinChargeSegmantDetails { get; set; }

    public virtual DbSet<HpConsultantLedger> HpConsultantLedgers { get; set; }
    public virtual DbSet<HpPatientLedger> HpPatientLedgers { get; set; }
    public virtual DbSet<HpParameterSetup> HpParameterSetups { get; set; }
    public virtual DbSet<CabinInfo> CabinInfos { get; set; }
    public virtual DbSet<WardInfo> WardInfos { get; set; }

    public virtual DbSet<WardBedInfo> WardBedInfos { get; set; }
    public virtual DbSet<DoctorServiceBillDetail> DoctorServiceBillDetails { get; set; }
    public virtual DbSet<DoctorServiceDeleteLog> DoctorServiceDeleteLogs { get; set; }

    public virtual DbSet<ServiceBillDetail> ServiceBillDetails { get; set; }
    public virtual DbSet<OTSchedule> OTSchedules { get; set; }
    public virtual DbSet<OTExecutionDetail> OTExecutionDetails { get; set; }
    public virtual DbSet<ServiceGroup> ServiceGroups { get; set; }
    public virtual DbSet<ServiceSubGroup> ServiceSubGroups { get; set; }

    public virtual DbSet<ServiceHead> ServiceHeads { get; set; }

    public virtual DbSet<HospitalPatientInfo> HospitalPatientInfoes { get; set; }
    public virtual DbSet<OperationConsent> OperationConsents { get; set; }
    public virtual DbSet<OutDoorPatient> OutDoorPatients { get; set; }
    public virtual DbSet<OutDoorIncome> OutDoorIncomes { get; set; }
 
    public virtual DbSet<HospitalBill> HospitalBills { get; set; }

    public virtual DbSet<HospitalBillDetail> HospitalBillDetails { get; set; }

    public virtual DbSet<LedgerOfHospitalBillPayment> LedgerOfHospitalBillPayments { get; set; }

    //End Of Hospital Module

    public DbSet<ReportConsultantWorkList> ReportConsultantWorkLists { get; set; }
    public DbSet<MasterTestGroup> MasterTestGroups { get; set; }

    public DbSet<ReferralCategory> ReferralCategories { get; set; }


    public DbSet<SampleCollectionSetting> SampleCollectionSettings { get; set; }

    //=======================Store==================
    //=======================Store==================
    public virtual DbSet<SCMPO> SCMPOes { get; set; }
    public virtual DbSet<SCMPODetail> SCMPODetails { get; set; }
    public virtual DbSet<SCMPRApproval> SCMPRApprovals { get; set; }
    public virtual DbSet<SCMPR> SCMPRs { get; set; }
    public virtual DbSet<SCMPRDetail> SCMPRDetails { get; set; }
    public virtual DbSet<SCMPRAppovalRecord> SCMPRAppovalRecords { get; set; }
    public virtual DbSet<SCMPRAppovalRecordDetail> SCMPRAppovalRecordDetails { get; set; }

    public virtual DbSet<StoreItemUsesMaster> StoreItemUsesMasters { get; set; }
    public virtual DbSet<StoreItemUsesMasterDetail> StoreItemUsesMasterDetails { get; set; }
    public virtual DbSet<StoreRequisitionDetail> StoreRequisitionDetails { get; set; }
    public virtual DbSet<StoreDept> StoreDepts { get; set; }
    public virtual DbSet<StoreRequisition> StoreRequisitions { get; set; }
    public virtual DbSet<StoreMasterGroup> StoreMasterGroups { get; set; }
    public virtual DbSet<StoreGroup> StoreGroups { get; set; }
    public virtual DbSet<StoreProductInfo> StoreProductInfoes { get; set; }
    public virtual DbSet<StoreReceive> StoreReceives { get; set; }
    public virtual DbSet<StoreReceiveDetail> StoreReceiveDetails { get; set; }
    public virtual DbSet<StoreInvoice> StoreInvoices { get; set; }
    public virtual DbSet<StoreInvoiceDetail> StoreInvoiceDetails { get; set; }
    public virtual DbSet<StoreDeptUser> StoreDeptUsers { get; set; }
    public virtual DbSet<StoreLotInfo> StoreLotInfoes { get; set; }
    public virtual DbSet<StoreStcokInfo> StoreStcokInfoes { get; set; }
    public virtual DbSet<StoreReturnToSupplier> StoreReturnToSuppliers { get; set; }
    public virtual DbSet<StoreReturnProductDetil> StoreReturnProductDetils { get; set; }

    //Accounting

    public virtual DbSet<AccountsAutoImportLog> AccountsAutoImportLogs { get; set; }
    public virtual DbSet<AccountHead> AccountHeads { get; set; }
    public virtual DbSet<Voucher> Vouchers { get; set; }
    public virtual DbSet<VoucherDetail> VoucherDetails { get; set; }
    public virtual DbSet<FiscalYear> FiscalYears { get; set; }
    public virtual DbSet<AccOpeningBalance> AccOpeningBalances { get; set; }

    public virtual DbSet<MiniAccountHead> MiniAccountHeads { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<DeptGroupWithAccountMapping> DeptGroupWithAccountMappings { get; set; }

    //=========Common===========================

    public virtual DbSet<PaymentMode> PaymentModes { get; set; }
    public virtual DbSet<Relation> Relations { get; set; }
    
    public virtual DbSet<PaymentChannel> PaymentChannels { get; set; }
    public virtual DbSet<Occupation> Occupations { get; set; }
    public virtual DbSet<TitleOrNamePrefix> TitleOrNamePrefixes { get; set; }
    public virtual DbSet<RegRecord> RegRecords { get; set; }

    public virtual DbSet<RegDiscountPlan> RegDiscountPlans { get; set; }
    public virtual DbSet<CorporateClient> CorporateClients { get; set; }
    public virtual DbSet<RegDesignation> RegDesignations { get; set; }
    public virtual DbSet<RegStatus> RegStatuses { get; set; }

    public virtual DbSet<CompanyInfo> CompanyInfos { get; set; }
    public virtual DbSet<OrganizationInfo> OrganizationInfos { get; set; }
    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
  
    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<SupplierInfo> SupplierInfoes { get; set; }

    public virtual DbSet<SupplierLedger> SupplierLedgers { get; set; }
    public virtual DbSet<ManufacturerLedger> ManufacturerLedgers { get; set; }


    public virtual DbSet<OpdOrEmgStock> OpdOrEmgStocks { get; set; }

    //Rx-Prescription

    public virtual DbSet<MedicineInterX> MedicineInterXes { get; set; }
    public virtual DbSet<RxPrintFormatTemplate> RxPrintFormatTemplates { get; set; }
    public virtual DbSet<RxCpDosageWithGenericMapping> RxCpDosageWithGenericMappings { get; set; }
    public virtual DbSet<RxCarryOnBlock> RxCarryOnBlocks { get; set; }
    public virtual DbSet<RxPersonalPreferenceSetting> RxPersonalPreferenceSettings { get; set; }
    public virtual DbSet<RxDosage> RxDosages { get; set; }
    public virtual DbSet<RxCompletedTestMaster> RxCompletedTestMasters { get; set; }
    public virtual DbSet<RxCompletedTestDetail> RxCompletedTestDetails { get; set; }

    public virtual DbSet<RxDoseEMRInterpretation> RxDoseEMRInterpretations { get; set; }
    public virtual DbSet<RxCpPreferredTestParameterMaster> RxCpPreferredTestParameterMasters { get; set; }
    public virtual DbSet<RxCpPreferredTestParameterDetail> RxCpPreferredTestParameterDetails { get; set; }
    public virtual DbSet<RxCpDrugHistoryTemplate> RxCpDrugHistoryTemplates { get; set; }
    public virtual DbSet<RxCpOtherFindingTemplate> RxCpOtherFindingTemplates { get; set; }
    public virtual DbSet<RxCpAdditionalInfoTemplate> RxCpAdditionalInfoTemplates { get; set; }
    public virtual DbSet<RxCpHistoryTemplate> RxCpHistoryTemplates { get; set; }
    public virtual DbSet<RxCpAdviceTemplateMaster> RxCpAdviceTemplateMasters { get; set; }
    public virtual DbSet<RxCpAdviceTemplateDetail> RxCpAdviceTemplateDetails { get; set; }
    public virtual DbSet<RxCpSupportUserAccessOption> RxCpSupportUserAccessOptions { get; set; }
    public virtual DbSet<RxCPPrintPageSetup> RxCPPrintPageSetups { get; set; }
    public virtual DbSet<TmpPrescriptionDataPart1> TmpPrescriptionDataPart1s { get; set; }
    public virtual DbSet<TmpPrescriptionDataPart2> TmpPrescriptionDataPart2s { get; set; }
    public virtual DbSet<TmpPrescriptionDataPart3> TmpPrescriptionDataPart3s { get; set; }

    public virtual DbSet<RxCpCC> RxCpCCs { get; set; }
    public virtual DbSet<RxCPPreferredMedicine> RxCPPreferredMedicines { get; set; }
    public virtual DbSet<RxCPPreferredTest> RxCPPreferredTests { get; set; }
    public virtual DbSet<RxCPAdvice> RxCPAdvices { get; set; }
    public virtual DbSet<RxCPDrugHistory> RxCPDrugHistories { get; set; }
    public virtual DbSet<RxCPHistory> RxCPHistories { get; set; }
    public virtual DbSet<RxCPPastHistory> RxCPPastHistories { get; set; }
    public virtual DbSet<RxCPOtherFinding> RxCPOtherFindings { get; set; }
    public virtual DbSet<RxCPTreatmentPlan> RxCPTreatmentPlans { get; set; }
    public virtual DbSet<CPOffDayCalender> CPOffDayCalenders { get; set; }

    public virtual DbSet<RxCPDiseaseTemplate> RxCPDiseaseTemplates { get; set; }
    public virtual DbSet<RxCPDiseaseTemplateHistoricalData> RxCPDiseaseTemplateHistoricalDatas { get; set; }
    public virtual DbSet<RxCPDiseaseTemplateTreatmentData> RxCPDiseaseTemplateTreatmentDatas { get; set; }
    public virtual DbSet<RxCPDiseaseTemplateTestData> RxCPDiseaseTemplateTestDatas { get; set; }
    public virtual DbSet<RxCPDiseaseTemplateAdviceData> RxCPDiseaseTemplateAdviceDatas { get; set; }
    

    public virtual DbSet<RxInitialData> RxInitialDatas { get; set; }
    public virtual DbSet<RxDiagnosis> RxDiagnosises { get; set; }

    public virtual DbSet<RxCpDosage> RxCpDosages { get; set; }
    public virtual DbSet<RxDuration> RxDurations { get; set; }
    public virtual DbSet<Symtomp> Symtomps { get; set; }
    public virtual DbSet<RxPatientMasterData> RxPatientMasterDatas { get; set; }
    public virtual DbSet<RxVisitHistory> RxVisitHistories { get; set; }
    public virtual DbSet<RxAdviceToPatient> RxAdviceToPatients { get; set; }

    public virtual DbSet<RxDrug> RxDrugs { get; set; }
    public virtual DbSet<RxTest> RxTests { get; set; }
    
    public virtual DbSet<RxPrintPreference> RxPrintPreferences { get; set; }

    public virtual DbSet<RxCPDrugTemplateMaster> RxCPDrugTemplateMasters { get; set; }
    public virtual DbSet<RxCPDrugTemplateDetail> RxCPDrugTemplateDetails { get; set; }
    public virtual DbSet<RxCPTestTemplateMaster> RxCPTestTemplateMasters { get; set; }
    public virtual DbSet<RxCPTestTemplateDetail> RxCPTestTemplateDetails { get; set; }

    public virtual DbSet<RxDoseApplication> RxDoseApplications { get; set; }
    //End of Rx

    //Pharmacy

    public virtual DbSet<PhSupplierLedger> PhSupplierLedgers { get; set; }
    public DbSet<PhProductLocation> PhProductLocations { get; set; }
    public DbSet<PhProductLedger> PhProductLedgers { get; set; }
    public DbSet<PhOutletMedicinieRequisition> PhOutletMedicinieRequisitions { get; set; }
    public DbSet<PhOutletMedicineRequisitionDetail> PhOutletMedicineRequisitionDetails { get; set; }
    public DbSet<PhStockInfoesDateWiseHistory> PhStockInfoesDateWiseHistories { get; set; }
    public virtual DbSet<PhTemIPDReturnLadger> PhTemIPDReturnLadgers { get; set; }
    public virtual DbSet<PhStockTransferRecord> PhStockTransferRecords { get; set; }
    public virtual DbSet<PhStockTransferRecordDetail> PhStockTransferRecordDetails { get; set; }
    public virtual DbSet<PhIPDSaleLedger> PhIPDSaleLedgers { get; set; }
    public virtual DbSet<PhReturnToSupplier> PhReturnToSuppliers { get; set; }
    public virtual DbSet<PhSupplierReturnDetail> PhSupplierReturnDetails { get; set; }

    public virtual DbSet<PhLotInfo> PhLotInfoes { get; set; }
    public virtual DbSet<PhStockInfo> PhStockInfoes { get; set; }
    public virtual DbSet<MedicineOutlet> MedicineOutlets { get; set; }
    public virtual DbSet<PhSaleLedger> PhSaleLedgers { get; set; }
    public virtual DbSet<PhInvoiceType> PhInvoiceTypes { get; set; }
    public virtual DbSet<PhCompany> PhCompanies { get; set; }
    public virtual DbSet<PhOrder> PhOrders { get; set; }
    public virtual DbSet<PhOrderDetail> PhOrderDetails { get; set; }
    public virtual DbSet<PhInvoice> PhInvoices { get; set; }
    public virtual DbSet<PhInvoiceDetail> PhInvoiceDetails { get; set; }
    public virtual DbSet<PhReceive> PhReceives { get; set; }
    public virtual DbSet<PhReceiveDetail> PhReceiveDetails { get; set; }
    public virtual DbSet<PhStockAuditMaster> PhStockAuditMasters { get; set; }
    public virtual DbSet<PhStockAuditMasterDetail> PhStockAuditMasterDetails { get; set; }

    public virtual DbSet<DischargeCertificateTemplateBased> DischargeCertificateTemplateBaseds { get; set; }


    public virtual DbSet<PhProductInfo> PhProductInfos { get; set; }

   
    public virtual DbSet<PhProductGroup> PhProductGroups { get; set; }
    public virtual DbSet<Manufacturer> Manufacturers { get; set; }
   // public virtual DbSet<PhSubGroup> PhSubGroups { get; set; }
    public virtual DbSet<Generic> Generics { get; set; }
    public virtual DbSet<Formation> Formations { get; set; }
    public virtual DbSet<Strength> Strengths { get; set; }

    public virtual DbSet<PhTempIPDLedger> PhTempIPDLedgers { get; set; }
    public virtual DbSet<PhPurchaseLedger> PhPurchaseLedgers { get; set; }

    //End of Pharmacy

    //=============Location===================================

    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Division> Divisions { get; set; }
    public virtual DbSet<District> Districts { get; set; }
    public virtual DbSet<UpazilaOrArea> UpazilaOrAreas { get; set; }
    public virtual DbSet<Union> Unions { get; set; }


    //Test Settings

    public virtual DbSet<ReportType> ReportTypes { get; set; }
    public virtual DbSet<TestSubItem> TestSubItems { get; set; }


    //End of Test Settings

 public virtual DbSet<ReagentWithTest> ReagentWithTests { get; set; }
 public virtual DbSet<DailyStatement> DailyStatement { get; set; }
 public virtual DbSet<ReportDefination> ReportDefinations { get; set; }

 public virtual DbSet<Consultant> Consultants { get; set; }


public virtual DbSet<Doctor> Doctors { get; set; }

public virtual DbSet<User> Users { get; set; }
public virtual DbSet<Role> Roles { get; set; }
public virtual DbSet<UserRole> UserRoles { get; set; }
public virtual DbSet<Module> Modules { get; set; }
public virtual DbSet<ParentMenu> ParentMenus { get; set; }
public virtual DbSet<ModulePermission> ModulePermissions { get; set; }

public virtual DbSet<PathologicalMachine> PathologicalMachines { get; set; }

 public virtual DbSet<PatientLedger> PatientLedgers { get; set; }

public virtual DbSet<Patient> Patients { get; set; }
public virtual DbSet<ReportDeliveryTimingMaster> ReportDeliveryTimingMasters { get; set; }
public virtual DbSet<ReportDeliveryTimingDetail> ReportDeliveryTimingDetails { get; set; }
public virtual DbSet<ReportConsultant> ReportConsultants { get; set; }
public virtual DbSet<TestGroup> TestGroups { get; set; }
public virtual DbSet<TestItem> TestItems { get; set; }
public virtual DbSet<TestItemDetail> TestItemDetails { get; set; }
public virtual DbSet<PathologyNormalValue> PathologyNormalValues { get; set; }
public virtual DbSet<PathReportValueComboType> PathReportValueComboTypes { get; set; }
public virtual DbSet<TestsCost> TestsCosts { get; set; }

public virtual DbSet<GroupReportItem> GroupReportItems { get; set; }

public virtual DbSet<ConsultantFee> ConsultantFees { get; set; }




public virtual DbSet<VacuType> VacuTypes { get; set; }
public virtual DbSet<VacuWithTestSetting> VacuWithTestSettings { get; set; }
    
public virtual DbSet<BarCodeLabelSettingForTest> BarCodeLabelSettingForTests { get; set; }
public virtual DbSet<PathologyReport> PathologyReports { get; set; }
public virtual DbSet<PathologyNonWordReportReportDetail> PathologyNonWordReportReportDetails { get; set; }

public virtual DbSet<ReportTechnologist> ReportTechnologist { get; set; }



//Chamber Practitioners
public virtual DbSet<ChamberPractitionerSpeciality> ChamberPractitionerSpecialities { get; set; }
public virtual DbSet<ChamberPractitioner> ChamberPractitioners { get; set; }
public virtual DbSet<PractitionerWisePatientSerial> PractitionerWisePatientSerials { get; set; }


//Marketing
public virtual DbSet<MarketingAgent> MarketingAgents { get; set; }

    //Shareholder Model
    public virtual DbSet<ShareHolderBasicData> ShareHolderBasicDatas { get; set; }
    public virtual DbSet<ShareHolderDescendantsInfo> ShareHolderDescendantsInfoes { get; set; }
    public virtual DbSet<ShareHolderRelation> ShareHolderRelations { get; set; }
    public virtual DbSet<ShareInfo> ShareInfoes { get; set; }
    public virtual DbSet<ShareHolderLedger> ShareHolderLedgers { get; set; }
    public virtual DbSet<ShareTransferInfo> ShareTransferInfoes { get; set; }
    public virtual DbSet<DividentInfo> DividentInfoes { get; set; }
    public virtual DbSet<ShareWithdrawdata> ShareWithdrawdatas { get; set; }
    public virtual DbSet<YearOnYearShareInfo> YearOnYearShareInfoes { get; set; }
    public virtual DbSet<RightShareInfo> RightShareInfoes { get; set; }


    // Dash Board Models
    public virtual DbSet<DashBoardAccGeneralInfo> DashBoardAccGeneralInfoes { get; set; }

    // Vehicle Management
    public virtual DbSet<CarInfo> CarInfoes { get; set; }
    public virtual DbSet<DriverInfo> DriverInfoes { get; set; }
    public virtual DbSet<RoutingOrTripInfo> RoutingOrTripInfoes { get; set; }
    public virtual DbSet<CarAllotmentInfo> CarAllotmentInfoes { get; set; }
    public virtual DbSet<CarAndDriverLedger> CarAndDriverLedgers { get; set; }

    public virtual DbSet<PatientWiseMediaCommission> PatientWiseMediaCommissions { get; set; }

    public virtual DbSet<MediaCommissionGroup> MediaCommissionGroups { get; set; }

}