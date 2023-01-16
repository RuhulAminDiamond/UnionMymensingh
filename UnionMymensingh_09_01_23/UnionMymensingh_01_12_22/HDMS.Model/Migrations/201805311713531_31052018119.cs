namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31052018119 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceHeads", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.ServiceHeads", "Modifieddate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceHeads", "Modifieddate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ServiceHeads", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
