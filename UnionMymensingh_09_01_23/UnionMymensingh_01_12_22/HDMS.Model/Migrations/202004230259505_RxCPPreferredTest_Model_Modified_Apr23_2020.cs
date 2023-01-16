namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCPPreferredTest_Model_Modified_Apr23_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCPPreferredTests", "TestGroupId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxCPPreferredTests", "TestGroupId");
        }
    }
}
