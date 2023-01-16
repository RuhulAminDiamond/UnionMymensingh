namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15032018m2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRole1", newName: "RoleUsers");
            DropPrimaryKey("dbo.RoleUsers");
            AddColumn("dbo.TestsCost", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RoleUsers", new[] { "Role_RoleId", "User_UserId" });
            CreateIndex("dbo.TestsCost", "TestId");
            CreateIndex("dbo.TestsCost", "UserId");
            AddForeignKey("dbo.TestsCost", "TestId", "dbo.TestItems", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.TestsCost", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropColumn("dbo.TestsCost", "OperatorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestsCost", "OperatorName", c => c.String());
            DropForeignKey("dbo.TestsCost", "UserId", "dbo.User");
            DropForeignKey("dbo.TestsCost", "TestId", "dbo.TestItems");
            DropIndex("dbo.TestsCost", new[] { "UserId" });
            DropIndex("dbo.TestsCost", new[] { "TestId" });
            DropPrimaryKey("dbo.RoleUsers");
            DropColumn("dbo.TestsCost", "UserId");
            AddPrimaryKey("dbo.RoleUsers", new[] { "User_UserId", "Role_RoleId" });
            RenameTable(name: "dbo.RoleUsers", newName: "UserRole1");
        }
    }
}
