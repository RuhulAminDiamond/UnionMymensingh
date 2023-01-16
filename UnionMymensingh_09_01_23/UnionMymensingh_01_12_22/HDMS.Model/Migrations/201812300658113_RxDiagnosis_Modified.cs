namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxDiagnosis_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxDiagnosis", "Name", c => c.String());
            DropColumn("dbo.RxDiagnosis", "RxId");
            DropColumn("dbo.RxDiagnosis", "TestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxDiagnosis", "TestId", c => c.Int(nullable: false));
            AddColumn("dbo.RxDiagnosis", "RxId", c => c.Long(nullable: false));
            DropColumn("dbo.RxDiagnosis", "Name");
        }
    }
}
