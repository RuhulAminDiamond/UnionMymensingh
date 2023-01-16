namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07052018m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "DiscountRequestById", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "DiscountGivenByRequestInPercent", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "DoctorId");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctor", "DoctorId", cascadeDelete: false);
            DropColumn("dbo.Patients", "RefbyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "RefbyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropColumn("dbo.Patients", "DiscountGivenByRequestInPercent");
            DropColumn("dbo.Patients", "DiscountRequestById");
            DropColumn("dbo.Patients", "DoctorId");
        }
    }
}
