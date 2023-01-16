namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hp_opd_consultant_category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpOPDConsultantCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpOPDConsultantCategories");
        }
    }
}
