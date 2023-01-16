namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8052018m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "CountryCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "CountryCode");
        }
    }
}
