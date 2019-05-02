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
        public async Task<string> LoadUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return "Empty field!";
            }

            // name is unique, using any will not cause any trouble 
            var x =  await unit.userRepository.GetAsync(s => s.name == name);
            bool passwordMatch = x.Any(s => s.password == password);
            if (x.Count() == 0)
            {
                unit.Dispose();
                return "User with this name does not exists.";
            }
            if (!passwordMatch)
            {
                unit.Dispose();
                return "Username or password are not correct.";
            }

            unit.Dispose();
            return "ok";
        }
    }
}
