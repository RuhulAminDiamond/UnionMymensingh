namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Store_Indent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreRequisitionDetails",
                c => new
                    {
                        RDId = c.Long(nullable: false, identity: true),
                        RequisitionId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RDId)
                .ForeignKey("dbo.StoreRequisitions", t => t.RequisitionId, cascadeDelete: true)
                .Index(t => t.RequisitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreRequisitionDetails", "RequisitionId", "dbo.StoreRequisitions");
            DropIndex("dbo.StoreRequisitionDetails", new[] { "RequisitionId" });
            DropTable("dbo.StoreRequisitionDetails");
        }
    }
}
