namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPrescriprionPart_1_2_3_Model_Added_Apr05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TmpPrescriptionDataPart1",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        Title = c.String(),
                        Values = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TmpPrescriptionDataPart2",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        Title = c.String(),
                        Values = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TmpPrescriptionDataPart3",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        Title = c.String(),
                        Value1 = c.String(),
                        Value2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TmpPrescriptionDataPart3");
            DropTable("dbo.TmpPrescriptionDataPart2");
            DropTable("dbo.TmpPrescriptionDataPart1");
        }
    }
}
