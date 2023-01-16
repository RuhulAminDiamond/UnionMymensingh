namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31072018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpConsultantLedgers", "PaymentTransactionNo", c => c.Long(nullable: false));
            AddColumn("dbo.HpConsultantLedgers", "EntryTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpConsultantLedgers", "EntryTime");
            DropColumn("dbo.HpConsultantLedgers", "PaymentTransactionNo");
        }
    }
}
