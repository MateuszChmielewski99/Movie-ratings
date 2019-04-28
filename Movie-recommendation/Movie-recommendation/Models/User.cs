using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Movie_recommendation
{
    /// <summary>
    /// User model class
    /// </summary>

    [Table("MSBD2.users")]
    public class User
    {
        /// <summary>
        /// user unique id
        /// </summary>
        [Key]
        public string id { set; get; }
        /// <summary>
        /// user name, min length = 4 and max is 20
        /// </summary>
        [Column(TypeName = "VARCHAR2")]
        [StringLength( maximumLength: 20,MinimumLength = 4)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).{4,15}$",ErrorMessage ="User name must constain lower and upper case letters")]
        [Index]
        public string name { set; get; }
        /// <summary>
        /// user password, it must be longer then 5 characters and contains small and capital letters 
        /// and numbers as well
        /// </summary>
        [StringLength(maximumLength: 15, MinimumLength = 5)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,15}$")]
        [Required]
        public string password { set; get; }

        /// <summary>
        /// check if user was logged before to show corect window 
        /// </summary>
        [DefaultValue(true)]
        public bool first_logging { set; get; }

        /// <summary>
        /// N:M relation 
        /// </summary>
        public ICollection<FavouriteMovies> favouriteMovies { set; get; }
        public ICollection<Rating> ratings { set; get; }
        public ICollection<RecommendedMovies> recommendedMovies { set; get; }


    }
}
