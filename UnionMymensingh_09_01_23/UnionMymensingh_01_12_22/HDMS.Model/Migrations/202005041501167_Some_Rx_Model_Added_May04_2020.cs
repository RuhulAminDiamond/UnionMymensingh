namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Some_Rx_Model_Added_May04_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxCpPreferredTestParameterMasters",
                c => new
                {
                    TpId = c.Int(nullable: false, identity: true),
                    CpId = c.Int(nullable: false),
                    CPPTId = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.TpId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CpId, cascadeDelete: true)
                .ForeignKey("dbo.RxCPPreferredTests", t => t.CPPTId, cascadeDelete: false)
                .Index(t => t.CpId)
                .Index(t => t.CPPTId);

            CreateTable(
                "dbo.RxCpPreferredTestParameterDetails",
                c => new
                    {
                        TpdId = c.Int(nullable: false, identity: true),
                        TpId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        TestDetailId = c.Int(nullable: false),
                        Parameter = c.String(),
                    })
                .PrimaryKey(t => t.TpdId)
                .ForeignKey("dbo.RxCpPreferredTestParameterMasters", t => t.TpId, cascadeDelete: true)
                .Index(t => t.TpId);
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxCpPreferredTestParameterDetails", "TpId", "dbo.RxCpPreferredTestParameterMasters");
            DropForeignKey("dbo.RxCpPreferredTestParameterMasters", "CPPTId", "dbo.RxCPPreferredTests");
            DropForeignKey("dbo.RxCpPreferredTestParameterMasters", "CpId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxCpPreferredTestParameterMasters", new[] { "CPPTId" });
            DropIndex("dbo.RxCpPreferredTestParameterMasters", new[] { "CpId" });
            DropIndex("dbo.RxCpPreferredTestParameterDetails", new[] { "TpId" });
            DropTable("dbo.RxCpPreferredTestParameterMasters");
            DropTable("dbo.RxCpPreferredTestParameterDetails");
        }
    }
}
