using Movie_recommendation;
using System;
using Xunit;

namespace MovieRecomendationTest
{
    public class UnitTest1
    {
        [Fact]
        public async void UpdateUserTest()
        {
            UnitOfWork unit = new UnitOfWork();
            User user = new User
            {
                id = "test",
                name = "Test1",
                password = "Test1"
            };
            unit.userRepository.Insert(user);

            user.name = "Tomek";
            unit.userRepository.Update(user);

            User updatedUser = await unit.userRepository.GetByIdAsync("test");
            Assert.Equal("Tomek", updatedUser.name);
        }
    }
}
