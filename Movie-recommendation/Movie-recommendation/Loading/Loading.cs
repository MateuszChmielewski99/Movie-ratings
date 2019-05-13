using Movie_recommendation.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    class Loading
    {
        private UnitOfWork unit;
        public Loading()
        {
            this.unit = new UnitOfWork();
        }
        /// <summary>
        /// Logging function, checks if username and password are correct  
        /// </summary>
        /// <param name="name"> User name </param>
        /// <param name="password">User's password </param>
        /// <returns> String that is a message about loading </returns>
        public async Task<bool>LoadUser(string name, string password)
        {
            // Check if fields are not empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new System.ArgumentNullException();
            }

            // Get user by his name
            var x = await unit.userRepository.GetByNameAsync(name);
            if (x == null)
            {
                unit.Dispose();
                throw new InvalidUsernameException("User does not exists!");
            }

            bool passwordMatch = x.password == password;
            if (!passwordMatch)
            {
                unit.Dispose();
                throw new InvalidPasswordException("Username or password are inccorect!");
            }

            unit.Dispose();
            return true;
        }

        
    }
}
