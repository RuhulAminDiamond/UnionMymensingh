namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sept23_Transactiontime_added_with_ledgers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpConsultantLedgers", "TransactionTime", c => c.String());
            AddColumn("dbo.HpPatientLedgerFinals", "TransactionTime", c => c.String());
            AddColumn("dbo.HpPatientLedgerRoughs", "TransactionTime", c => c.String());
            AddColumn("dbo.PatientLedger", "TransactionTime", c => c.String());
            AddColumn("dbo.PhSaleLedgers", "TransactionTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhSaleLedgers", "TransactionTime");
            DropColumn("dbo.PatientLedger", "TransactionTime");
            DropColumn("dbo.HpPatientLedgerRoughs", "TransactionTime");
            DropColumn("dbo.HpPatientLedgerFinals", "TransactionTime");
            DropColumn("dbo.HpConsultantLedgers", "TransactionTime");
        }
    }
}
