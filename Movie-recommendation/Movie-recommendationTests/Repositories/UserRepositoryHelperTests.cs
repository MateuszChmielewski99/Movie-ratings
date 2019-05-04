using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Threading.Tasks;


namespace Movie_recommendation.Tests
{
    [TestClass()]
    public class UserRepositoryHelperTests
    {

        [TestMethod()]
        public void GetByNameAsyncTestAsync()
        {
            MoviesRecDbContext context = new MoviesRecDbContext();
            GenericRepository<User> userRepository = new GenericRepository<User>(context);

            
            Task t = Task.Run(async () =>
           {
               User testUser =  await userRepository.GetByNameAsync("FakeUser");
               User existingUser = await userRepository.GetByNameAsync("Dominika");
               Assert.IsNull(testUser);
               Assert.IsNotNull(existingUser);
           });

            
        }
    }
}