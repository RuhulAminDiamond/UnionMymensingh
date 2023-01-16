namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpPkgSubItem_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpPkgSubItems", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.HpPkgSubItems", "ServiceId");
            AddForeignKey("dbo.HpPkgSubItems", "ServiceId", "dbo.ServiceHeads", "ServiceHeadId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpPkgSubItems", "ServiceId", "dbo.ServiceHeads");
            DropIndex("dbo.HpPkgSubItems", new[] { "ServiceId" });
            DropColumn("dbo.HpPkgSubItems", "ServiceId");
        }
    }
}
