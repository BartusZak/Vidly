namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class byte_instock2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Kupa", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Kupa");
        }
    }
}
