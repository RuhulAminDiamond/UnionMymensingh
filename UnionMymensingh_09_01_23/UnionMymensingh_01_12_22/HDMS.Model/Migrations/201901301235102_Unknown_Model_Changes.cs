namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unknown_Model_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpCabinCharges", "CabinId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpCabinCharges", "CabinId");
        }
    }
}
