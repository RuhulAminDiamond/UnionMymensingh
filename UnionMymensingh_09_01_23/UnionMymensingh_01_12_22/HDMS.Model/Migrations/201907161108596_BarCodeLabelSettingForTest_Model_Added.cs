namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BarCodeLabelSettingForTest_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarCodeLabelSettingForTests",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        BarcodeLabel = c.String(),
                    })
                .PrimaryKey(t => t.SettingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BarCodeLabelSettingForTests");
        }
    }
}
