using System;
using System.Collections.Generic;
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
        /// user name
        /// </summary>
        [Column(TypeName = "VARCHAR2")]
        [StringLength(50)]
        [Index]
        public string name { set; get; }
        /// <summary>
        /// user password
        /// </summary>
        public string password { set; get; }

        /// <summary>
        /// check if user was logged before to show corect window 
        /// </summary>
        public bool first_logging { set; get; }
        /// <summary>
        /// N:M relation 
        /// </summary>
        public ICollection<FavouriteMovies> favouriteMovies { set; get; }
        public ICollection<Rating> ratings { set; get; }


    }
}
