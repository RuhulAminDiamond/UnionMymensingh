namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloorServiceDeleteLog_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloorServiceDeleteLogs",
                c => new
                    {
                        DeleteId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DeleteId)
               // .ForeignKey("dbo.HospitalPatientInfoes", t => t.AdmissionId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceHeads", t => t.ServiceHeadId, cascadeDelete: true)
                .Index(t => t.AdmissionId)
                .Index(t => t.ServiceHeadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloorServiceDeleteLogs", "ServiceHeadId", "dbo.ServiceHeads");
            DropForeignKey("dbo.FloorServiceDeleteLogs", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropIndex("dbo.FloorServiceDeleteLogs", new[] { "ServiceHeadId" });
            DropIndex("dbo.FloorServiceDeleteLogs", new[] { "AdmissionId" });
            DropTable("dbo.FloorServiceDeleteLogs");
        }
    }
}
