namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductGroup_Model_Modified_March09_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductGroups", "Info", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductGroups", "Info");
        }
    }
}
