using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.UserEditor
{
    class UserEditor
    {
        private UnitOfWork unit;
        public UserEditor()
        {
            unit = new UnitOfWork();
        }

        public async Task UpdateAsync(string password)
        {
            User userToUpdate = await unit.userRepository.GetByIdAsync(LoggedUser.ID);
            userToUpdate.password = password;
            unit.userRepository.Update(userToUpdate);
            unit.Dispose();

        }

        public void DeleteUser()
        {
            unit.userRepository.dbSet.SqlQuery($"DELETE * FROM {"users"} WHERE id = {LoggedUser.ID} CASCADE CONSTRAINTS");
            unit.userRepository.context.SaveChanges();
            unit.Dispose();
        }
    }
}
