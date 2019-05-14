using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    /// <summary>
    /// class to hold info about logged user
    /// </summary>
    [Serializable]    // serializable for futhure development and holding a session
    class LoggedUser
    {
        private static string _ID;
        public static string ID
        {
            get { return _ID; }
            set
            {
                if (String.IsNullOrEmpty(ID))
                {
                    _ID = value;
                }
                return;
            }
        }

    }
}
