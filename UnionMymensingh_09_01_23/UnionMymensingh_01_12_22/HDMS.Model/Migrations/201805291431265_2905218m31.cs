namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2905218m31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSubGroups", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceSubGroups", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.ServiceSubGroups", "Modifieddate", c => c.DateTime());
            CreateIndex("dbo.ServiceSubGroups", "GroupId");
            //AddForeignKey("dbo.ServiceSubGroups", "GroupId", "dbo.ServiceGroups", "GroupId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceSubGroups", "GroupId", "dbo.ServiceGroups");
            DropIndex("dbo.ServiceSubGroups", new[] { "GroupId" });
            AlterColumn("dbo.ServiceSubGroups", "Modifieddate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ServiceSubGroups", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ServiceSubGroups", "GroupId");
        }
    }
}
