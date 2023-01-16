namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rx_Treatment_Template_Model_Modified_May28_2020 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RxCPDrugTemplateDetails", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxCPDrugTemplateDetails", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
