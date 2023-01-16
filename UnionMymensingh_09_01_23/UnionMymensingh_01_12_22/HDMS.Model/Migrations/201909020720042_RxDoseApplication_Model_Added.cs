namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxDoseApplication_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxDoseApplications",
                c => new
                    {
                        DAppId = c.Int(nullable: false, identity: true),
                        DoseApplyRole = c.String(),
                        IsBanglaFont = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DAppId);
            
            AddColumn("dbo.RxDurations", "IsBanglaFont", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxDurations", "IsBanglaFont");
            DropTable("dbo.RxDoseApplications");
        }
    }
}
