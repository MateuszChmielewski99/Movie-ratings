using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    /// <summary>
    /// User registery class
    /// </summary>
    public class Register
    {
        private UnitOfWork unit;

        public Register()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Register user 
        /// </summary>
        /// <param name="user"> user to register </param>
        /// <returns> information if registration was successful </returns>
        public async Task<bool> RegisterUserAsync(User user)
        {
            var x = await unit.userRepository.GetAsync(s => s.name == user.name);
            if (x == null)
            {
                unit.userRepository.Insert(user);
                await unit.Save();
                unit.Dispose();
                return true;
            }

            unit.Dispose();
            return false;
        }

    }
}
