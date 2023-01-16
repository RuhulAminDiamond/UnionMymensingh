namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReceive_OrderNo_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceives", "OrderId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReceives", "OrderId");
        }
    }
}
