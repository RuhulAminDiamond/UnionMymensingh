namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Added_Modofied_Feb23_2020_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxVisitHistories", "IsServiceCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxVisitHistories", "IsServiceCompleted");
        }
    }
}
