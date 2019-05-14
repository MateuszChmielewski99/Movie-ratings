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

            IQueryable<int> tmp = ( from s in favouriteMovies select s.movie_id ) as IQueryable<int>;

            IQueryable<Movie> movies = from m in unit.context.Movies where tmp.Contains(m.ID) select m;
            
            unit.Dispose();


            var moviez = from m in unit.context.FavouriteMovies
            where m.user_id == LoggedUser.ID
            select new 
            {
                m.movie
            };

            return moviez as ICollection<Movie>;
        }
    }
}
