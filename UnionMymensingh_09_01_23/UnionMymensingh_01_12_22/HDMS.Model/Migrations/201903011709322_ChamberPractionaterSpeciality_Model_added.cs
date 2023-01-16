namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChamberPractionaterSpeciality_Model_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChamberPractitionerSpecialities",
                c => new
                    {
                        CPSId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CPSId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChamberPractitionerSpecialities");
        }
    }
}
