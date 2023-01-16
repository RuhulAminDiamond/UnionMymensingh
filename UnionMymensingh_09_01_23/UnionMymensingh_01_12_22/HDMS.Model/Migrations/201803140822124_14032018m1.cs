namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14032018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Updateby", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Updateby");
        }
    }
}
