namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strongergenremovierelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "Movie_MovieId" });
            RenameColumn(table: "dbo.Genres", name: "Movie_MovieId", newName: "MovieRefId");
            AlterColumn("dbo.Genres", "MovieRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Genres", "MovieRefId");
            AddForeignKey("dbo.Genres", "MovieRefId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "MovieRefId", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "MovieRefId" });
            AlterColumn("dbo.Genres", "MovieRefId", c => c.Int());
            RenameColumn(table: "dbo.Genres", name: "MovieRefId", newName: "Movie_MovieId");
            CreateIndex("dbo.Genres", "Movie_MovieId");
            AddForeignKey("dbo.Genres", "Movie_MovieId", "dbo.Movies", "MovieId");
        }
    }
}
