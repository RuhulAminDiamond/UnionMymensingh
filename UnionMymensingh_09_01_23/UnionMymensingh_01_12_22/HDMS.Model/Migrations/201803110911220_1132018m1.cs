namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1132018m1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PathologyNonWordReports", newName: "PathologyReports");
            //DropPrimaryKey("dbo.Doctor");
           //DropPrimaryKey("dbo.PathologyReports");
           // DropPrimaryKey("dbo.Patients");
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Trandate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Invdate = c.DateTime(nullable: false),
                        RegNo = c.Int(nullable: false),
                        AdmissionNo = c.Long(nullable: false),
                        RxId = c.Long(nullable: false),
                        TotalTK = c.Double(nullable: false),
                        DiscountTK = c.Double(nullable: false),
                        GrandTK = c.Double(nullable: false),
                        ReceivedTK = c.Double(nullable: false),
                        ChangeTK = c.Double(nullable: false),
                        DueTK = c.Double(nullable: false),
                        ReturnAdjustedTK = c.Double(nullable: false),
                        InvoiceNumber = c.String(),
                        ChallanNumber = c.String(),
                        ChallanAddress = c.String(),
                        InvoiceType = c.String(),
                        IsReturened = c.String(),
                        RRInvoice = c.Int(nullable: false),
                        ReturnedInvoiceNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParentGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Name = c.String(),
                        GroupId = c.Int(nullable: false),
                        Unit = c.String(),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        WholeSaleRate = c.Double(nullable: false),
                        ROL = c.Int(nullable: false),
                        QtyPerCartoonOrBox = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        TotalTk = c.Double(nullable: false),
                        DiscountTk = c.Double(nullable: false),
                        SupplerId = c.Int(nullable: false),
                        SChallanNo = c.String(),
                        SInvoiceNo = c.String(),
                        SInvoiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceiveDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceivedId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReturnInvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnInvoice = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ReturnQty = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReturnInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnDate = c.DateTime(nullable: false),
                        SoldInvoice = c.Int(nullable: false),
                        ReturnAmount = c.Double(nullable: false),
                        AdjustableAmount = c.Double(nullable: false),
                        ReturnBy = c.String(),
                        IsAdjusted = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxDiagnosis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RxId = c.Long(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxDosages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RxId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        dosage = c.String(),
                        duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxPatientInfoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RxDate = c.DateTime(nullable: false),
                        RegNo = c.Long(nullable: false),
                        AgeYear = c.String(),
                        AgeMonth = c.String(),
                        AgeDay = c.String(),
                        RxDoctorId = c.Int(nullable: false),
                        ChiefComplain = c.String(),
                        OnExamination = c.String(),
                        Diagnosis = c.String(),
                        Advices = c.String(),
                        OperateBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplierLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        Trandate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Supplierid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Suppliername = c.String(),
                        Address = c.String(),
                        Contactno = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Supplierid);
            
            CreateTable(
                "dbo.Symtomps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Doctor", "DoctorId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Doctor", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.PathologyReports", "ReportType", c => c.String());
            AddColumn("dbo.Patients", "PatientId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Patients", "RxId", c => c.Long(nullable: false));
            AddColumn("dbo.Patients", "AdmissionNo", c => c.Long(nullable: false));
            AddColumn("dbo.Patients", "AgeYear", c => c.String());
            AddColumn("dbo.Patients", "AgeMonth", c => c.String());
            AddColumn("dbo.Patients", "AgeDay", c => c.String());
            AddColumn("dbo.TestsCost", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.PathologyNonWordReportReportDetails", "ReportId", c => c.Long(nullable: false));
            AlterColumn("dbo.PathologyReports", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PathologyReports", "PatientId", c => c.Long(nullable: false));
            AlterColumn("dbo.PatientLedger", "PatientId", c => c.Long(nullable: false));
            AlterColumn("dbo.Patients", "RegNo", c => c.Long(nullable: false));
            AlterColumn("dbo.TestsCost", "PatientId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Doctor", "DoctorId");
            AddPrimaryKey("dbo.PathologyReports", "Id");
            AddPrimaryKey("dbo.Patients", "PatientId");
            CreateIndex("dbo.TestsCost", "PatientId");
            AddForeignKey("dbo.TestsCost", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
            DropColumn("dbo.Doctor", "Id");
            DropColumn("dbo.PathologyReports", "PrintBy");
            //DropColumn("dbo.Patients", "Id");
            //DropColumn("dbo.Patients", "Name");
            //DropColumn("dbo.Patients", "Age");
            //DropColumn("dbo.Patients", "Sex");
            DropColumn("dbo.Patients", "ContactNumber");
            DropColumn("dbo.TestsCost", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestsCost", "ItemId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "ContactNumber", c => c.String());
            AddColumn("dbo.Patients", "Sex", c => c.String());
            AddColumn("dbo.Patients", "Age", c => c.String());
            AddColumn("dbo.Patients", "Name", c => c.String());
            AddColumn("dbo.Patients", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PathologyReports", "PrintBy", c => c.String());
            AddColumn("dbo.Doctor", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TestsCost", "PatientId", "dbo.Patients");
            DropIndex("dbo.TestsCost", new[] { "PatientId" });
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.PathologyReports");
            DropPrimaryKey("dbo.Doctor");
            AlterColumn("dbo.TestsCost", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "RegNo", c => c.String());
            AlterColumn("dbo.PatientLedger", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.PathologyReports", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.PathologyReports", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PathologyNonWordReportReportDetails", "ReportId", c => c.Int(nullable: false));
            DropColumn("dbo.TestsCost", "TestId");
            DropColumn("dbo.Patients", "AgeDay");
            DropColumn("dbo.Patients", "AgeMonth");
            DropColumn("dbo.Patients", "AgeYear");
            DropColumn("dbo.Patients", "AdmissionNo");
            DropColumn("dbo.Patients", "RxId");
            DropColumn("dbo.Patients", "PatientId");
            DropColumn("dbo.PathologyReports", "ReportType");
            DropColumn("dbo.Doctor", "UserId");
            DropColumn("dbo.Doctor", "DoctorId");
            DropTable("dbo.Symtomps");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierLedgers");
            DropTable("dbo.RxPatientInfoes");
            DropTable("dbo.RxDurations");
            DropTable("dbo.RxDrugs");
            DropTable("dbo.RxDosages");
            DropTable("dbo.RxDiagnosis");
            DropTable("dbo.ReturnInvoices");
            DropTable("dbo.ReturnInvoiceDetails");
            DropTable("dbo.ReceiveDetails");
            DropTable("dbo.Receives");
            DropTable("dbo.ProductInfoes");
            DropTable("dbo.ParentGroups");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Groups");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerLedgers");
            DropTable("dbo.Companies");
            AddPrimaryKey("dbo.Patients", "Id");
            AddPrimaryKey("dbo.PathologyReports", "Id");
            AddPrimaryKey("dbo.Doctor", "Id");
            RenameTable(name: "dbo.PathologyReports", newName: "PathologyNonWordReports");
        }
    }
}
