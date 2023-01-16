namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecord_Model_Modified_Feb11_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "Referredby", c => c.Int(nullable: false));
            AddColumn("dbo.RegRecords", "CpId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "CpId");
            DropColumn("dbo.RegRecords", "Referredby");
        }
    }
}
