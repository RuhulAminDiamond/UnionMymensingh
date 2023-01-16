namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15032018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "OperatorName", c => c.String());
            DropColumn("dbo.TestsCost", "CancelledBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestsCost", "CancelledBy", c => c.String());
            DropColumn("dbo.TestsCost", "OperatorName");
        }
    }
}
