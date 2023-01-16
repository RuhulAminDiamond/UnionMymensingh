namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rx_Model_Modfied_Apr25_2020_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "CommentsOrReferral", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "Notes", c => c.String());
            AddColumn("dbo.RxInitialDatas", "CommentsOrReferral", c => c.String());
            AddColumn("dbo.RxInitialDatas", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxInitialDatas", "Notes");
            DropColumn("dbo.RxInitialDatas", "CommentsOrReferral");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "Notes");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "CommentsOrReferral");
        }
    }
}
