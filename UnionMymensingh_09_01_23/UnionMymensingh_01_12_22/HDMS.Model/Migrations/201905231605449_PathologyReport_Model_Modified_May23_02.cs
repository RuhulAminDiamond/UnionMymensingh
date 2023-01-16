namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PathologyReport_Model_Modified_May23_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PathologyReports", "AnyComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PathologyReports", "AnyComments");
        }
    }
}
