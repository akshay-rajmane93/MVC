namespace Movieship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateinMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable=NumberInStock");//business logic
        }
        
        public override void Down()
        {
        }
    }
}
