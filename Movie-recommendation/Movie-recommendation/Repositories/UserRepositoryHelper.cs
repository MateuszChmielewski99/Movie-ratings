using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    public static class UserRepositoryHelper
    {
        public static async Task<User> GetByNameAsync(this GenericRepository<User>genericRepository, string name)
        {
            MoviesRecDbContext context = new MoviesRecDbContext();
            DbSet<User> user = context.Set<User>();

            return await user.FirstOrDefaultAsync(s => s.name == name);
        }

        public static async Task<ICollection<Movie>> GetUserMovies<T>(this GenericRepository<User> genericRepository, string id) where T : class
        {
            MoviesRecDbContext context = new MoviesRecDbContext();
            var user = await genericRepository.GetByIdAsync(id);
            dynamic movies = null;
            if (typeof(T) == typeof(FavouriteMovies))
            {
                DbSet<FavouriteMovies> dbSet = context.Set<FavouriteMovies>();
                 movies = from m in dbSet
                                      where m.user_id == LoggedUser.ID
                                      select new
                                      {
                                          m.movie
                                      };
            }
            if (typeof(T) == typeof(RecommendedMovies))
            {
                DbSet<RecommendedMovies> dbSet = context.Set<RecommendedMovies>();
                movies = from m in dbSet
                         where m.user_id == LoggedUser.ID
                         select new
                         {
                             m.movie
                         };
            }

            return movies;
        }

        public static int CountMovies(this GenericRepository<User> genericRepository, string id)
        {
            int count = 0;
            MoviesRecDbContext context = new MoviesRecDbContext();
            DbSet<RecommendedMovies> DbSet = context.Set<RecommendedMovies>();

            count = DbSet.Where(s => s.user_id == id).Count();
            return count;
        }
    }
}
