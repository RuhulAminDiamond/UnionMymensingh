namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_modified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "MediaId");
            DropTable("dbo.BusinessMedias");
            DropTable("dbo.MediaLedgers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MediaLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MediaId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessMedias",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        MediaType = c.String(),
                    })
                .PrimaryKey(t => t.MediaId);
            
            AddColumn("dbo.Patients", "MediaId", c => c.Int(nullable: false));
        }
    }
}
