namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06062018m202 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabinInfoes", "AccomodationType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CabinInfoes", "AccomodationType");
        }
    }
}
