namespace FakeDatabse
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserModelDbContext : DbContext
    {
        public DbSet<User> users { set; get; }
        public DbSet<Movie> movies { set; get; }

        public UserModelDbContext()
            : base("name=UserModel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}