namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreatmentOnDischarge_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreatmentOnDischarges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        MedicineName = c.String(),
                        Dosage = c.String(),
                        Duration = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TreatmentOnDischarges");
        }
    }
}
