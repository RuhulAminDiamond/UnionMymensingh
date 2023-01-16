namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1132018m3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "AdmissionNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "AdmissionNo", c => c.Long(nullable: false));
        }
    }
}
