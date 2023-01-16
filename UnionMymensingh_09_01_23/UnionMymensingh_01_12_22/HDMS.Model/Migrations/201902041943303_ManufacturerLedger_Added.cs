namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufacturerLedger_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManufacturerLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        Trandate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManufacturerLedgers", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.ManufacturerLedgers", new[] { "ManufacturerId" });
            DropTable("dbo.ManufacturerLedgers");
        }
    }
}
