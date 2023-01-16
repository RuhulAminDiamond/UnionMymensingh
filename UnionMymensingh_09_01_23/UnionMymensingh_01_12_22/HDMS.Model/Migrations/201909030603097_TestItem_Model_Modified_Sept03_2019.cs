namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestItem_Model_Modified_Sept03_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestItems", "GLUResultExtension", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestItems", "GLUResultExtension");
        }
    }
}
