namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceiveDetails", "BatchNo", c => c.String());
            AddColumn("dbo.PhReceiveDetails", "disCountInpercent", c => c.Double(nullable: false));
            AddColumn("dbo.PhReceiveDetails", "grossDiscount", c => c.Double(nullable: false));
            AddColumn("dbo.PhReceiveDetails", "ExpireDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReceiveDetails", "ExpireDate");
            DropColumn("dbo.PhReceiveDetails", "grossDiscount");
            DropColumn("dbo.PhReceiveDetails", "disCountInpercent");
            DropColumn("dbo.PhReceiveDetails", "BatchNo");
        }
    }
}
