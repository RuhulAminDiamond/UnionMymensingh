namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06032018m94 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "ContactPerson", c => c.String());
            AddColumn("dbo.RegRecords", "RelationWithPatient", c => c.String());
            AddColumn("dbo.RegRecords", "CPAddress", c => c.String());
            AddColumn("dbo.RegRecords", "CPMobile", c => c.String());
            AddColumn("dbo.RegRecords", "CPNationalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "CPNationalId");
            DropColumn("dbo.RegRecords", "CPMobile");
            DropColumn("dbo.RegRecords", "CPAddress");
            DropColumn("dbo.RegRecords", "RelationWithPatient");
            DropColumn("dbo.RegRecords", "ContactPerson");
        }
    }
}
