namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReceive_OrderNo_Added_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhOrderDetails", "OrderId", "dbo.PhOrders");
            DropIndex("dbo.PhOrderDetails", new[] { "OrderId" });
            //DropPrimaryKey("dbo.PhOrders");
            AlterColumn("dbo.PhOrderDetails", "OrderId", c => c.Long(nullable: false));
            AlterColumn("dbo.PhOrders", "OrderId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PhReceives", "OrderId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.PhOrders", "OrderId");
            CreateIndex("dbo.PhOrderDetails", "OrderId");
            AddForeignKey("dbo.PhOrderDetails", "OrderId", "dbo.PhOrders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhOrderDetails", "OrderId", "dbo.PhOrders");
            DropIndex("dbo.PhOrderDetails", new[] { "OrderId" });
            DropPrimaryKey("dbo.PhOrders");
            AlterColumn("dbo.PhReceives", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhOrders", "OrderId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PhOrderDetails", "OrderId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PhOrders", "OrderId");
            CreateIndex("dbo.PhOrderDetails", "OrderId");
            AddForeignKey("dbo.PhOrderDetails", "OrderId", "dbo.PhOrders", "OrderId", cascadeDelete: true);
        }
    }
}
