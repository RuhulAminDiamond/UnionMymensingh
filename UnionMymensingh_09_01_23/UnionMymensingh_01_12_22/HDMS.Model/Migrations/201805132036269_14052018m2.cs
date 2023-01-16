namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14052018m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
            DropTable("dbo.TubeMpping");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TubeMpping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(),
                        TestId = c.Int(),
                        TubeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Departments");
        }
    }
}
