namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class July09_PhStockTransferModel_Added_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhStockTransferRecords", "FromOutLet", c => c.Int(nullable: false));
            AddColumn("dbo.PhStockTransferRecords", "ToOutLet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhStockTransferRecords", "ToOutLet");
            DropColumn("dbo.PhStockTransferRecords", "FromOutLet");
        }
    }
}
