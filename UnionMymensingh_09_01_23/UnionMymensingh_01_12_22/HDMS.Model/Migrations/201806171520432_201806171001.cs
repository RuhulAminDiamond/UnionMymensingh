namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201806171001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "Dischargedby", c => c.String());
            AddColumn("dbo.HospitalBills", "BillType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalBills", "BillType");
            DropColumn("dbo.HospitalPatientInfoes", "Dischargedby");
        }
    }
}
