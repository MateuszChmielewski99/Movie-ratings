using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    public static class UserRepositoryHelper
    {
        public static async Task<User> GetByNameAsync(this GenericRepository<User>genericRepository, string name)
        {
            MoviesRecDbContext context = new MoviesRecDbContext();
            DbSet<User> user = context.Set<User>();

            return await user.FirstOrDefaultAsync(s => s.name == name);
        }
    }
}
