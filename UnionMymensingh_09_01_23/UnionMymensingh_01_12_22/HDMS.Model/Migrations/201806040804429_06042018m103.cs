namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m103 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloorInfoes",
                c => new
                    {
                        FloorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FloorId);
            
            AddColumn("dbo.CabinInfoes", "FloorId", c => c.String());
            AddColumn("dbo.User", "FloorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "FloorId");
            DropColumn("dbo.CabinInfoes", "FloorId");
            DropTable("dbo.FloorInfoes");
        }
    }
}
