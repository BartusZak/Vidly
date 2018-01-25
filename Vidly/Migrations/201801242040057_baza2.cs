namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baza2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "Surname", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Surname", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
        }
    }
}
