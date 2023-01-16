namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxDosage_Model_Modified_Jun05_2020_05 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RxDosages", "CpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxDosages", "CpId", c => c.Int(nullable: false));
        }
    }
}
