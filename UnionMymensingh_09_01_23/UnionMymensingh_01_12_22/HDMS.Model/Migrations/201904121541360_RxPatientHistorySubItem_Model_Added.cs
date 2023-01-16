namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientHistorySubItem_Model_Added : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.RxPatientHistoryItems");
            CreateTable(
                "dbo.RxPatientHistorySubItems",
                c => new
                    {
                        RxHSubItemId = c.Int(nullable: false, identity: true),
                        RxHItemId = c.Int(nullable: false),
                        SubItemName = c.String(),
                    })
                .PrimaryKey(t => t.RxHSubItemId)
                .ForeignKey("dbo.RxPatientHistoryItems", t => t.RxHItemId, cascadeDelete: true)
                .Index(t => t.RxHItemId);
            
            AddColumn("dbo.RxPatientHistoryItems", "RxHItemId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RxPatientHistoryItems", "RxHItemId");
           // DropColumn("dbo.RxPatientHistoryItems", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientHistoryItems", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RxPatientHistorySubItems", "RxHItemId", "dbo.RxPatientHistoryItems");
            DropIndex("dbo.RxPatientHistorySubItems", new[] { "RxHItemId" });
           // DropPrimaryKey("dbo.RxPatientHistoryItems");
            DropColumn("dbo.RxPatientHistoryItems", "RxHItemId");
            DropTable("dbo.RxPatientHistorySubItems");
           // AddPrimaryKey("dbo.RxPatientHistoryItems", "Id");
        }
    }
}
