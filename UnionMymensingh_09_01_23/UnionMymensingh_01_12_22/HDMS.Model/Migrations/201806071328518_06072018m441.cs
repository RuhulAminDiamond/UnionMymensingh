namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06072018m441 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpDoctorServices",
                c => new
                    {
                        DSId = c.Long(nullable: false, identity: true),
                        DSDate = c.DateTime(nullable: false),
                        ServiceAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DSId);
            
            AddColumn("dbo.DoctorServiceBillDetails", "DSId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorServiceBillDetails", "DSId");
            DropTable("dbo.HpDoctorServices");
        }
    }
}
