using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.MovieRecommendator
{
   
    public class MovieRocommendator : IRecommendator
    {
        private readonly UnitOfWork unit;

        public MovieRocommendator(UnitOfWork unit)
        {
            this.unit = unit;
        }

        /// <summary>
        /// Measure simmilarity of two movies based on metadata
        /// </summary>
        /// <param name="firstMovie"></param>
        /// <param name="secondMovie"></param>
        /// <returns></returns>
        public double MeasureSimmilarity(Movie firstMovie, Movie secondMovie)
        {
            double result = 0;
            int sumF = 0;
            int sumS = 0;
            int tmp1 = 0;
            int tmp2 = 0;

            foreach (PropertyInfo prop in typeof(Movie).GetProperties())
            {

                if (prop.PropertyType == typeof(bool))
                {
                    tmp1 = Convert.ToInt32(prop.GetValue(firstMovie));
                    sumF += tmp1;
                    tmp2 = Convert.ToInt32(prop.GetValue(secondMovie));
                    sumS += tmp2;

                    result += (Math.Min(tmp1,tmp2));
                }
            }

            result /= Math.Min(sumF, sumS); 

            return result;
        }

        /// <summary>
        /// Recommends movies based on metadata
        /// </summary>
        /// <param name="movies">Collection of movies on which recommendation will take place </param>
        /// <returns> ICollection of top 3 recommended movies </returns>
        public async Task<IEnumerable<Movie>>RecommendAsync(ICollection<Movie> movies)
        {
            var allMovies = await unit.movieRepository.GetAsync();
            Movie m = new Movie();
      


            SortedDictionary<double, Movie> topMovies = new SortedDictionary<double, Movie>();
            double simmilarity = 0;


            foreach (Movie movie in movies)
            {
                foreach (Movie innerMovie in allMovies)
                {
                    if (!movie.Equals(innerMovie))
                    {
                        simmilarity = MeasureSimmilarity(movie, innerMovie);
                        if (simmilarity > 0.9)
                            topMovies.Add(simmilarity, innerMovie);
                    }
                }
            }

             

            return topMovies.Values.Take(3);
        }
    }
}
