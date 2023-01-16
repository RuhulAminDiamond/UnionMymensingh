namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpAdvancePayments", "AdvanceCollectionBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpAdvancePayments", "AdvanceCollectionBy");
        }
    }
}
