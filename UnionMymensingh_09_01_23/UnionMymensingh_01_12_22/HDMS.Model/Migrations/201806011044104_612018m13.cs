namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _612018m13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoices", "OutLetId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhInvoices", "OutLetId");
        }
    }
}
