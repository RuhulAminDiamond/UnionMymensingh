namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15032018m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "UserId");
            AddForeignKey("dbo.Patients", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropColumn("dbo.Patients", "Receivedby");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Receivedby", c => c.Int(nullable: false));
            DropForeignKey("dbo.Patients", "UserId", "dbo.User");
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropColumn("dbo.Patients", "UserId");
        }
    }
}
