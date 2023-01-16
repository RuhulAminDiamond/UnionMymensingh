namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChamberPractitioner_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChamberPractitioners", "CPSId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChamberPractitioners", "CPSId");
            AddForeignKey("dbo.ChamberPractitioners", "CPSId", "dbo.ChamberPractitionerSpecialities", "CPSId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChamberPractitioners", "CPSId", "dbo.ChamberPractitionerSpecialities");
            DropIndex("dbo.ChamberPractitioners", new[] { "CPSId" });
            DropColumn("dbo.ChamberPractitioners", "CPSId");
        }
    }
}
