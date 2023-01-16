namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modified_March_02_2020_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxInitialDatas", "RxInitDUpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RxInitialDatas", "RxInitDUpdateTime", c => c.String());
            AddColumn("dbo.RxInitialDatas", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxInitialDatas", "UserId");
            DropColumn("dbo.RxInitialDatas", "RxInitDUpdateTime");
            DropColumn("dbo.RxInitialDatas", "RxInitDUpdateDate");
        }
    }
}
