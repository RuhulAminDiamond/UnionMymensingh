namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06032018m92 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpParameterSetups", "AmountType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpParameterSetups", "AmountType");
        }
    }
}
