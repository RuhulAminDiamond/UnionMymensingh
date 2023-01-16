namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecord_Model_Modifed_Feb09_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "CareOf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "CareOf");
        }
    }
}
