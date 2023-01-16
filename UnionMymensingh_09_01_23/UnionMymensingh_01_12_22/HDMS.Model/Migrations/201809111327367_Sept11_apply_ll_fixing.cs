namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sept11_apply_ll_fixing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuplierInfoes", "ManufacturerId", c => c.Int(nullable: false));
            DropColumn("dbo.PhProductInfoes", "ProductCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhProductInfoes", "ProductCode", c => c.String());
            DropColumn("dbo.SuplierInfoes", "ManufacturerId");
        }
    }
}
