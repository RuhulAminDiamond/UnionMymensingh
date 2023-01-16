namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_StoreAddDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreDepts",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IndentUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreDepts");
        }
    }
}
