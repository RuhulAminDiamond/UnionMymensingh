namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _612018m12 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PhReceives", "OutLetId");
            AddForeignKey("dbo.PhReceives", "OutLetId", "dbo.MedicineOutlets", "OutLetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhReceives", "OutLetId", "dbo.MedicineOutlets");
            DropIndex("dbo.PhReceives", new[] { "OutLetId" });
        }
    }
}
