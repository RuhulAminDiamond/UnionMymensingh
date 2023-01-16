namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06072018m333 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpServiceBills",
                c => new
                    {
                        SBId = c.Long(nullable: false, identity: true),
                        SDate = c.DateTime(nullable: false),
                        ServiceAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SBId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpServiceBills");
        }
    }
}
