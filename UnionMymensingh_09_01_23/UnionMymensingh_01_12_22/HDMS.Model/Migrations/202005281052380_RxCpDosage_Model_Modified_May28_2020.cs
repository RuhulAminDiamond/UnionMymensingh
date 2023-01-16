namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCpDosage_Model_Modified_May28_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCpDosages", "EMRInterPretId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxCpDosages", "EMRInterPretId");
        }
    }
}
