namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registrations_Models_Modified_Added_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "NationalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "NationalId");
        }
    }
}
