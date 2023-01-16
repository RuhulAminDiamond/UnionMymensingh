namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_RxPatientInfo_Modidfied_May15_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientInfoes", "IsServiceDelivered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxPatientInfoes", "IsServiceDelivered");
        }
    }
}
