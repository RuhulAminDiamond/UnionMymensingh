namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_Patient_Ledger_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDPatientLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OPDPatientLedgers");
        }
    }
}
