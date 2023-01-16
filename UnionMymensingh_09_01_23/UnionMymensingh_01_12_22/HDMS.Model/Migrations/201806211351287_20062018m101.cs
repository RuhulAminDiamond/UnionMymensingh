namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegUniqueKeyTrackers",
                c => new
                    {
                        RegNo = c.Long(nullable: false, identity: true),
                        GenerateBy = c.String(),
                        GenerateFrom = c.String(),
                        GenerateTime = c.String(),
                    })
                .PrimaryKey(t => t.RegNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegUniqueKeyTrackers");
        }
    }
}
