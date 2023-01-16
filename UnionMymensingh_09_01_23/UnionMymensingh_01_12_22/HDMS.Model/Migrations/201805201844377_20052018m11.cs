namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20052018m11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "Qty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestsCost", "Qty");
        }
    }
}
