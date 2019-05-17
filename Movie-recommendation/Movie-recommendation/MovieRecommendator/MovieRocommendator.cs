using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private double MeasureSimmilarity(Movie firstMovie, Movie secondMovie)
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
        public async Task<ICollection<Movie>>RecommendAsync(ICollection<Movie> movies)
        {
            var allMovies = await unit.movieRepository.GetAsync();

            Dictionary<Movie, double> topMovies = null;
            double simmilarity = 0;

            foreach (Movie movie in movies)
            {
                foreach (Movie innerMovie in allMovies)
                {
                    if (movie.ID != innerMovie.ID)
                    {
                        topMovies = new Dictionary<Movie, double>();
                        simmilarity = MeasureSimmilarity(movie, innerMovie);
                        if (simmilarity > 0.8) 
                            topMovies.Add(innerMovie, simmilarity);
                    }
                }
            }

           
            var ord = topMovies.OrderBy(s => s.Value);
            ICollection<Movie> toRet = new List<Movie>();

            foreach (KeyValuePair<Movie, double> kv in ord)
                toRet.Add(kv.Key);

            if (toRet.Count >= 3)
            {
                return toRet.Take(3).ToList();

            }
            else
            {
                return toRet.Take(topMovies.Count).ToList();
                // Made By Mastr of Mind
            }
        }
    }
}
