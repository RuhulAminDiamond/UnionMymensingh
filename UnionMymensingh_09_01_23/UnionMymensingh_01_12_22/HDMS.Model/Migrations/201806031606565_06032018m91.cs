namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06032018m91 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpParameterSetups",
                c => new
                    {
                        ParameterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        ParameterType = c.String(),
                    })
                .PrimaryKey(t => t.ParameterId);
            
            DropTable("dbo.HpAdmissionFees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HpAdmissionFees",
                c => new
                    {
                        HpAdmissionFeeId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.HpAdmissionFeeId);
            
            DropTable("dbo.HpParameterSetups");
        }
    }
}
