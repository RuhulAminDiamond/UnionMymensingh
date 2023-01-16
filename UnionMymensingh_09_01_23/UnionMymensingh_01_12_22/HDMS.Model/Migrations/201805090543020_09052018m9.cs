namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09052018m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterTestGroups",
                c => new
                    {
                        MasterTestGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MasterTestGroupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MasterTestGroups");
        }
    }
}
