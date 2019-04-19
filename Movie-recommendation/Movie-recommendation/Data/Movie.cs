using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Movie_recommendation
{
    /// <summary>
    /// Movie model 
    /// </summary>
    [Table("MSBD2.movies")]
    public class Movie
    {
        /// <summary>
        /// movie unique id
        /// </summary>
        [Key]
        public string id { set; get; }
        /// <summary>
        /// movie name
        /// </summary>
        [Column(TypeName = "VARCHAR2")]
        [StringLength(100)]
        [Index]
        public string title { set; get; }
        /// <summary>
        /// movie director
        /// </summary>
        public string director { set; get; }

        // to do, image of a movie!

        /// <summary>
        /// N : M relations 
        /// </summary>
        public ICollection<FavouriteMovies> favouriteMovies { set; get; }
        public ICollection<Rating> ratings { set; get; }

        /// <summary>
        /// movie categories to classification
        /// </summary>
        #region movie categories
        public bool is_drama { set; get; }

        public bool is_comedy { set; get; }

        public bool is_thriller { set; get; }

        public bool is_horror { set; get; }

        public bool is_action { set; get; }

        public bool for_kids { set; get; }

        public bool is_fantasy { set; get; }

        public bool is_historical { set; get; }

        public bool is_crime { set; get; }

        public bool is_musical { set; get; }

        public bool is_sf { set; get; }

        #endregion
    }
}
