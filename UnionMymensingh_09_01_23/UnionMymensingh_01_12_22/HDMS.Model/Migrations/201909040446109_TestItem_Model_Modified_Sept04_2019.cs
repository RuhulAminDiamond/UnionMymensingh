namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestItem_Model_Modified_Sept04_2019 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TestItems", "GLUResultExtension");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestItems", "GLUResultExtension", c => c.String());
        }
    }
}
