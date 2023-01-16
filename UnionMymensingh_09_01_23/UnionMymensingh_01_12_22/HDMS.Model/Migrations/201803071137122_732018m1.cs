namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _732018m1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole1", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserRole1", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropIndex("dbo.UserRole1", new[] { "User_Id" });
            DropIndex("dbo.UserRole1", new[] { "Role_Id" });
            DropPrimaryKey("dbo.Role");
          //  DropPrimaryKey("dbo.User");
            AddColumn("dbo.Role", "RoleId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.User", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Role", "RoleId");
            AddPrimaryKey("dbo.User", "UserId");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropColumn("dbo.Role", "Id");
            DropColumn("dbo.User", "Id");
            DropColumn("dbo.User", "RoleId");
            DropTable("dbo.UserRole1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRole1",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id });
            
            AddColumn("dbo.User", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Role", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Role");
            DropColumn("dbo.User", "UserId");
            DropColumn("dbo.Role", "RoleId");
            AddPrimaryKey("dbo.User", "Id");
            AddPrimaryKey("dbo.Role", "Id");
            CreateIndex("dbo.UserRole1", "Role_Id");
            CreateIndex("dbo.UserRole1", "User_Id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole1", "Role_Id", "dbo.Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole1", "User_Id", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
