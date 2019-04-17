using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_recommendation
{
    /// <summary>
    /// Movie ratings class
    /// </summary>

    [Table("MSBD2.ratings")]
    public class Rating
    {
        /// <summary>
        /// id of a rating
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
        public string movie_id { set; get; }

        /// <summary>
        /// rate that user add for a movie 
        /// </summary>
        [Required]
        public byte rating { set; get; }
        /// <summary>
        /// N:M relation
        /// </summary>
        public User user { set; get; }

        public Movie movie { set; get; }
    }
}
