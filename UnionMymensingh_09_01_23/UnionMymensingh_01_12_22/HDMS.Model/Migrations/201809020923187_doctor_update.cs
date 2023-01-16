namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctor_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "IsOPDConsultant", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctor", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "OPDConsultantCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "ConsultancyFee", c => c.Double(nullable: false));
            AddColumn("dbo.Doctor", "HpPercent", c => c.Double(nullable: false));
            AddColumn("dbo.Doctor", "CpPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "CpPercent");
            DropColumn("dbo.Doctor", "HpPercent");
            DropColumn("dbo.Doctor", "ConsultancyFee");
            DropColumn("dbo.Doctor", "OPDConsultantCategoryId");
            DropColumn("dbo.Doctor", "DeptId");
            DropColumn("dbo.Doctor", "IsOPDConsultant");
        }
    }
}
