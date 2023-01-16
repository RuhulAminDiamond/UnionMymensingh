namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor_M_Modified_Feb03_12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "RCId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "RCId");
        }
    }
}
