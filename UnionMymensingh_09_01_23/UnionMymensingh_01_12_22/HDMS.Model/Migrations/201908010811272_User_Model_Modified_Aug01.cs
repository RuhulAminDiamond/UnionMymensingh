namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Model_Modified_Aug01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "DeptId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "DeptId");
        }
    }
}
