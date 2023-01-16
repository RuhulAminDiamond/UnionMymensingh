namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sep16_MemberLedger_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TranId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberLedgers");
        }
    }
}
