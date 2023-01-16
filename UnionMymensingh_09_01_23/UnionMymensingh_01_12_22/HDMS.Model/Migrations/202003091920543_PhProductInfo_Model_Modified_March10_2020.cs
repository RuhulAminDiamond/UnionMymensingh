namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductInfo_Model_Modified_March10_2020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhSubGroups", "GroupId", "dbo.PhProductGroups");
            DropForeignKey("dbo.PhProductInfoes", "SubGroupId", "dbo.PhSubGroups");
            DropIndex("dbo.PhProductInfoes", new[] { "SubGroupId" });
            DropIndex("dbo.PhSubGroups", new[] { "GroupId" });
            DropColumn("dbo.PhProductInfoes", "SubGroupId");
            DropTable("dbo.PhSubGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhSubGroups",
                c => new
                    {
                        SubGroupId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubGroupId);
            
            AddColumn("dbo.PhProductInfoes", "SubGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhSubGroups", "GroupId");
            CreateIndex("dbo.PhProductInfoes", "SubGroupId");
            AddForeignKey("dbo.PhProductInfoes", "SubGroupId", "dbo.PhSubGroups", "SubGroupId", cascadeDelete: true);
            AddForeignKey("dbo.PhSubGroups", "GroupId", "dbo.PhProductGroups", "GroupId", cascadeDelete: true);
        }
    }
}
