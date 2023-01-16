namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Module_Model_Modified_Active_InActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Module", "IsActive", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Module", "IsActive");
        }
    }
}
