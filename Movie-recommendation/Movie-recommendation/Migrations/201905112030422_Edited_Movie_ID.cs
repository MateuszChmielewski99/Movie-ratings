namespace Movie_recommendation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edited_Movie_ID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("MSBD2.favourite_movies", "movie_id", "MSBD2.movies");
            DropForeignKey("MSBD2.ratings", "movie_id", "MSBD2.movies");
            DropForeignKey("MSBD2.recommended_movies", "movie_id", "MSBD2.movies");
            DropIndex("MSBD2.favourite_movies", new[] { "movie_id" });
            DropIndex("MSBD2.ratings", new[] { "movie_id" });
            DropIndex("MSBD2.recommended_movies", new[] { "movie_id" });
            DropPrimaryKey("MSBD2.movies");
            AlterColumn("MSBD2.favourite_movies", "movie_id", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("MSBD2.movies", "ID", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AlterColumn("MSBD2.ratings", "movie_id", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("MSBD2.recommended_movies", "movie_id", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AddPrimaryKey("MSBD2.movies", "ID");
            CreateIndex("MSBD2.favourite_movies", "movie_id");
            CreateIndex("MSBD2.ratings", "movie_id");
            CreateIndex("MSBD2.recommended_movies", "movie_id");
            AddForeignKey("MSBD2.favourite_movies", "movie_id", "MSBD2.movies", "ID", cascadeDelete: true);
            AddForeignKey("MSBD2.ratings", "movie_id", "MSBD2.movies", "ID", cascadeDelete: true);
            AddForeignKey("MSBD2.recommended_movies", "movie_id", "MSBD2.movies", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("MSBD2.recommended_movies", "movie_id", "MSBD2.movies");
            DropForeignKey("MSBD2.ratings", "movie_id", "MSBD2.movies");
            DropForeignKey("MSBD2.favourite_movies", "movie_id", "MSBD2.movies");
            DropIndex("MSBD2.recommended_movies", new[] { "movie_id" });
            DropIndex("MSBD2.ratings", new[] { "movie_id" });
            DropIndex("MSBD2.favourite_movies", new[] { "movie_id" });
            DropPrimaryKey("MSBD2.movies");
            AlterColumn("MSBD2.recommended_movies", "movie_id", c => c.String(maxLength: 128));
            AlterColumn("MSBD2.ratings", "movie_id", c => c.String(maxLength: 128));
            AlterColumn("MSBD2.movies", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("MSBD2.favourite_movies", "movie_id", c => c.String(maxLength: 128));
            AddPrimaryKey("MSBD2.movies", "ID");
            CreateIndex("MSBD2.recommended_movies", "movie_id");
            CreateIndex("MSBD2.ratings", "movie_id");
            CreateIndex("MSBD2.favourite_movies", "movie_id");
            AddForeignKey("MSBD2.recommended_movies", "movie_id", "MSBD2.movies", "ID");
            AddForeignKey("MSBD2.ratings", "movie_id", "MSBD2.movies", "ID");
            AddForeignKey("MSBD2.favourite_movies", "movie_id", "MSBD2.movies", "ID");
        }
    }
}
