namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Model_Modified_for_RxChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "IsRxShortDoseDescriptionPreferred");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "IsRxShortDoseDescriptionPreferred", c => c.Boolean(nullable: false));
        }
    }
}
