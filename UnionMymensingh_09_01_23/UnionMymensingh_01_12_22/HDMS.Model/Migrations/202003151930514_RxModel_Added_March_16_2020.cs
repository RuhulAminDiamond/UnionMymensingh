namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Added_March_16_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CPOffDayCalenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        WeeklyOffDay = c.String(),
                        MonthlyOffDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ChamberPractitioners", "PrcticeTime", c => c.String());
            DropColumn("dbo.ChamberPractitioners", "OffDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChamberPractitioners", "OffDay", c => c.String());
            DropColumn("dbo.ChamberPractitioners", "PrcticeTime");
            DropTable("dbo.CPOffDayCalenders");
        }
    }
}
