namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChamberPractitioner_model_modified_march_01 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ChamberPractitioners");
            AddColumn("dbo.ChamberPractitioners", "CPId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ChamberPractitioners", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.ChamberPractitioners", "Fsize1", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "DIdentityLine1", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Fsize2", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "DIdentityLine2", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Fsize3", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "DIdentityLine3", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Fsize4", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "DIdentityLine4", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Fsize5", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "DIdentityLine5", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Fsize6", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "DIdentityLine6", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Fsize7", c => c.Int());
            AddColumn("dbo.ChamberPractitioners", "CPUserId", c => c.Int(nullable: false));
            AddColumn("dbo.ChamberPractitioners", "ESignature", c => c.Binary());
            AddColumn("dbo.ChamberPractitioners", "IsESignatureAllow", c => c.String());
            AddPrimaryKey("dbo.ChamberPractitioners", "CPId");
            CreateIndex("dbo.ChamberPractitioners", "DoctorId");
            AddForeignKey("dbo.ChamberPractitioners", "DoctorId", "dbo.Doctor", "DoctorId", cascadeDelete: true);
            DropColumn("dbo.ChamberPractitioners", "Id");
            DropColumn("dbo.ChamberPractitioners", "Identity1");
            DropColumn("dbo.ChamberPractitioners", "Identity2");
            DropColumn("dbo.ChamberPractitioners", "Identity3");
            DropColumn("dbo.ChamberPractitioners", "Identity4");
            DropColumn("dbo.ChamberPractitioners", "Identity5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChamberPractitioners", "Identity5", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Identity4", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Identity3", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Identity2", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Identity1", c => c.String());
            AddColumn("dbo.ChamberPractitioners", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ChamberPractitioners", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.ChamberPractitioners", new[] { "DoctorId" });
            DropPrimaryKey("dbo.ChamberPractitioners");
            DropColumn("dbo.ChamberPractitioners", "IsESignatureAllow");
            DropColumn("dbo.ChamberPractitioners", "ESignature");
            DropColumn("dbo.ChamberPractitioners", "CPUserId");
            DropColumn("dbo.ChamberPractitioners", "Fsize7");
            DropColumn("dbo.ChamberPractitioners", "DIdentityLine6");
            DropColumn("dbo.ChamberPractitioners", "Fsize6");
            DropColumn("dbo.ChamberPractitioners", "DIdentityLine5");
            DropColumn("dbo.ChamberPractitioners", "Fsize5");
            DropColumn("dbo.ChamberPractitioners", "DIdentityLine4");
            DropColumn("dbo.ChamberPractitioners", "Fsize4");
            DropColumn("dbo.ChamberPractitioners", "DIdentityLine3");
            DropColumn("dbo.ChamberPractitioners", "Fsize3");
            DropColumn("dbo.ChamberPractitioners", "DIdentityLine2");
            DropColumn("dbo.ChamberPractitioners", "Fsize2");
            DropColumn("dbo.ChamberPractitioners", "DIdentityLine1");
            DropColumn("dbo.ChamberPractitioners", "Fsize1");
            DropColumn("dbo.ChamberPractitioners", "DoctorId");
            DropColumn("dbo.ChamberPractitioners", "CPId");
            AddPrimaryKey("dbo.ChamberPractitioners", "Id");
        }
    }
}
