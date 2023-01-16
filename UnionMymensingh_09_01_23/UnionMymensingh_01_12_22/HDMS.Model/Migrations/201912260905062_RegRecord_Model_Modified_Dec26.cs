namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecord_Model_Modified_Dec26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "DesignationId", c => c.Int(nullable: false));
            DropColumn("dbo.RegRecords", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegRecords", "Designation", c => c.String());
            DropColumn("dbo.RegRecords", "DesignationId");
        }
    }
}
