namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name, Movie_MovieId) VALUES ('Action', 8)");
        }
        
        public override void Down()
        {
        }
    }
}
