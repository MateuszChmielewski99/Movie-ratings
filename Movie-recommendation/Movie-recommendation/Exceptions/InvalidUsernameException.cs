using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.Exceptions
{
    class InvalidUsernameException : Exception 
    {
        public InvalidUsernameException(): base()
        {
        }

        public InvalidUsernameException(string message)
            : base(message)
        {
        }

        public InvalidUsernameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
