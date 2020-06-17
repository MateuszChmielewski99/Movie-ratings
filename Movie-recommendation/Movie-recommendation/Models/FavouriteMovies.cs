using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Movie_recommendation
{
    /// <summary>
    /// Favourite movie model
    /// </summary>

    [Table("MSBD40.favourite_movies")]
    public class FavouriteMovies
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
        /// id of a movie that user liked
        /// </summary>
        [ForeignKey("movie")]
        [Index(IsUnique =true)]
        public int movie_id { set; get; }

        public User user { set; get; }

        public Movie movie { set; get; }


    }
}
