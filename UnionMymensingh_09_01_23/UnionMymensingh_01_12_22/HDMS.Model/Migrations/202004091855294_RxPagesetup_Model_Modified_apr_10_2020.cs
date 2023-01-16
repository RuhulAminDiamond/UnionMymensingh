namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPagesetup_Model_Modified_apr_10_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCPPrintPageSetups", "PageOrientation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxCPPrintPageSetups", "PageOrientation");
        }
    }
}
