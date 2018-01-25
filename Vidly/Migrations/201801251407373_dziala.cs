namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dziala : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Kupa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Kupa", c => c.Byte(nullable: false));
        }
    }
}
