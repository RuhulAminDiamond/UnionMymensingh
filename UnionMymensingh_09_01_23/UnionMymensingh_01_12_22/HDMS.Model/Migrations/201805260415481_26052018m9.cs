namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26052018m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "BillNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "BillNo");
        }
    }
}
