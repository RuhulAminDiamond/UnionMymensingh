namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CabinInfo_model_Modified_July31_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabinInfoes", "DeptId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CabinInfoes", "DeptId");
        }
    }
}
