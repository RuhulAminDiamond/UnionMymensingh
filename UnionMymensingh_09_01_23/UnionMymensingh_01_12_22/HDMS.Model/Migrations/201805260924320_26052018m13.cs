namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26052018m13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestGroups", "MovementOrder", c => c.Int(nullable: false));
            AddColumn("dbo.TestGroups", "MovementRoomNo", c => c.String());
            AddColumn("dbo.TestGroups", "DeptName", c => c.String());
            DropColumn("dbo.TestGroups", "MovementOrderr");
            DropTable("dbo.DiagPatientMovementOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DiagPatientMovementOrders",
                c => new
                    {
                        MovementId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        RoomNo = c.String(),
                    })
                .PrimaryKey(t => t.MovementId);
            
            AddColumn("dbo.TestGroups", "MovementOrderr", c => c.Int(nullable: false));
            DropColumn("dbo.TestGroups", "DeptName");
            DropColumn("dbo.TestGroups", "MovementRoomNo");
            DropColumn("dbo.TestGroups", "MovementOrder");
        }
    }
}
