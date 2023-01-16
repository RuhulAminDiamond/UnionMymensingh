namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpPatientLedgerFinals",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.TranId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpPatientLedgerFinals");
        }
    }
}
