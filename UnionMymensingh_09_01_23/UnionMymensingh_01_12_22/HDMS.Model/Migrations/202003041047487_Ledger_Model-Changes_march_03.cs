namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ledger_ModelChanges_march_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Formations", "ShortFormation", c => c.String());
            AddColumn("dbo.HpPatientLedgerFinals", "TransactionTerminal", c => c.String());
            AddColumn("dbo.HpPatientLedgerRoughs", "TransactionTerminal", c => c.String());
            AddColumn("dbo.PatientLedger", "TransactionTerminal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientLedger", "TransactionTerminal");
            DropColumn("dbo.HpPatientLedgerRoughs", "TransactionTerminal");
            DropColumn("dbo.HpPatientLedgerFinals", "TransactionTerminal");
            DropColumn("dbo.Formations", "ShortFormation");
        }
    }
}
