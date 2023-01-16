namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Defien_WorkingDays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HrWokingDays",
                c => new
                    {
                        WDId = c.Long(nullable: false, identity: true),
                        WDate = c.DateTime(nullable: false),
                        WDay = c.Int(nullable: false),
                        WMonth = c.Int(nullable: false),
                        WYear = c.Int(nullable: false),
                        IsPublicHoliday = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.WDId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HrWokingDays");
        }
    }
}
