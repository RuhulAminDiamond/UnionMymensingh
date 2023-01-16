namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09062018m901 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpPatientCurrentAccomodations",
                c => new
                    {
                        AccomId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        AccomodateDate = c.DateTime(nullable: false),
                        AccomodateTime = c.String(),
                        CabinId = c.Int(nullable: false),
                        Status = c.String(),
                        OperatorRemarks = c.String(),
                        SoftwareRemarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.AccomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpPatientCurrentAccomodations");
        }
    }
}
