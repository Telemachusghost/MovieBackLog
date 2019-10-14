namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Movie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "Movie_MovieId" });
            DropTable("dbo.Genres");
        }
    }
}
