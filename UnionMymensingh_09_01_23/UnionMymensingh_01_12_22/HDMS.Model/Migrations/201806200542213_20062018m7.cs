namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpPatientLedgerFinals", "HpBillingItemType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpPatientLedgerFinals", "HpBillingItemType");
        }
    }
}
