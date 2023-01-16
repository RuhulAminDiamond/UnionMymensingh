namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReceive_Model_Modified_March23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceives", "IPDReturnBy", c => c.Long(nullable: false));
            AddColumn("dbo.PhReceives", "OPDReturnInvoice", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReceives", "OPDReturnInvoice");
            DropColumn("dbo.PhReceives", "IPDReturnBy");
        }
    }
}
