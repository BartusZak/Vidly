namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Genres (id, Name) VALUES (1, 'Krymina?')");
            Sql("INSERT INTO Genres (id, Name) VALUES (2, 'Komedia')");
            Sql("INSERT INTO Genres (id, Name) VALUES (3, 'Horror')");
            Sql("INSERT INTO Genres (id, Name) VALUES (4, 'Obyczajowy')");
            Sql("INSERT INTO Genres (id, Name) VALUES (5, 'Animowany')");
            Sql("INSERT INTO Genres (id, Name) VALUES (6, 'Thriller')");
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
