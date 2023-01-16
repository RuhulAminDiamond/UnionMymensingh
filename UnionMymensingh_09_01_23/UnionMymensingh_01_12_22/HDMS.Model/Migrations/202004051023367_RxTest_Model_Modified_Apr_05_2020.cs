namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxTest_Model_Modified_Apr_05_2020 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RxTests", "RxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxTests", "RxId", c => c.Long(nullable: false));
        }
    }
}
