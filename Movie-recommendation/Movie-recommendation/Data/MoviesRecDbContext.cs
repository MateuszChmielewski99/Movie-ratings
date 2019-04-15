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

        public MoviesRecDbContext(): base("name=MoviesRecDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(s => s.id);
            modelBuilder.Entity<Movie>().HasKey(s => s.id);
            modelBuilder.Entity<User>().HasIndex(s => s.name);
            modelBuilder.Entity<Movie>().HasIndex(s => s.name);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}