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
        public static string ID
        {
            get { return ID; }
            set
            {
                if (String.IsNullOrEmpty(ID))
                {
                    ID = value;
                }
                return;
            }
        }

    }
}
