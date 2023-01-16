namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barcodelabelsettings_mofifed_july28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarCodeLabelSettingForTests", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BarCodeLabelSettingForTests", "CategoryId");
        }
    }
}
