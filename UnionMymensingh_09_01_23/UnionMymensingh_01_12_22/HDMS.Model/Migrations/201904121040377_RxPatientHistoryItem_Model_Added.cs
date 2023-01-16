namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientHistoryItem_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxPatientHistoryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.RxResumeOfHistories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RxResumeOfHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResumeOfHistory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.RxPatientHistoryItems");
        }
    }
}
