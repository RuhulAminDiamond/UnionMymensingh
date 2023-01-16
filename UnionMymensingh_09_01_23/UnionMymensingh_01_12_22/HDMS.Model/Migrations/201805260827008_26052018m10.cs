namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26052018m10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiagPatientMovementOrders",
                c => new
                    {
                        MovementId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.MovementId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiagPatientMovementOrders");
        }
    }
}
