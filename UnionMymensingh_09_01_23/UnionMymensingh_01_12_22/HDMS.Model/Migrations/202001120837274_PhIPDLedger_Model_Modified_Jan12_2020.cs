namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhIPDLedger_Model_Modified_Jan12_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhIPDSaleLedgers", "InvoiceIdGeneratedOnReturn", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhIPDSaleLedgers", "InvoiceIdGeneratedOnReturn");
        }
    }
}
