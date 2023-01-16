namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_RxVisitHistory_Modified_May31_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxVisitHistories", "VisitTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxVisitHistories", "VisitTime");
        }
    }
}
