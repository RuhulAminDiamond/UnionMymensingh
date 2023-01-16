namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12062018m3001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineReturnInednts", "ReturnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HpMedicineReturnInednts", "ReturnTime", c => c.String());
            DropColumn("dbo.HpMedicineReturnInednts", "ReturnIndentNo");
            DropColumn("dbo.HpMedicineReturnInednts", "ReqDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpMedicineReturnInednts", "ReqDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HpMedicineReturnInednts", "ReturnIndentNo", c => c.Long(nullable: false));
            DropColumn("dbo.HpMedicineReturnInednts", "ReturnTime");
            DropColumn("dbo.HpMedicineReturnInednts", "ReturnDate");
        }
    }
}
