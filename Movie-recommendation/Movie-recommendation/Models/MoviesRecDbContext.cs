namespace Movie_recommendation
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesRecDbContext : DbContext
    {

        #region DBSets
        public DbSet<User> Users { set; get; }
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Rating> Ratings { set; get; }
        public DbSet<FavouriteMovies> FavouriteMovies { set; get; }
        #endregion

        public MoviesRecDbContext(): base("name=MoviesRecDb")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("MSBD2");
        }

    }
}