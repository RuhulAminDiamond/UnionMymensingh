namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Generic_Model_Modified_March_09_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Generics", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.Generics", "Info", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Generics", "Info");
            DropColumn("dbo.Generics", "GroupId");
        }
    }
}
