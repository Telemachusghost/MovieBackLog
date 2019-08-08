namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeededUser2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET BackLog_Id = 8 WHERE Id = '0f66b55a-3e6f-4fdf-a5b2-5e078c91d53c'");
            Sql("INSERT INTO MovieBackLogs (Movie_MovieId, BackLog_Id) VALUES (1,  8)");
        }
        
        public override void Down()
        {
        }
    }
}
