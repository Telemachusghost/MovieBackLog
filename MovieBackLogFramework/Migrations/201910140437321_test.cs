namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "MovieRefId", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "MovieRefId" });
            RenameColumn(table: "dbo.Genres", name: "MovieRefId", newName: "Movie_MovieId");
            AlterColumn("dbo.Genres", "Movie_MovieId", c => c.Int());
            CreateIndex("dbo.Genres", "Movie_MovieId");
            AddForeignKey("dbo.Genres", "Movie_MovieId", "dbo.Movies", "MovieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "Movie_MovieId" });
            AlterColumn("dbo.Genres", "Movie_MovieId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Genres", name: "Movie_MovieId", newName: "MovieRefId");
            CreateIndex("dbo.Genres", "MovieRefId");
            AddForeignKey("dbo.Genres", "MovieRefId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
