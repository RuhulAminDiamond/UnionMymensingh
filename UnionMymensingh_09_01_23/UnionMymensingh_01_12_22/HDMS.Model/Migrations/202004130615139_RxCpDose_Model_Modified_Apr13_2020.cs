namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCpDose_Model_Modified_Apr13_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxCpDosages",
                c => new
                    {
                        DoseId = c.Int(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        DoseEnLong = c.String(),
                        DoseBnLong = c.String(),
                        DoseEnShort = c.String(),
                        DoseBnShort = c.String(),
                    })
                .PrimaryKey(t => t.DoseId);
            
            DropTable("dbo.RxDosages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RxDosages",
                c => new
                    {
                        DoseId = c.Int(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        IsBanglaFont = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DoseId);
            
            DropTable("dbo.RxCpDosages");
        }
    }
}
