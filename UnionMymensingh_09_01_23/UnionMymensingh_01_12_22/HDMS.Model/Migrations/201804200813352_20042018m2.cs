namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20042018m2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountHeads", "AccCode", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccountHeads", "AccCode", c => c.Int(nullable: false));
        }
    }
}
