namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jun01_2019_PhModel_Changes_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineRequisitionDetails", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineRequisitionDetails", "Status");
        }
    }
}
