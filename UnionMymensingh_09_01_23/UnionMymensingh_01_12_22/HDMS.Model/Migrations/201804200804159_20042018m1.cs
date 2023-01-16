namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20042018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountHeads", "AccCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountHeads", "AccCode");
        }
    }
}
