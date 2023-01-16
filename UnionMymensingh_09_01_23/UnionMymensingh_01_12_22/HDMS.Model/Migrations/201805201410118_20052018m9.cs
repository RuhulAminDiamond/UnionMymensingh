namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20052018m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "DeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TestsCost", "DeliveryTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestsCost", "DeliveryTime");
            DropColumn("dbo.TestsCost", "DeliveryDate");
        }
    }
}
