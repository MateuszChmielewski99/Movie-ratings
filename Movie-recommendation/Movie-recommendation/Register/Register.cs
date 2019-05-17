using Movie_recommendation.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Movie_recommendation
{
    /// <summary>
    /// User registery class
    /// </summary>
    public class Register
    {
        private UnitOfWork unit;
        private Regex passwordRegex;
        private Regex nameRegex;

        #region constructors
        public Register()
        {
            unit = new UnitOfWork();
            passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,15}$");
            nameRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z]).{4,15}$");
        }
        
        public Register(Regex password, Regex name)
        {
            passwordRegex = password;
            nameRegex = name;
        }
        #endregion

        /// <summary>
        /// Method to check if user name and password match regexs
        /// </summary>
        /// <param name="user"> user to check </param>
        public bool CheckUsernameAndPassword(string name, string password)
        {
           
            if (!nameRegex.IsMatch(name))
                throw new InvalidUsernameException();

            if (!passwordRegex.IsMatch(password))
                throw new InvalidPasswordException();

            return true;
        }

        /// <summary>
        /// Sign in user, using his name to check if he exists in Db 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> SignInAsync(User user)
        {
            User x = await unit.userRepository.GetByNameAsync(user.name);
            if (x == null)
            {
                unit.userRepository.Insert(user);
                unit.Save();
                unit.Dispose();
                return true;
            }
            else
            {
                unit.Dispose();
                throw new UserExistsException("User already exists!");
            }
        }

    }
}
