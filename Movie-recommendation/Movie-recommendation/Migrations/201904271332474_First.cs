namespace Movie_recommendation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MSBD2.favourite_movies",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(maxLength: 128),
                        movie_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("MSBD2.movies", t => t.movie_id)
                .ForeignKey("MSBD2.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.movie_id);
            
            CreateTable(
                "MSBD2.movies",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        title = c.String(maxLength: 100, unicode: false),
                        director = c.String(nullable: false),
                        is_drama = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_comedy = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_thriller = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_horror = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_action = c.Decimal(nullable: false, precision: 1, scale: 0),
                        for_kids = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_fantasy = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_historical = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_crime = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_musical = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_sf = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.title);
            
            CreateTable(
                "MSBD2.ratings",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(maxLength: 128),
                        movie_id = c.String(maxLength: 128),
                        rating = c.Decimal(nullable: false, precision: 3, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("MSBD2.movies", t => t.movie_id)
                .ForeignKey("MSBD2.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.movie_id);
            
            CreateTable(
                "MSBD2.users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(maxLength: 20, unicode: false),
                        password = c.String(nullable: false, maxLength: 15),
                        first_logging = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.name);
            
            CreateTable(
                "MSBD2.recommended_movies",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(maxLength: 128),
                        movie_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("MSBD2.movies", t => t.movie_id)
                .ForeignKey("MSBD2.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.movie_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MSBD2.favourite_movies", "user_id", "MSBD2.users");
            DropForeignKey("MSBD2.favourite_movies", "movie_id", "MSBD2.movies");
            DropForeignKey("MSBD2.ratings", "user_id", "MSBD2.users");
            DropForeignKey("MSBD2.recommended_movies", "user_id", "MSBD2.users");
            DropForeignKey("MSBD2.recommended_movies", "movie_id", "MSBD2.movies");
            DropForeignKey("MSBD2.ratings", "movie_id", "MSBD2.movies");
            DropIndex("MSBD2.recommended_movies", new[] { "movie_id" });
            DropIndex("MSBD2.recommended_movies", new[] { "user_id" });
            DropIndex("MSBD2.users", new[] { "name" });
            DropIndex("MSBD2.ratings", new[] { "movie_id" });
            DropIndex("MSBD2.ratings", new[] { "user_id" });
            DropIndex("MSBD2.movies", new[] { "title" });
            DropIndex("MSBD2.favourite_movies", new[] { "movie_id" });
            DropIndex("MSBD2.favourite_movies", new[] { "user_id" });
            DropTable("MSBD2.recommended_movies");
            DropTable("MSBD2.users");
            DropTable("MSBD2.ratings");
            DropTable("MSBD2.movies");
            DropTable("MSBD2.favourite_movies");
        }
    }
}
