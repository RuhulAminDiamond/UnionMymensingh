namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_ranovation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessUnits", "OrgId", "dbo.OrganizationInfoes");
            DropForeignKey("dbo.VoucherDetails", "VMId", "dbo.Vouchers");
            DropIndex("dbo.BusinessUnits", new[] { "OrgId" });
            DropIndex("dbo.VoucherDetails", new[] { "VMId" });
          //  DropPrimaryKey("dbo.VoucherDetails");
          //  DropPrimaryKey("dbo.Vouchers");
            AddColumn("dbo.Expenses", "BusinessUnitId", c => c.Int(nullable: false));
            AddColumn("dbo.Vouchers", "VTime", c => c.String());
           // AlterColumn("dbo.VoucherDetails", "Id", c => c.Long(nullable: false, identity: true));
           // AlterColumn("dbo.VoucherDetails", "VMId", c => c.Long(nullable: false));
          //  AlterColumn("dbo.Vouchers", "VMId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Vouchers", "CompanyId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VoucherDetails", "Id");
            AddPrimaryKey("dbo.Vouchers", "VMId");
            CreateIndex("dbo.Expenses", "BusinessUnitId");
            CreateIndex("dbo.VoucherDetails", "VMId");
            AddForeignKey("dbo.Expenses", "BusinessUnitId", "dbo.BusinessUnits", "BusinessUnitId", cascadeDelete: true);
            AddForeignKey("dbo.VoucherDetails", "VMId", "dbo.Vouchers", "VMId", cascadeDelete: true);
            DropColumn("dbo.BusinessUnits", "OrgId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessUnits", "OrgId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VoucherDetails", "VMId", "dbo.Vouchers");
            DropForeignKey("dbo.Expenses", "BusinessUnitId", "dbo.BusinessUnits");
            DropIndex("dbo.VoucherDetails", new[] { "VMId" });
            DropIndex("dbo.Expenses", new[] { "BusinessUnitId" });
            DropPrimaryKey("dbo.Vouchers");
           // DropPrimaryKey("dbo.VoucherDetails");
            AlterColumn("dbo.Vouchers", "CompanyId", c => c.Short(nullable: false));
            AlterColumn("dbo.Vouchers", "VMId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.VoucherDetails", "VMId", c => c.Int(nullable: false));
            AlterColumn("dbo.VoucherDetails", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Vouchers", "VTime");
            DropColumn("dbo.Expenses", "BusinessUnitId");
            AddPrimaryKey("dbo.Vouchers", "VMId");
            AddPrimaryKey("dbo.VoucherDetails", "Id");
            CreateIndex("dbo.VoucherDetails", "VMId");
            CreateIndex("dbo.BusinessUnits", "OrgId");
            AddForeignKey("dbo.VoucherDetails", "VMId", "dbo.Vouchers", "VMId", cascadeDelete: true);
            AddForeignKey("dbo.BusinessUnits", "OrgId", "dbo.OrganizationInfoes", "OrgId", cascadeDelete: true);
        }
    }
}
