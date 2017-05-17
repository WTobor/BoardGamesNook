using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public void Login()
        {
            //Arrange
            var accountService = new AccountService(new AccountRepository());
            var userService = new UserService(new UserRepository());
            var login = "testLogin";
            var password = "testPsswd";

            //Act
            userService.Add(GetTestUser(login, password));
            bool loggedIn = accountService.Login(login, password);
            //Assert
            Assert.AreEqual(true, loggedIn);
        }

        [TestMethod]
        public void IsLoginAllowed()
        {
            //Arrange
            var accountService = new AccountService(new AccountRepository());
            var userService = new UserService(new UserRepository());
            var login = "testLogin";
            var password = "testPsswd";

            //Act
            userService.Add(GetTestUser(login, password));
            bool loginAllowed = accountService.IsLoginAllowed(login);
            //Assert
            Assert.AreEqual(false, loginAllowed);
        }

        private static User GetTestUser(string login, string password)
        {
            var newUserId = UserGenerator.users.Max(x => x.Id) + 1;
            return new User()
            {
                Id = newUserId,
                Login = login,
                Password = password,
                IsConfirmed = true,
                Active = true
            };
        }
    }
}
