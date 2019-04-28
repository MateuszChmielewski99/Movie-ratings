using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.Test
{
    class Test
    {

        public ICollection<Movie> getFavouriteMovies(ICollection<FavouriteMovies> favouriteMovies)
        {
            UnitOfWork unit = new UnitOfWork();

            IQueryable<string> tmp = ( from s in favouriteMovies select s.movie_id ) as IQueryable<string>;

            IQueryable<Movie> movies = from m in unit.context.Movies where tmp.Contains(m.id) select m;
            
            unit.Dispose();

            return movies as ICollection<Movie>;
        }
    }
}
