namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhAudit_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhStockAuditMasterDetails",
                c => new
                    {
                        AMDId = c.Long(nullable: false, identity: true),
                        AMId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SoftWareStock = c.Int(nullable: false),
                        PhysicalStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AMDId);
            
            CreateTable(
                "dbo.PhStockAuditMasters",
                c => new
                    {
                        AMId = c.Long(nullable: false, identity: true),
                        AMonth = c.String(),
                        AYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AMId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhStockAuditMasters");
            DropTable("dbo.PhStockAuditMasterDetails");
        }
    }
}
