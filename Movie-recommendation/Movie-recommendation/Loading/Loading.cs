using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<string> LoadUser(string name, string password)
        {
            var x =  await unit.userRepository.GetAsync(s => s.name == name);
            bool passwordMatch = x.Any(s => s.password == password);
            if (x == null)
                return "User with this name does not exists";

            if (!passwordMatch)
            {
                return "Username or password are not correct";
            }

            return "OK";
        }
    }
}
