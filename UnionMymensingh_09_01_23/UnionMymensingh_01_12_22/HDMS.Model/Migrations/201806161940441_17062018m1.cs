namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17062018m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpCabinCharges",
                c => new
                    {
                        HpCCId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        TotalDays = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.HpCCId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpCabinCharges");
        }
    }
}
