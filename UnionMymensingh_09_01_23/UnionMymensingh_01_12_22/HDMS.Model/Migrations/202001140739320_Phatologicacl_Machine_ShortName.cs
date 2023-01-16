namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phatologicacl_Machine_ShortName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PathologicalMachines", "TestGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.PathologicalMachines", "MachineShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PathologicalMachines", "MachineShortName");
            DropColumn("dbo.PathologicalMachines", "TestGroupId");
        }
    }
}
