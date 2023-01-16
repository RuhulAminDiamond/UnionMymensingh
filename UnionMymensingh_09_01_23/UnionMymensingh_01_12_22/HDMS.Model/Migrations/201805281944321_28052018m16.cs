namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WardInfoes", "Rent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WardInfoes", "Rent", c => c.Double(nullable: false));
        }
    }
}
