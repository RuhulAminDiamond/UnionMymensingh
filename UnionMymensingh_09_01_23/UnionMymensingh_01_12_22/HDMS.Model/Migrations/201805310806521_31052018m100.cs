namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31052018m100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicineOutlets",
                c => new
                    {
                        OutLetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OutLetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedicineOutlets");
        }
    }
}
