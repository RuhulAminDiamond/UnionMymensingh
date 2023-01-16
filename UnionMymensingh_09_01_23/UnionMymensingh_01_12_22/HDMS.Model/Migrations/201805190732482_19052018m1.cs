namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19052018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Module", "frmName", c => c.String());
            AddColumn("dbo.Module", "DisplayType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Module", "DisplayType");
            DropColumn("dbo.Module", "frmName");
        }
    }
}
