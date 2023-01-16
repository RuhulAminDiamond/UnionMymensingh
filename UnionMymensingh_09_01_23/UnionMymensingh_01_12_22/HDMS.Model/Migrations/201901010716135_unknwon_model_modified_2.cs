namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknwon_model_modified_2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Supplierid = c.Int(nullable: false, identity: true),
                        Suppliername = c.String(),
                        Address = c.String(),
                        Contactno = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Supplierid);
            
        }
    }
}
