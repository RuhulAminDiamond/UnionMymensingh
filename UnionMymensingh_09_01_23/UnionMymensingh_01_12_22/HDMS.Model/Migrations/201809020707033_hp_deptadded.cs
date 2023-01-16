namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hp_deptadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpDepartments", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpDepartments", "Description");
        }
    }
}
