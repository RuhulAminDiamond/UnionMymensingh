namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestItem_Model_Modified_Sept04_2019_01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestItems", "IsGLUTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.TestItems", "GLUIdentityExt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestItems", "GLUIdentityExt");
            DropColumn("dbo.TestItems", "IsGLUTest");
        }
    }
}
