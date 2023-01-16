namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecord_Model_Modified_March_15_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "RefdId", c => c.Int(nullable: false));
            AddColumn("dbo.RegRecords", "RegDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RegRecords", "IsRegisterd", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "IsRegisterd");
            DropColumn("dbo.RegRecords", "RegDate");
            DropColumn("dbo.RegRecords", "RefdId");
        }
    }
}
