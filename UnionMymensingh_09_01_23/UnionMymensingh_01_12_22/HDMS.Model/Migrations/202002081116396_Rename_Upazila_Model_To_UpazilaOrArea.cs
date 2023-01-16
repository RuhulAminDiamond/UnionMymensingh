namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Upazila_Model_To_UpazilaOrArea : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Upazilas", newName: "UpazilaOrAreas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UpazilaOrAreas", newName: "Upazilas");
        }
    }
}
