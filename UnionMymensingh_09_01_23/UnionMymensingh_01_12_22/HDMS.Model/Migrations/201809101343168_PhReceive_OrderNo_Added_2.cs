namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReceive_OrderNo_Added_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhReceives", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhReceives", "OrderId", c => c.Int());
        }
    }
}
