namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AddedDate");
        }
    }
}
