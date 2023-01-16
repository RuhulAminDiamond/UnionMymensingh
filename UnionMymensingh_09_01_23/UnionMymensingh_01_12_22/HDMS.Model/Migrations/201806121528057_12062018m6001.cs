namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12062018m6001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineReturnIndentDetails", "BatchNo", c => c.String());
            AddColumn("dbo.HpMedicineReturnIndentDetails", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HpMedicineReturnIndentDetails", "SRate", c => c.Double(nullable: false));
            AddColumn("dbo.HpMedicineReturnIndentDetails", "PRate", c => c.Double(nullable: false));
            AddColumn("dbo.HpMedicineReturnIndentDetails", "TSaleAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineReturnIndentDetails", "TSaleAmount");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "PRate");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "SRate");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "ExpireDate");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "BatchNo");
        }
    }
}
