namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecord_Model_Modified_Feb08_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "LocalGurdianUpazilaOrAreaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "LocalGurdianUpazilaOrAreaId");
        }
    }
}
