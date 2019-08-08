namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popmovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Title, RunningTime, ReleaseYear) VALUES ('Gladiator', 120, 200)");
        }
        
        public override void Down()
        {
        }
    }
}
