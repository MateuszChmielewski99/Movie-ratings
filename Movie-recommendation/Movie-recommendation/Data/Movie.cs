using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Movie_recommendation
{
    public class Movie
    {
        /// <summary>
        /// movie unique id
        /// </summary>
        public string id { set; get; }
       /// <summary>
       /// movie name
       /// </summary>
        public string name { set; get; }
        /// <summary>
        /// movie director
        /// </summary>
        public string director { set; get; }
        /// <summary>
        /// image of a movie
        /// </summary>
        public Image image { set; get; }

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
