namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31052018m101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineOutlets", "CodeNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineOutlets", "CodeNo");
        }
    }
}
