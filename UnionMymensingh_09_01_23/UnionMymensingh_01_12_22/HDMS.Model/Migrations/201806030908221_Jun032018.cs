namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jun032018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceives", "Receivedby", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReceives", "Receivedby");
        }
    }
}
