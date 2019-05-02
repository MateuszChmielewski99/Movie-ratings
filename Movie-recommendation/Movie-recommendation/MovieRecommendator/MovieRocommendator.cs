using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.MovieRecommendator
{
    enum categories
    {
        is_action,
        is_comedy
    }
    class MovieRocommendator
    {
        private double MeasureSimmilarity(Movie firstMovie, Movie secondMovie)
        {
            double result = 0;

            return result /13;
        }
        public async Task RecommendAsync(ICollection<Movie> movies)
        {
            UnitOfWork unit = new UnitOfWork();
            var allMovies = await unit.movieRepository.GetAsync();
            foreach (Movie movie in movies)
            {
                foreach (Movie innerMovie in allMovies)
                {
                    MeasureSimmilarity(movie, innerMovie);
                }
            }
        }
    }
}
