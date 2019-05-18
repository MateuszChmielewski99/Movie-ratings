namespace Movie_recommendation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedIndexFromFavouriteMovies : DbMigration
    {
        public override void Up()
        {
            DropIndex("MSBD2.movies", new[] { "Title" });
        }
        
        public override void Down()
        {
            CreateIndex("MSBD2.movies", "Title", unique: true);
        }
    }
}
