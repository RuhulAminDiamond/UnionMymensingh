namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31052018m90 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.RegRecords");
            AlterColumn("dbo.RegRecords", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.RegRecords", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RegRecords");
            AlterColumn("dbo.RegRecords", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RegRecords", "Id");
        }
    }
}
