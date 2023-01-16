namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hp_opd_consultant_category_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpOPDConsultantCategories", "CpPercent", c => c.Double(nullable: false));
            AddColumn("dbo.HpOPDConsultantCategories", "HpPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpOPDConsultantCategories", "HpPercent");
            DropColumn("dbo.HpOPDConsultantCategories", "CpPercent");
        }
    }
}
