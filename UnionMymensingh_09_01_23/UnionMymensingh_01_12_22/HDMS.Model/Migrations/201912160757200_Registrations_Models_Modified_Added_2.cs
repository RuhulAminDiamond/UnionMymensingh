namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registrations_Models_Modified_Added_2 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.CorporateClients");
            AddColumn("dbo.CorporateClients", "CompanyId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RegDiscountPlans", "CompanyId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CorporateClients", "CompanyId");
            DropColumn("dbo.CorporateClients", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CorporateClients", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CorporateClients");
            DropColumn("dbo.RegDiscountPlans", "CompanyId");
            DropColumn("dbo.CorporateClients", "CompanyId");
            AddPrimaryKey("dbo.CorporateClients", "Id");
        }
    }
}
