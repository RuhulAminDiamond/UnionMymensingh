namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportDefination_model_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportDefinations", "IsKeyValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportDefinations", "IsKeyValue");
        }
    }
}
