namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorServiceBillDetails",
                c => new
                    {
                        DSBId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DSBId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.HospitalPatientInfoes", t => t.AdmissionId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceHeads", t => t.ServiceHeadId, cascadeDelete: true)
                .Index(t => t.AdmissionId)
                .Index(t => t.ServiceHeadId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.HospitalPatientInfoes",
                c => new
                    {
                        AdmissionId = c.Long(nullable: false, identity: true),
                        RegNo = c.Long(nullable: false),
                        GurdianType = c.String(),
                        GurdianName = c.String(),
                        AgeYear = c.String(),
                        AgeMonth = c.String(),
                        AgeDay = c.String(),
                        BedCabinNo = c.String(),
                        AssignDoctorId = c.Int(nullable: false),
                        RefdDoctorId = c.Int(nullable: false),
                        AdmissionFee = c.Int(nullable: false),
                        Status = c.String(),
                        AddmissionDate = c.DateTime(nullable: false),
                        Time = c.String(),
                        DischargeDate = c.DateTime(),
                        DischargeTime = c.String(),
                    })
                .PrimaryKey(t => t.AdmissionId);
            
            CreateTable(
                "dbo.ServiceHeads",
                c => new
                    {
                        ServiceHeadId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubGroupId = c.Int(nullable: false),
                        ServiceHeadName = c.String(),
                        Rate = c.Double(nullable: false),
                        Unit = c.String(),
                        Vat = c.Boolean(nullable: false),
                        ServiceCharge = c.Boolean(nullable: false),
                        DocVisit = c.Boolean(nullable: false),
                        Show = c.Boolean(nullable: false),
                        OpdShow = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Createdby = c.String(),
                        modifiedby = c.String(),
                        Modifieddate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceHeadId)
                .ForeignKey("dbo.ServiceGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceSubGroups", t => t.SubGroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubGroupId);
            
            CreateTable(
                "dbo.ServiceGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Createdby = c.String(),
                        modifiedby = c.String(),
                        Modifieddate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.ServiceSubGroups",
                c => new
                    {
                        SubGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubGroupType = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Createdby = c.String(),
                        modifiedby = c.String(),
                        Modifieddate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubGroupId);
            
            CreateTable(
                "dbo.HospitalBilldetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        BillItemId = c.Int(nullable: false),
                        DeliveredUnit = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        ReportOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitalBillingItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Double(nullable: false),
                        IserviceCharge = c.String(),
                        IsVat = c.String(),
                        IsReferralCommission = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitlBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        Billby = c.String(),
                        Invdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LedgerOfHospitalBillPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        HCVSerialNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationConsents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Consent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OTExecutionDetails",
                c => new
                    {
                        OTDId = c.Long(nullable: false, identity: true),
                        OTId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.OTDId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.OTSchedules", t => t.OTId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceHeads", t => t.ServiceHeadId, cascadeDelete: true)
                .Index(t => t.OTId)
                .Index(t => t.ServiceHeadId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.OTSchedules",
                c => new
                    {
                        OTId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        OSDate = c.DateTime(nullable: false),
                        OSTime = c.String(),
                        OEDate = c.DateTime(nullable: false),
                        OETime = c.String(),
                        ChiefSurgeonId = c.Long(nullable: false),
                        OTType = c.String(),
                        OEStatus = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.OTId)
                .ForeignKey("dbo.HospitalPatientInfoes", t => t.AdmissionId, cascadeDelete: true)
                .Index(t => t.AdmissionId);
            
            CreateTable(
                "dbo.OutDoorIncomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PaymentType = c.String(),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        HCVSerialNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OutDoorPatients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DailyId = c.Int(nullable: false),
                        RegNo = c.String(),
                        ServiceFor = c.String(),
                        Name = c.String(),
                        Age = c.String(),
                        GurdianName = c.String(),
                        Village = c.String(),
                        Union = c.String(),
                        Upazilla = c.String(),
                        MobileNo = c.String(),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceBillDetails",
                c => new
                    {
                        SBDId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SBDId)
                .ForeignKey("dbo.HospitalPatientInfoes", t => t.AdmissionId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceHeads", t => t.ServiceHeadId, cascadeDelete: true)
                .Index(t => t.AdmissionId)
                .Index(t => t.ServiceHeadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceBillDetails", "ServiceHeadId", "dbo.ServiceHeads");
            DropForeignKey("dbo.ServiceBillDetails", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropForeignKey("dbo.OTExecutionDetails", "ServiceHeadId", "dbo.ServiceHeads");
            DropForeignKey("dbo.OTExecutionDetails", "OTId", "dbo.OTSchedules");
            DropForeignKey("dbo.OTSchedules", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropForeignKey("dbo.OTExecutionDetails", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.DoctorServiceBillDetails", "ServiceHeadId", "dbo.ServiceHeads");
            DropForeignKey("dbo.ServiceHeads", "SubGroupId", "dbo.ServiceSubGroups");
            DropForeignKey("dbo.ServiceHeads", "GroupId", "dbo.ServiceGroups");
            DropForeignKey("dbo.DoctorServiceBillDetails", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropForeignKey("dbo.DoctorServiceBillDetails", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.ServiceBillDetails", new[] { "ServiceHeadId" });
            DropIndex("dbo.ServiceBillDetails", new[] { "AdmissionId" });
            DropIndex("dbo.OTSchedules", new[] { "AdmissionId" });
            DropIndex("dbo.OTExecutionDetails", new[] { "DoctorId" });
            DropIndex("dbo.OTExecutionDetails", new[] { "ServiceHeadId" });
            DropIndex("dbo.OTExecutionDetails", new[] { "OTId" });
            DropIndex("dbo.ServiceHeads", new[] { "SubGroupId" });
            DropIndex("dbo.ServiceHeads", new[] { "GroupId" });
            DropIndex("dbo.DoctorServiceBillDetails", new[] { "DoctorId" });
            DropIndex("dbo.DoctorServiceBillDetails", new[] { "ServiceHeadId" });
            DropIndex("dbo.DoctorServiceBillDetails", new[] { "AdmissionId" });
            DropTable("dbo.ServiceBillDetails");
            DropTable("dbo.OutDoorPatients");
            DropTable("dbo.OutDoorIncomes");
            DropTable("dbo.OTSchedules");
            DropTable("dbo.OTExecutionDetails");
            DropTable("dbo.OperationConsents");
            DropTable("dbo.LedgerOfHospitalBillPayments");
            DropTable("dbo.HospitlBills");
            DropTable("dbo.HospitalBillingItems");
            DropTable("dbo.HospitalBilldetails");
            DropTable("dbo.ServiceSubGroups");
            DropTable("dbo.ServiceGroups");
            DropTable("dbo.ServiceHeads");
            DropTable("dbo.HospitalPatientInfoes");
            DropTable("dbo.DoctorServiceBillDetails");
        }
    }
}
