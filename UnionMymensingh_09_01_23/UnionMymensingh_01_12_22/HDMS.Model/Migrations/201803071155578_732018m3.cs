namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _732018m3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Role", "User_UserId", "dbo.User");
            DropIndex("dbo.Role", new[] { "User_UserId" });
            CreateTable(
                "dbo.UserRole1",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
            DropColumn("dbo.Role", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "User_UserId", c => c.Int());
            DropForeignKey("dbo.UserRole1", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole1", "User_UserId", "dbo.User");
            DropIndex("dbo.UserRole1", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRole1", new[] { "User_UserId" });
            DropTable("dbo.UserRole1");
            CreateIndex("dbo.Role", "User_UserId");
            AddForeignKey("dbo.Role", "User_UserId", "dbo.User", "UserId");
        }
    }
}
