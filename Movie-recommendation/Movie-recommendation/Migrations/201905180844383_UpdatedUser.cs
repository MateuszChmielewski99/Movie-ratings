namespace Movie_recommendation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("MSBD2.favourite_movies", new[] { "movie_id" });
            CreateIndex("MSBD2.favourite_movies", "movie_id", unique: true);
            DropColumn("MSBD2.users", "first_logging");
        }
        
        public override void Down()
        {
            AddColumn("MSBD2.users", "first_logging", c => c.Decimal(nullable: false, precision: 1, scale: 0));
            DropIndex("MSBD2.favourite_movies", new[] { "movie_id" });
            CreateIndex("MSBD2.favourite_movies", "movie_id");
        }
    }
}
