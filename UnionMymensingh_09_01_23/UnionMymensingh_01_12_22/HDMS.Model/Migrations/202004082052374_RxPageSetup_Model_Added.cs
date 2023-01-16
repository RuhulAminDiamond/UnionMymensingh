namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPageSetup_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxCPPrintPageSetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        PageType = c.String(),
                        TopMargin = c.Double(nullable: false),
                        RightMargin = c.Double(nullable: false),
                        BottomMargin = c.Double(nullable: false),
                        LeftMargin = c.Double(nullable: false),
                        footerText = c.String(),
                        headretext = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RxCPPrintPageSetups");
        }
    }
}
