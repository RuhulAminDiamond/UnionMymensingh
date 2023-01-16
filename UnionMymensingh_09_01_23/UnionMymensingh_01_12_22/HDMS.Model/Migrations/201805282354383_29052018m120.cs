namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29052018m120 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AdmissionNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "AdmissionNo");
        }
    }
}
