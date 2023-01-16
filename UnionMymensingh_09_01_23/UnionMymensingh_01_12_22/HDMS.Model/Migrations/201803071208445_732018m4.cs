namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _732018m4 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Module");
            AddColumn("dbo.Module", "ModuleId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Module", "ModuleId");
            DropColumn("dbo.Module", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Module", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Module");
            DropColumn("dbo.Module", "ModuleId");
            AddPrimaryKey("dbo.Module", "Id");
        }
    }
}
