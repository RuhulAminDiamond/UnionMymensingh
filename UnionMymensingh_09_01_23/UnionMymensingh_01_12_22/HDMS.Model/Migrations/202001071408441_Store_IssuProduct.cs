namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Store_IssuProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreRequisitions",
                c => new
                    {
                        RequisitionId = c.Long(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        RDate = c.DateTime(nullable: false),
                        RTime = c.String(),
                        OperateBy = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RequisitionId)
                .ForeignKey("dbo.StoreDepts", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            AddColumn("dbo.StoreInvoices", "RequisitionId", c => c.Long(nullable: false));
            AddColumn("dbo.StoreInvoices", "DeptId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreRequisitions", "DeptId", "dbo.StoreDepts");
            DropIndex("dbo.StoreRequisitions", new[] { "DeptId" });
            DropColumn("dbo.StoreInvoices", "DeptId");
            DropColumn("dbo.StoreInvoices", "RequisitionId");
            DropTable("dbo.StoreRequisitions");
        }
    }
}
