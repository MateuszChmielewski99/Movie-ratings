using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    [Table("MSBD2.recommended_movies")]
    public class RecommendedMovies
    {
        /// <summary>
        /// table id 
        /// </summary>
        [Key]
        public string id { set; get; }
        /// <summary>
        /// user id
        /// </summary>
        [ForeignKey("user")]
        public string user_id { set; get; }
        /// <summary>
        /// id of a movie that was recommended to user
        /// </summary>
        [ForeignKey("movie")]
        public string movie_id { set; get; }

        public User user { set; get; }

        public Movie movie { set; get; }
    }
}
