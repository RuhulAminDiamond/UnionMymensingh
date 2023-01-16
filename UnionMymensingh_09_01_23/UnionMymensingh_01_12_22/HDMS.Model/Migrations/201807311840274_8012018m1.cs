namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8012018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpConsultantLedgers", "PaymentEntryTime", c => c.String());
            DropColumn("dbo.HpConsultantLedgers", "EntryTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpConsultantLedgers", "EntryTime", c => c.String());
            DropColumn("dbo.HpConsultantLedgers", "PaymentEntryTime");
        }
    }
}
