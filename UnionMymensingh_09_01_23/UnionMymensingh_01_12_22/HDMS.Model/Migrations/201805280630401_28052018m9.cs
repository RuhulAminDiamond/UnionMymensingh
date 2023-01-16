namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhInvoiceTypes",
                c => new
                    {
                        InvoceTypeId = c.Int(nullable: false, identity: true),
                        InvoiceType = c.String(),
                    })
                .PrimaryKey(t => t.InvoceTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhInvoiceTypes");
        }
    }
}
