namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Changes_March_16_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChamberPractitioners", "PrcticeTimeFrom", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "PrcticeTimeTo", c => c.String());
            DropColumn("dbo.ChamberPractitioners", "PrcticeTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChamberPractitioners", "PrcticeTime", c => c.String());
            DropColumn("dbo.ChamberPractitioners", "PrcticeTimeTo");
            DropColumn("dbo.ChamberPractitioners", "PrcticeTimeFrom");
        }
    }
}
