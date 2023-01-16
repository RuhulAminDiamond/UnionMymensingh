namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m104 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CabinInfoes", "FloorId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CabinInfoes", "FloorId", c => c.String());
        }
    }
}
