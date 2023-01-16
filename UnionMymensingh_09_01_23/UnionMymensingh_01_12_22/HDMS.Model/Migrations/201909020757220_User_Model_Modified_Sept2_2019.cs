namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Model_Modified_Sept2_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsRxShortDoseDescriptionPreferred", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxDosages", "IsBanglaFont", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxDosages", "IsBanglaFont");
            DropColumn("dbo.User", "IsRxShortDoseDescriptionPreferred");
        }
    }
}
