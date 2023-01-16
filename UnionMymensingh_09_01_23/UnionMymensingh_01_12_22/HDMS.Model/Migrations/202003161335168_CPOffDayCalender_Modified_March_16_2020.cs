namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CPOffDayCalender_Modified_March_16_2020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CPOffDayCalenders", "MonthlyOffDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CPOffDayCalenders", "MonthlyOffDate", c => c.DateTime(nullable: false));
        }
    }
}
