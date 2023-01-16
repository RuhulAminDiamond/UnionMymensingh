namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06062018m203 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientAccomodationTypes",
                c => new
                    {
                        AccomodationTypeId = c.Int(nullable: false, identity: true),
                        AccomodationType = c.String(),
                    })
                .PrimaryKey(t => t.AccomodationTypeId);
            
            AddColumn("dbo.CabinInfoes", "AccomodationTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.CabinInfoes", "AccomodationType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CabinInfoes", "AccomodationType", c => c.String());
            DropColumn("dbo.CabinInfoes", "AccomodationTypeId");
            DropTable("dbo.PatientAccomodationTypes");
        }
    }
}
