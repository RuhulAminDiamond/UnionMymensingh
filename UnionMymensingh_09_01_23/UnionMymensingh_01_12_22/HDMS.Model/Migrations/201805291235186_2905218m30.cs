namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2905218m30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "VisitFee", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "VisitFee");
        }
    }
}
