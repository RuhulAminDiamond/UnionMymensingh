namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxDosage_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxDosages", "CpId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxDosages", "CpId");
        }
    }
}
