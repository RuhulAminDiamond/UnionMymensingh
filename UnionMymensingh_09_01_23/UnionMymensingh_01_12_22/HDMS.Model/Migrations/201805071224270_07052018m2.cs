namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07052018m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReferralCategories",
                c => new
                    {
                        RefCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RefCategoryId);
            
            AddColumn("dbo.Doctor", "RefCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctor", "RefCategoryId");
            AddForeignKey("dbo.Doctor", "RefCategoryId", "dbo.ReferralCategories", "RefCategoryId", cascadeDelete: true);
            DropColumn("dbo.Doctor", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctor", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Doctor", "RefCategoryId", "dbo.ReferralCategories");
            DropIndex("dbo.Doctor", new[] { "RefCategoryId" });
            DropColumn("dbo.Doctor", "RefCategoryId");
            DropTable("dbo.ReferralCategories");
        }
    }
}
