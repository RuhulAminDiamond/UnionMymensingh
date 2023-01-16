namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03062018m91 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineRequisitions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineRequisitions", "Status");
        }
    }
}
