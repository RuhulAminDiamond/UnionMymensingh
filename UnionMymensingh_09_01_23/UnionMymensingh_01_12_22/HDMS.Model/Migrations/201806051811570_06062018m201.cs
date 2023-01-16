namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06062018m201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoices", "RequisitionNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhInvoices", "RequisitionNo");
        }
    }
}
