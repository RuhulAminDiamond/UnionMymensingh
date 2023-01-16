namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30052018m19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoices", "InvTime", c => c.String());
            AddColumn("dbo.PhInvoices", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhInvoices", "UserId");
            AddForeignKey("dbo.PhInvoices", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhInvoices", "UserId", "dbo.User");
            DropIndex("dbo.PhInvoices", new[] { "UserId" });
            DropColumn("dbo.PhInvoices", "UserId");
            DropColumn("dbo.PhInvoices", "InvTime");
        }
    }
}
