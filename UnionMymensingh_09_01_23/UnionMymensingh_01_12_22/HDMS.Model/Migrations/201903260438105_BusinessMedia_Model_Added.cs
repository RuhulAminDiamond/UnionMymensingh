namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessMedia_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessMedias",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        MediaType = c.String(),
                    })
                .PrimaryKey(t => t.MediaId);
            
            CreateTable(
                "dbo.MediaLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MediaId = c.Int(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessMedias", t => t.MediaId, cascadeDelete: true)
                .Index(t => t.MediaId);
            
            AddColumn("dbo.Patients", "MediaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaLedgers", "MediaId", "dbo.BusinessMedias");
            DropIndex("dbo.MediaLedgers", new[] { "MediaId" });
            DropColumn("dbo.Patients", "MediaId");
            DropTable("dbo.MediaLedgers");
            DropTable("dbo.BusinessMedias");
        }
    }
}
