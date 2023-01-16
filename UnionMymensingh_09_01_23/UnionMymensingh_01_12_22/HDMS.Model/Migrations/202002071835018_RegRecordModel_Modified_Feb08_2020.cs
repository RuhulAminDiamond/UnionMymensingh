namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecordModel_Modified_Feb08_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "NoOfSons", c => c.String());
            AddColumn("dbo.RegRecords", "NoOfDaughters", c => c.String());
            AddColumn("dbo.RegRecords", "CPHouseNo", c => c.String());
            AddColumn("dbo.RegRecords", "CPRoadNo", c => c.String());
            AddColumn("dbo.RegRecords", "CPVillage", c => c.String());
            AddColumn("dbo.RegRecords", "CPPo", c => c.String());
            AddColumn("dbo.RegRecords", "HouseNo", c => c.String());
            AddColumn("dbo.RegRecords", "RoadNo", c => c.String());
            AddColumn("dbo.RegRecords", "Village", c => c.String());
            AddColumn("dbo.RegRecords", "PO", c => c.String());
            AddColumn("dbo.RegRecords", "UpazilaOrAreaId", c => c.Int(nullable: false));
            DropColumn("dbo.RegRecords", "CPAddress");
            DropColumn("dbo.RegRecords", "UpazilaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegRecords", "UpazilaId", c => c.Int(nullable: false));
            AddColumn("dbo.RegRecords", "CPAddress", c => c.String());
            DropColumn("dbo.RegRecords", "UpazilaOrAreaId");
            DropColumn("dbo.RegRecords", "PO");
            DropColumn("dbo.RegRecords", "Village");
            DropColumn("dbo.RegRecords", "RoadNo");
            DropColumn("dbo.RegRecords", "HouseNo");
            DropColumn("dbo.RegRecords", "CPPo");
            DropColumn("dbo.RegRecords", "CPVillage");
            DropColumn("dbo.RegRecords", "CPRoadNo");
            DropColumn("dbo.RegRecords", "CPHouseNo");
            DropColumn("dbo.RegRecords", "NoOfDaughters");
            DropColumn("dbo.RegRecords", "NoOfSons");
        }
    }
}
