namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modiifed_March_05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxInitialDatas", "CC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxInitialDatas", "CC");
        }
    }
}
