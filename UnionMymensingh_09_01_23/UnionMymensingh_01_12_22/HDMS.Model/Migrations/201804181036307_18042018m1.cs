namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18042018m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoucherDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoucherMasterId = c.Int(nullable: false),
                        DRCR = c.String(),
                        PostingAccountHead = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        reamrks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Short(nullable: false),
                        VoucherID = c.String(),
                        VoucherDate = c.DateTime(nullable: false),
                        Desccription = c.String(),
                        CreateUser = c.String(),
                        VoucherType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AccountHeads", "CompanyId", c => c.Short(nullable: false));
            AddColumn("dbo.AccountHeads", "ParentAccountHeadId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "AccountHeadName", c => c.String());
            AddColumn("dbo.AccountHeads", "Description", c => c.String());
            AddColumn("dbo.AccountHeads", "IsPostingHead", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "IsCashHead", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "IsBankHead", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "IsBalanceSheet", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "IsIncomeExpense", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "IsReceivedPayment", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "TopAccountHead", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "SequenceNo", c => c.Int(nullable: false));
            DropColumn("dbo.AccountHeads", "Name");
            DropColumn("dbo.AccountHeads", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountHeads", "Type", c => c.String());
            AddColumn("dbo.AccountHeads", "Name", c => c.String());
            DropColumn("dbo.AccountHeads", "SequenceNo");
            DropColumn("dbo.AccountHeads", "TopAccountHead");
            DropColumn("dbo.AccountHeads", "IsReceivedPayment");
            DropColumn("dbo.AccountHeads", "IsIncomeExpense");
            DropColumn("dbo.AccountHeads", "IsBalanceSheet");
            DropColumn("dbo.AccountHeads", "IsBankHead");
            DropColumn("dbo.AccountHeads", "IsCashHead");
            DropColumn("dbo.AccountHeads", "IsPostingHead");
            DropColumn("dbo.AccountHeads", "Description");
            DropColumn("dbo.AccountHeads", "AccountHeadName");
            DropColumn("dbo.AccountHeads", "ParentAccountHeadId");
            DropColumn("dbo.AccountHeads", "CompanyId");
            DropTable("dbo.Vouchers");
            DropTable("dbo.VoucherDetails");
        }
    }
}
