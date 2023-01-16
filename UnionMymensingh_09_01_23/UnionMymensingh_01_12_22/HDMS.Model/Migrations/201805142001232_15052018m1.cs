namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15052018m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessUnits",
                c => new
                    {
                        BusinessUnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrgId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessUnitId)
                .ForeignKey("dbo.OrganizationInfoes", t => t.OrgId, cascadeDelete: true)
                .Index(t => t.OrgId);
            
            CreateTable(
                "dbo.OrganizationInfoes",
                c => new
                    {
                        OrgId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrgId)
                .ForeignKey("dbo.CompanyInfoes", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyInfoes",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            AddColumn("dbo.Departments", "BusinessUnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "BusinessUnitId");
            AddForeignKey("dbo.Departments", "BusinessUnitId", "dbo.BusinessUnits", "BusinessUnitId", cascadeDelete: true);
            DropTable("dbo.Companies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Departments", "BusinessUnitId", "dbo.BusinessUnits");
            DropForeignKey("dbo.BusinessUnits", "OrgId", "dbo.OrganizationInfoes");
            DropForeignKey("dbo.OrganizationInfoes", "CompanyId", "dbo.CompanyInfoes");
            DropIndex("dbo.Departments", new[] { "BusinessUnitId" });
            DropIndex("dbo.OrganizationInfoes", new[] { "CompanyId" });
            DropIndex("dbo.BusinessUnits", new[] { "OrgId" });
            DropColumn("dbo.Departments", "BusinessUnitId");
            DropTable("dbo.CompanyInfoes");
            DropTable("dbo.OrganizationInfoes");
            DropTable("dbo.BusinessUnits");
        }
    }
}
