namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registrations_Models_Modified_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CorporateClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhTempIPDLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        RetIndentId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        TransactionTime = c.String(),
                        AdmissionId = c.Long(nullable: false),
                        ReturnAmount = c.Double(nullable: false),
                        DiscountAdjusted = c.Double(nullable: false),
                        Returnable = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TranId);
            
            CreateTable(
                "dbo.RegDesignations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.RegDiscountPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationId = c.Int(nullable: false),
                        LabDiscount = c.Double(nullable: false),
                        NonLabDiscount = c.Double(nullable: false),
                        IPDBedDiscount = c.Double(nullable: false),
                        IPDServiceChargeDiscount = c.Double(nullable: false),
                        ICU_CCU_Discount = c.Double(nullable: false),
                        OPDDiscount = c.Double(nullable: false),
                        OthersDiscount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RegRecords", "PresentAddress", c => c.String());
            AddColumn("dbo.RegRecords", "PermanentAddress", c => c.String());
            AddColumn("dbo.RegRecords", "Status", c => c.String());
            AddColumn("dbo.RegRecords", "Designation", c => c.String());
            AddColumn("dbo.RegRecords", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.RegRecords", "Others", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "Others");
            DropColumn("dbo.RegRecords", "CompanyId");
            DropColumn("dbo.RegRecords", "Designation");
            DropColumn("dbo.RegRecords", "Status");
            DropColumn("dbo.RegRecords", "PermanentAddress");
            DropColumn("dbo.RegRecords", "PresentAddress");
            DropTable("dbo.RegStatus");
            DropTable("dbo.RegDiscountPlans");
            DropTable("dbo.RegDesignations");
            DropTable("dbo.PhTempIPDLedgers");
            DropTable("dbo.CorporateClients");
        }
    }
}
