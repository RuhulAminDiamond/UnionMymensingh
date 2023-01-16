namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sept06_updatde : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDServiceCosts", "Rate", c => c.Double(nullable: false));
            AddColumn("dbo.OPDServiceCosts", "TAmount", c => c.Double(nullable: false));
            AddColumn("dbo.TestItems", "MediaComm", c => c.Double(nullable: false));
            DropColumn("dbo.OPDServiceCosts", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPDServiceCosts", "Cost", c => c.Double(nullable: false));
            DropColumn("dbo.TestItems", "MediaComm");
            DropColumn("dbo.OPDServiceCosts", "TAmount");
            DropColumn("dbo.OPDServiceCosts", "Rate");
        }
    }
}
