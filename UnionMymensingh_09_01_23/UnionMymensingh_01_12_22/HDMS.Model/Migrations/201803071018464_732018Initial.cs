namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _732018Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountHeads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChamberPractitioners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Identity1 = c.String(),
                        Identity2 = c.String(),
                        Identity3 = c.String(),
                        Identity4 = c.String(),
                        Identity5 = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GroupId = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyStatement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Name = c.String(),
                        Investigations = c.String(),
                        Pathology = c.Double(nullable: false),
                        XRay = c.Double(nullable: false),
                        USG = c.Double(nullable: false),
                        ECG = c.Double(nullable: false),
                        ENDO = c.Double(nullable: false),
                        CC = c.Double(nullable: false),
                        ECHO = c.Double(nullable: false),
                        Histo = c.Double(nullable: false),
                        Medicine = c.Double(nullable: false),
                        Due = c.Double(nullable: false),
                        Less = c.Double(nullable: false),
                        DoctorName = c.String(),
                        DueCollectedOn = c.String(),
                        USGDoctor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        trandate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Description = c.String(),
                        PaymentBy = c.String(),
                        EntryBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupReportItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupTestId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModulePermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionId = c.Int(nullable: false),
                        PermissionType = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParentMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PathologicalMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineName = c.String(),
                        ApplicableFor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PathologyNonWordReportReportDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        TestDetailId = c.Int(nullable: false),
                        TestTitle = c.String(),
                        TestResult = c.String(),
                        ResultUnit = c.String(),
                        NormalResult = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PathologyNonWordReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        ReportDate = c.DateTime(nullable: false),
                        ReportDoctor = c.Int(nullable: false),
                        ReportTechnologist = c.Int(nullable: false),
                        PrintBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PathologyNormalValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestDetailId = c.Int(nullable: false),
                        Age = c.Single(nullable: false),
                        lowerValue = c.String(),
                        upperValue = c.String(),
                        alarmingValue = c.String(),
                        ResultUnit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientLedger",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        DailyId = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.String(),
                        Sex = c.String(),
                        ContactNumber = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        EntryTime = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryTime = c.String(),
                        RefbyId = c.Int(nullable: false),
                        Cabin = c.String(),
                        DiscountCareOf = c.String(),
                        Status = c.String(),
                        Cancelledby = c.String(),
                        CancelledhostIp = c.String(),
                        Cancelledhostname = c.String(),
                        Isfree = c.Boolean(nullable: false),
                        Receivedby = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PractitionerWisePatientSerials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChamberPractitionerId = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        SerialDate = c.DateTime(nullable: false),
                        PatientName = c.String(),
                        MobileNo = c.String(),
                        Age = c.String(),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportConsultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fsize1 = c.Int(),
                        DIdentityLine1 = c.String(),
                        Fsize2 = c.Int(),
                        DIdentityLine2 = c.String(),
                        Fsize3 = c.Int(),
                        DIdentityLine3 = c.String(),
                        Fsize4 = c.Int(),
                        DIdentityLine4 = c.String(),
                        Fsize5 = c.Int(),
                        DIdentityLine5 = c.String(),
                        Fsize6 = c.Int(),
                        DIdentityLine6 = c.String(),
                        Fsize7 = c.Int(),
                        ConsultantGroup = c.String(),
                        ConsultantUserId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportDefinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        GroupTitle = c.String(),
                        TestId = c.Int(nullable: false),
                        TestTitle = c.String(),
                        NormalValue = c.String(),
                        ResultUnit = c.String(),
                        LowerLimit = c.Single(),
                        UpperLimit = c.Single(),
                        AgeVariant = c.Int(nullable: false),
                        DetailReportOrder = c.Int(nullable: false),
                        TestTitle_FontBold = c.Int(nullable: false),
                        TestTitle_FontItalic = c.Int(nullable: false),
                        TestTitle_FontUnderline = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportTechnologists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FSize1 = c.Int(),
                        Identity1 = c.String(),
                        FSize2 = c.Int(),
                        Identity2 = c.String(),
                        FSize3 = c.Int(),
                        Identity3 = c.String(),
                        FSize4 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportTypes",
                c => new
                    {
                        ReportTypeId = c.Int(nullable: false, identity: true),
                        TestGroupId = c.Int(nullable: false),
                        Report_Type = c.String(),
                        IsPathReport = c.Boolean(nullable: false),
                        IsImageReport = c.Boolean(nullable: false),
                        TestCarriedOutBy = c.String(),
                        ReportOrder = c.Int(nullable: false),
                        SCTokenOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ReportTypeId)
                .ForeignKey("dbo.TestGroups", t => t.TestGroupId, cascadeDelete: true)
                .Index(t => t.TestGroupId);
            
            CreateTable(
                "dbo.TestGroups",
                c => new
                    {
                        TestGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReportOrder = c.Int(nullable: false),
                        Type = c.String(),
                        SummaryGroup = c.String(),
                        TokenOrder = c.Int(),
                    })
                .PrimaryKey(t => t.TestGroupId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        FullName = c.String(),
                        MobileNo = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        RoleId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestItemDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        TestCriteria = c.String(),
                        NormalValues = c.String(),
                        ResultUnit = c.String(),
                        lowerLimit = c.Double(nullable: false),
                        upperLimit = c.Double(nullable: false),
                        alarmLimit = c.Double(nullable: false),
                        HasAgeVariant = c.Boolean(nullable: false),
                        Reportorder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestItems",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Double(nullable: false),
                        Specimen = c.String(),
                        Process_Time = c.String(),
                        Vatable = c.Boolean(nullable: false),
                        ReportTypeId = c.Int(nullable: false),
                        CollectionTypeId = c.Int(),
                        Label = c.Boolean(nullable: false),
                        Comments = c.String(),
                        ReportOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.TestsCost",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        ConsultantId = c.Int(nullable: false),
                        DeliveryStatus = c.String(),
                        Status = c.String(),
                        CancelledBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TubeMpping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(),
                        TestId = c.Int(),
                        TubeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Vat",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VatInPercent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole1",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole1", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.UserRole1", "User_Id", "dbo.User");
            DropForeignKey("dbo.ReportTypes", "TestGroupId", "dbo.TestGroups");
            DropIndex("dbo.UserRole1", new[] { "Role_Id" });
            DropIndex("dbo.UserRole1", new[] { "User_Id" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.ReportTypes", new[] { "TestGroupId" });
            DropTable("dbo.UserRole1");
            DropTable("dbo.Vat");
            DropTable("dbo.UserRole");
            DropTable("dbo.TubeMpping");
            DropTable("dbo.TestsCost");
            DropTable("dbo.TestItems");
            DropTable("dbo.TestItemDetails");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.TestGroups");
            DropTable("dbo.ReportTypes");
            DropTable("dbo.ReportTechnologists");
            DropTable("dbo.ReportDefinations");
            DropTable("dbo.ReportConsultants");
            DropTable("dbo.PractitionerWisePatientSerials");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientLedger");
            DropTable("dbo.PathologyNormalValues");
            DropTable("dbo.PathologyNonWordReports");
            DropTable("dbo.PathologyNonWordReportReportDetails");
            DropTable("dbo.PathologicalMachines");
            DropTable("dbo.ParentMenus");
            DropTable("dbo.Module");
            DropTable("dbo.ModulePermission");
            DropTable("dbo.GroupReportItems");
            DropTable("dbo.Expenses");
            DropTable("dbo.Doctor");
            DropTable("dbo.DailyStatement");
            DropTable("dbo.Consultants");
            DropTable("dbo.ChamberPractitioners");
            DropTable("dbo.AccountHeads");
        }
    }
}
