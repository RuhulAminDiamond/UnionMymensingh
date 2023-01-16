namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _832017m1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ModulePermission", "ModuleId");
            AddForeignKey("dbo.ModulePermission", "ModuleId", "dbo.Module", "ModuleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModulePermission", "ModuleId", "dbo.Module");
            DropIndex("dbo.ModulePermission", new[] { "ModuleId" });
        }
    }
}
