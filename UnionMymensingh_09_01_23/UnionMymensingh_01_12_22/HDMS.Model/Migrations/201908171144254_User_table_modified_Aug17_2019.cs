namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_table_modified_Aug17_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsIndoorSaleAllowed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsIndoorSaleAllowed");
        }
    }
}
