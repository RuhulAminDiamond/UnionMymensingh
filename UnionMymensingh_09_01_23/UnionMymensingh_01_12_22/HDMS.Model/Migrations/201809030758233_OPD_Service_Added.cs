namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_Service_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDServiceGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Createdby = c.String(),
                        modifiedby = c.String(),
                        Modifieddate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.OPDServiceHeads",
                c => new
                    {
                        ServiceHeadId = c.Int(nullable: false, identity: true),
                        SubGroupId = c.Int(nullable: false),
                        ServiceHeadName = c.String(),
                        Rate = c.Double(nullable: false),
                        Unit = c.String(),
                        Vat = c.Boolean(nullable: false),
                        ServiceCharge = c.Boolean(nullable: false),
                        DocVisit = c.Boolean(nullable: false),
                        Show = c.Boolean(nullable: false),
                        OpdShow = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        Createdby = c.String(),
                        modifiedby = c.String(),
                        Modifieddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ServiceHeadId)
                .ForeignKey("dbo.OPDServiceSubGroups", t => t.SubGroupId, cascadeDelete: true)
                .Index(t => t.SubGroupId);
            
            CreateTable(
                "dbo.OPDServiceSubGroups",
                c => new
                    {
                        SubGroupId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Name = c.String(),
                        SubGroupType = c.String(),
                        CreateDate = c.DateTime(),
                        Createdby = c.String(),
                        modifiedby = c.String(),
                        Modifieddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SubGroupId)
                .ForeignKey("dbo.OPDServiceGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPDServiceHeads", "SubGroupId", "dbo.OPDServiceSubGroups");
            DropForeignKey("dbo.OPDServiceSubGroups", "GroupId", "dbo.OPDServiceGroups");
            DropIndex("dbo.OPDServiceSubGroups", new[] { "GroupId" });
            DropIndex("dbo.OPDServiceHeads", new[] { "SubGroupId" });
            DropTable("dbo.OPDServiceSubGroups");
            DropTable("dbo.OPDServiceHeads");
            DropTable("dbo.OPDServiceGroups");
        }
    }
}
