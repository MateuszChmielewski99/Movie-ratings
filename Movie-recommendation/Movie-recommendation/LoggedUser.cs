using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    [Serializable]
    class LoggedUser
    {
        public readonly string ID;

        public LoggedUser(string ID)
        {
            this.ID = ID;
        }
    }
}
