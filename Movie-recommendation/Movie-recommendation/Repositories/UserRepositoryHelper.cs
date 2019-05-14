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

        public static ICollection<Movie> GetUserFavouriteMovies(this GenericRepository<User> genericRepository, string id) 
        {
            MoviesRecDbContext context = new MoviesRecDbContext();

            var movies = from m in context.Movies
                         join fv in context.FavouriteMovies
                         on m.ID equals fv.movie_id
                         join u in context.Users
                         on fv.user_id equals u.id
                         where u.id == id
                         select m;                         

            return movies.ToList();
        }

        public static ICollection<Movie> GetUserRecommendedMovies(this GenericRepository<User> genericRepository, string id)
        {
            MoviesRecDbContext context = new MoviesRecDbContext();

            var movies = from m in context.Movies
                         join r in context.RecommendedMovies
                         on m.ID equals r.movie_id
                         join u in context.Users
                         on r.user_id equals u.id
                         where u.id == id
                         select m;

            return movies.ToList();
        }

        public static int CountMovies(this GenericRepository<User> genericRepository, string id)
        {
            int count = 0;
            MoviesRecDbContext context = new MoviesRecDbContext();

            count = context.RecommendedMovies.Where(s => s.user_id == id).Count();
            return count;
        }
    }
}
