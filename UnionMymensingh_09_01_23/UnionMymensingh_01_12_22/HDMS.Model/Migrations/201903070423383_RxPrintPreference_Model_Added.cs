namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPrintPreference_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxPrintPreferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        PrefName = c.String(),
                        IsPrintable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RxPrintPreferences");
        }
    }
}
