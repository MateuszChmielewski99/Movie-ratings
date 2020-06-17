namespace Movie_recommendation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MSBD40.favourite_movies",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(maxLength: 128),
                        movie_id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("MSBD40.movies", t => t.movie_id, cascadeDelete: true)
                .ForeignKey("MSBD40.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.movie_id, unique: true);
            
            CreateTable(
                "MSBD40.movies",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Title = c.String(maxLength: 100, unicode: false),
                        Director = c.String(nullable: false),
                        ImageURI = c.String(nullable: false),
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "MSBD40.ratings",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(maxLength: 128),
                        movie_id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        rating = c.Decimal(nullable: false, precision: 3, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("MSBD40.movies", t => t.movie_id, cascadeDelete: true)
                .ForeignKey("MSBD40.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.movie_id);
            
            CreateTable(
                "MSBD40.users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(maxLength: 20, unicode: false),
                        password = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.name, unique: true);
            
            CreateTable(
                "MSBD40.recommended_movies",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(maxLength: 128),
                        movie_id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("MSBD40.movies", t => t.movie_id, cascadeDelete: true)
                .ForeignKey("MSBD40.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.movie_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MSBD40.favourite_movies", "user_id", "MSBD40.users");
            DropForeignKey("MSBD40.favourite_movies", "movie_id", "MSBD40.movies");
            DropForeignKey("MSBD40.ratings", "user_id", "MSBD40.users");
            DropForeignKey("MSBD40.recommended_movies", "user_id", "MSBD40.users");
            DropForeignKey("MSBD40.recommended_movies", "movie_id", "MSBD40.movies");
            DropForeignKey("MSBD40.ratings", "movie_id", "MSBD40.movies");
            DropIndex("MSBD40.recommended_movies", new[] { "movie_id" });
            DropIndex("MSBD40.recommended_movies", new[] { "user_id" });
            DropIndex("MSBD40.users", new[] { "name" });
            DropIndex("MSBD40.ratings", new[] { "movie_id" });
            DropIndex("MSBD40.ratings", new[] { "user_id" });
            DropIndex("MSBD40.favourite_movies", new[] { "movie_id" });
            DropIndex("MSBD40.favourite_movies", new[] { "user_id" });
            DropTable("MSBD40.recommended_movies");
            DropTable("MSBD40.users");
            DropTable("MSBD40.ratings");
            DropTable("MSBD40.movies");
            DropTable("MSBD40.favourite_movies");
        }
    }
}
