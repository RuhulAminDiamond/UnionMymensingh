namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sept06_ServiceHead_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDServiceHeads", "ServiceCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPDServiceHeads", "ServiceCode");
        }
    }
}
