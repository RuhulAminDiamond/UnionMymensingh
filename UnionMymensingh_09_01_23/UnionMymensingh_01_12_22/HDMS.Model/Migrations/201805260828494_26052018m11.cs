namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26052018m11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiagPatientMovementOrders", "RoomNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiagPatientMovementOrders", "RoomNo");
        }
    }
}
