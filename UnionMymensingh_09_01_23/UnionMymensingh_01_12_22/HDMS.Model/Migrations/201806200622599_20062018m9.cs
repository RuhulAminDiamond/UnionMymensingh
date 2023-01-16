namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpAdvancePayments",
                c => new
                    {
                        AdvanceId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        AdvanceDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AdvanceId);
            
            DropColumn("dbo.HpPatientLedgerFinals", "HpBillingItemType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpPatientLedgerFinals", "HpBillingItemType", c => c.String());
            DropTable("dbo.HpAdvancePayments");
        }
    }
}
