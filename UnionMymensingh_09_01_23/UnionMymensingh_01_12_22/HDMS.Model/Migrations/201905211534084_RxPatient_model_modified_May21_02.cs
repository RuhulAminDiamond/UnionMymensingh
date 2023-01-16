namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatient_model_modified_May21_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientInfoes", "AnySpecialNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxPatientInfoes", "AnySpecialNote");
        }
    }
}
