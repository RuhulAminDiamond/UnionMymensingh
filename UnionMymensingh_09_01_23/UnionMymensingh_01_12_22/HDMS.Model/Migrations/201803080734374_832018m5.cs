namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _832018m5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestSubItems",
                c => new
                    {
                        TestSubItemId = c.Int(nullable: false, identity: true),
                        MainTestId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        Name = c.String(),
                        Vatable = c.Boolean(nullable: false),
                        ReportTypeId = c.Int(nullable: false),
                        Rate = c.Single(nullable: false),
                        Qty = c.Int(nullable: false),
                        SC = c.Single(nullable: false),
                        Specimen = c.String(),
                        Exclusive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TestSubItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestSubItems");
        }
    }
}
