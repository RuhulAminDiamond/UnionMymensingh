namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCpCC_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxCpCCs",
                c => new
                    {
                        RxCCId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        CCEn = c.String(),
                        CCBn = c.String(),
                    })
                .PrimaryKey(t => t.RxCCId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxCpCCs", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxCpCCs", new[] { "CPId" });
            DropTable("dbo.RxCpCCs");
        }
    }
}
