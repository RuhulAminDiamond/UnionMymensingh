namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _612018m14 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PhInvoices", "OutLetId");
            AddForeignKey("dbo.PhInvoices", "OutLetId", "dbo.MedicineOutlets", "OutLetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhInvoices", "OutLetId", "dbo.MedicineOutlets");
            DropIndex("dbo.PhInvoices", new[] { "OutLetId" });
        }
    }
}
