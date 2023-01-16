namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _932017m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BN_Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BN_Name = c.String(),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BN_Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DivisionId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.RegRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.Long(nullable: false),
                        RegHex = c.String(),
                        Title = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        FullName = c.String(),
                        AgeYear = c.String(),
                        AgeMonth = c.String(),
                        AgeDay = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Sex = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        MaritalStatus = c.String(),
                        Profession = c.String(),
                        MobileNo = c.String(),
                        EmailId = c.String(),
                        MType = c.String(),
                        Discount = c.Double(nullable: false),
                        Address = c.String(),
                        UpazilaId = c.Int(nullable: false),
                        UnionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unions",
                c => new
                    {
                        UnionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BN_Name = c.String(),
                        UpazilaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnionId)
                .ForeignKey("dbo.Upazilas", t => t.UpazilaId, cascadeDelete: true)
                .Index(t => t.UpazilaId);
            
            CreateTable(
                "dbo.Upazilas",
                c => new
                    {
                        UpazilaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BN_Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UpazilaId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Unions", "UpazilaId", "dbo.Upazilas");
            DropForeignKey("dbo.Upazilas", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Upazilas", new[] { "DistrictId" });
            DropIndex("dbo.Unions", new[] { "UpazilaId" });
            DropIndex("dbo.Divisions", new[] { "CountryId" });
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropTable("dbo.Upazilas");
            DropTable("dbo.Unions");
            DropTable("dbo.RegRecords");
            DropTable("dbo.Divisions");
            DropTable("dbo.Districts");
            DropTable("dbo.Countries");
        }
    }
}
