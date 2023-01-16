namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25072018_m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "ContraIndication", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductInfoes", "ContraIndication");
        }
    }
}
