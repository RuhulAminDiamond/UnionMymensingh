namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Model_Modified_feb15_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "MedicineRequisitionForwardToOutLet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "MedicineRequisitionForwardToOutLet");
        }
    }
}
