namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06072018m334 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceBillDetails", "SBId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceBillDetails", "SBId");
        }
    }
}
