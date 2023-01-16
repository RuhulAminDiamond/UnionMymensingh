namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxDosage_Modified_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxDosages", "ShortDescription", c => c.String());
            AddColumn("dbo.RxDosages", "LongDescription", c => c.String());
            DropColumn("dbo.RxDosages", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxDosages", "Name", c => c.String());
            DropColumn("dbo.RxDosages", "LongDescription");
            DropColumn("dbo.RxDosages", "ShortDescription");
        }
    }
}
