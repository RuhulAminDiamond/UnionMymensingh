namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorServiceDeleteLog_added : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DoctorServiceDeletedLogs", newName: "DoctorServiceDeleteLogs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DoctorServiceDeleteLogs", newName: "DoctorServiceDeletedLogs");
        }
    }
}
