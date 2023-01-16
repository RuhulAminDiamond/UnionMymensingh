namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20042018m7 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.AccountHeads");
           // DropPrimaryKey("dbo.Vouchers");
            AddColumn("dbo.AccountHeads", "AccId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.VoucherDetails", "VMId", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherDetails", "AccId", c => c.Int(nullable: false));
            AddColumn("dbo.Vouchers", "VMId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AccountHeads", "AccId");
            AddPrimaryKey("dbo.Vouchers", "VMId");
            CreateIndex("dbo.VoucherDetails", "VMId");
            CreateIndex("dbo.VoucherDetails", "AccId");
            AddForeignKey("dbo.VoucherDetails", "AccId", "dbo.AccountHeads", "AccId", cascadeDelete: true);
            AddForeignKey("dbo.VoucherDetails", "VMId", "dbo.Vouchers", "VMId", cascadeDelete: true);
            DropColumn("dbo.AccountHeads", "Id");
            DropColumn("dbo.VoucherDetails", "VoucherMasterId");
            DropColumn("dbo.VoucherDetails", "PostingAccountHead");
            DropColumn("dbo.Vouchers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vouchers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.VoucherDetails", "PostingAccountHead", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherDetails", "VoucherMasterId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountHeads", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.VoucherDetails", "VMId", "dbo.Vouchers");
            DropForeignKey("dbo.VoucherDetails", "AccId", "dbo.AccountHeads");
            DropIndex("dbo.VoucherDetails", new[] { "AccId" });
            DropIndex("dbo.VoucherDetails", new[] { "VMId" });
            DropPrimaryKey("dbo.Vouchers");
            DropPrimaryKey("dbo.AccountHeads");
            DropColumn("dbo.Vouchers", "VMId");
            DropColumn("dbo.VoucherDetails", "AccId");
            DropColumn("dbo.VoucherDetails", "VMId");
            DropColumn("dbo.AccountHeads", "AccId");
            AddPrimaryKey("dbo.Vouchers", "Id");
            AddPrimaryKey("dbo.AccountHeads", "Id");
        }
    }
}
