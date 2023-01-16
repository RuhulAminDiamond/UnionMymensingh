namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210042018m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SampleCollectionSettings",
                c => new
                    {
                        SCSId = c.Int(nullable: false, identity: true),
                        MainTestId = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SCSId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SampleCollectionSettings");
        }
    }
}
