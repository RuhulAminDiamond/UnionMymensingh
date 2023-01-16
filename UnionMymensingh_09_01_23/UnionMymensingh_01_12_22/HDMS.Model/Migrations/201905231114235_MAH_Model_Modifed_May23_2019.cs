namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAH_Model_Modifed_May23_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhSupplierReturnDetails", "Rate", c => c.Double(nullable: false));
            AlterColumn("dbo.PhSupplierReturnDetails", "Qty", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhSupplierReturnDetails", "Qty", c => c.Int(nullable: false));
            DropColumn("dbo.PhSupplierReturnDetails", "Rate");
        }
    }
}
