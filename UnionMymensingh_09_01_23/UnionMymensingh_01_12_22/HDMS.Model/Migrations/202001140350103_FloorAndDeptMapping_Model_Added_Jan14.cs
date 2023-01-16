namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloorAndDeptMapping_Model_Added_Jan14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloorAndDeptMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FloorAndDeptMappings");
        }
    }
}
