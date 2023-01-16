namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxResumeHistory_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxResumeOfHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResumeOfHistory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DischargeCertificateDetails", "DisplayOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DischargeCertificateDetails", "DisplayOrder");
            DropTable("dbo.RxResumeOfHistories");
        }
    }
}
