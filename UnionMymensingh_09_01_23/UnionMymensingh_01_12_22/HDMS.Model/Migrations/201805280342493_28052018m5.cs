namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuplierInfoes", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuplierInfoes", "Category");
        }
    }
}
