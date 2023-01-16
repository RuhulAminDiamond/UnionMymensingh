namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06072018m556 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DoctorServiceBillDetails");
            CreateTable(
                "dbo.HpDoctorServiceBills",
                c => new
                    {
                        DSbId = c.Long(nullable: false, identity: true),
                        DSDate = c.DateTime(nullable: false),
                        ServiceAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DSbId);
            
            AddColumn("dbo.DoctorServiceBillDetails", "DSBDId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.DoctorServiceBillDetails", "DSBId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.DoctorServiceBillDetails", "DSBDId");
            DropColumn("dbo.DoctorServiceBillDetails", "DSId");
            DropTable("dbo.HpDoctorServices");
        }
        
        public override void Down()
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
            DropPrimaryKey("dbo.DoctorServiceBillDetails");
            AlterColumn("dbo.DoctorServiceBillDetails", "DSBId", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.DoctorServiceBillDetails", "DSBDId");
            DropTable("dbo.HpDoctorServiceBills");
            AddPrimaryKey("dbo.DoctorServiceBillDetails", "DSBId");
        }
    }
}
