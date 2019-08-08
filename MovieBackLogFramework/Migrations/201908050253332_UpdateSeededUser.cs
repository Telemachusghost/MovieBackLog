namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeededUser : DbMigration
    {
        public override void Up()
        {
            // This is essentially what needs to happen when a new user is created
            Sql("INSERT INTO BackLogs DEFAULT VALUES");
            
        }
        
        public override void Down()
        {
        }
    }
}
