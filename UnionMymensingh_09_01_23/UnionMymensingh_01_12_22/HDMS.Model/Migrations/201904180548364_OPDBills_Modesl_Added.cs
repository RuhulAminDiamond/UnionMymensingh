namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPDBills_Modesl_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpOPDBillDetails",
                c => new
                    {
                        OPDBillDetailId = c.Long(nullable: false, identity: true),
                        OPDBillId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        ServiceName = c.String(),
                        Qty = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OPDBillDetailId)
                .ForeignKey("dbo.HpOPDBills", t => t.OPDBillId, cascadeDelete: true)
                .Index(t => t.OPDBillId);
            
            CreateTable(
                "dbo.HpOPDBills",
                c => new
                    {
                        OPDBillId = c.Long(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        BillTime = c.String(),
                        PatientId = c.Long(nullable: false),
                        BillNo = c.Long(nullable: false),
                        PreparedBy = c.String(),
                        BillType = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.OPDBillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpOPDBillDetails", "OPDBillId", "dbo.HpOPDBills");
            DropIndex("dbo.HpOPDBillDetails", new[] { "OPDBillId" });
            DropTable("dbo.HpOPDBills");
            DropTable("dbo.HpOPDBillDetails");
        }
    }
}
