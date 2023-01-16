namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReturnToSupplier_Model_Modified_May23_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReturnToSuppliers", "ReturnClaim", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReturnToSuppliers", "ReturnClaim");
        }
    }
}
