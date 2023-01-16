namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16052018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrganizationInfoes", "ShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrganizationInfoes", "ShortName");
        }
    }
}
