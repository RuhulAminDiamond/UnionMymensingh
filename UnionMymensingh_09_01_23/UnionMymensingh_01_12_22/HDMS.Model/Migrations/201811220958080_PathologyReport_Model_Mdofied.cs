namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PathologyReport_Model_Mdofied : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PathologyReports", "PreparedBy", c => c.String());
            AddColumn("dbo.PathologyReports", "ModifiedBy", c => c.String());
            AddColumn("dbo.PathologyReports", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.PathologyReports", "ModifiedTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PathologyReports", "ModifiedTime");
            DropColumn("dbo.PathologyReports", "ModifiedDate");
            DropColumn("dbo.PathologyReports", "ModifiedBy");
            DropColumn("dbo.PathologyReports", "PreparedBy");
        }
    }
}
