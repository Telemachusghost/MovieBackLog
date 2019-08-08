namespace MovieBackLogFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoIncrementBacklogid : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE AspNetUsers ALTER COLUMN Backlog_Id INT AUTO_INCREMENT");
        }
        
        public override void Down()
        {
        }
    }
}
