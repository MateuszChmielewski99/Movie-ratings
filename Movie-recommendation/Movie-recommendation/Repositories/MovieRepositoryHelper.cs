using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.Repositories
{
    public static class MovieRepositoryHelper
    {
        public static async Task<Movie> GetByTitle(this GenericRepository<Movie> genericRepository, string title)
        {
            MoviesRecDbContext context = new MoviesRecDbContext();
            return await context.Movies.FirstOrDefaultAsync(s => s.Title == title);
        }
    }
}
