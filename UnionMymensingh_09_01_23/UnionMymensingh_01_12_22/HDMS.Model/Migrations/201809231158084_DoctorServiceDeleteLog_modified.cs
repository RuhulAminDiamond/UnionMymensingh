namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorServiceDeleteLog_modified : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.DoctorServiceDeleteLogs");
            AddColumn("dbo.DoctorServiceDeleteLogs", "DeleteId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.DoctorServiceDeleteLogs", "DeletedBy", c => c.String());
            AddPrimaryKey("dbo.DoctorServiceDeleteLogs", "DeleteId");
            DropColumn("dbo.DoctorServiceDeleteLogs", "DSBDId");
            DropColumn("dbo.DoctorServiceDeleteLogs", "DSBId");
            DropColumn("dbo.DoctorServiceDeleteLogs", "ModifiedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DoctorServiceDeleteLogs", "ModifiedBy", c => c.String());
            AddColumn("dbo.DoctorServiceDeleteLogs", "DSBId", c => c.Long(nullable: false));
            AddColumn("dbo.DoctorServiceDeleteLogs", "DSBDId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.DoctorServiceDeleteLogs");
            DropColumn("dbo.DoctorServiceDeleteLogs", "DeletedBy");
            DropColumn("dbo.DoctorServiceDeleteLogs", "DeleteId");
            AddPrimaryKey("dbo.DoctorServiceDeleteLogs", "DSBDId");
        }
    }
}
