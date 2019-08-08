namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitBackLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        RunningTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieBackLogs",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        BackLog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.BackLog_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .ForeignKey("dbo.BackLogs", t => t.BackLog_Id, cascadeDelete: true)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.BackLog_Id);
            
            AddColumn("dbo.AspNetUsers", "BackLog_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BackLog_Id");
            AddForeignKey("dbo.AspNetUsers", "BackLog_Id", "dbo.BackLogs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BackLog_Id", "dbo.BackLogs");
            DropForeignKey("dbo.MovieBackLogs", "BackLog_Id", "dbo.BackLogs");
            DropForeignKey("dbo.MovieBackLogs", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.MovieBackLogs", new[] { "BackLog_Id" });
            DropIndex("dbo.MovieBackLogs", new[] { "Movie_MovieId" });
            DropIndex("dbo.AspNetUsers", new[] { "BackLog_Id" });
            DropColumn("dbo.AspNetUsers", "BackLog_Id");
            DropTable("dbo.MovieBackLogs");
            DropTable("dbo.Movies");
            DropTable("dbo.BackLogs");
        }
    }
}
