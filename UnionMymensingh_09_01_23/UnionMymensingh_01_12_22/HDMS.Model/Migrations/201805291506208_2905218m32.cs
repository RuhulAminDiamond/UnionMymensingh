namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2905218m32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceHeads", "GroupId", "dbo.ServiceGroups");
            DropIndex("dbo.ServiceHeads", new[] { "GroupId" });
            DropColumn("dbo.ServiceHeads", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceHeads", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceHeads", "GroupId");
            AddForeignKey("dbo.ServiceHeads", "GroupId", "dbo.ServiceGroups", "GroupId", cascadeDelete: true);
        }
    }
}
