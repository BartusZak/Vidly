namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamesToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE MembershipTypes SET Name = 'Płać i korzystaj' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Miesięczne' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Kwartalne' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Roczne' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
