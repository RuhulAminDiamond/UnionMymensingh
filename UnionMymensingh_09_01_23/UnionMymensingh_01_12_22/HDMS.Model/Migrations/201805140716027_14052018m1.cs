namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14052018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "ActivityNote", c => c.String());
            AddColumn("dbo.Departments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Status");
            DropColumn("dbo.Departments", "ActivityNote");
        }
    }
}
