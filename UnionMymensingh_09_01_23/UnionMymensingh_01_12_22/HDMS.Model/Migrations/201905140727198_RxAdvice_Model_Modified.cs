namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxAdvice_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxAdvices", "CPId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxAdvices", "CPId");
        }
    }
}
