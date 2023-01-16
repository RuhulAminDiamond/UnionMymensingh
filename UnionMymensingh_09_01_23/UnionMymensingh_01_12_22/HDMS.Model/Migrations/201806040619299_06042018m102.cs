namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m102 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpRequisitionTypes",
                c => new
                    {
                        RequisitionTypeId = c.Int(nullable: false, identity: true),
                        RequisitionType = c.String(),
                    })
                .PrimaryKey(t => t.RequisitionTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpRequisitionTypes");
        }
    }
}
