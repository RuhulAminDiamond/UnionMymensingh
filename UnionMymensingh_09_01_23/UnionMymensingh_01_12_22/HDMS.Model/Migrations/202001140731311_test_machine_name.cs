namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_machine_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PathologyReports", "TestCarriedOutby", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PathologyReports", "TestCarriedOutby");
        }
    }
}
