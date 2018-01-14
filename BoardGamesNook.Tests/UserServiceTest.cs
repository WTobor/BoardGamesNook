using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        //[TestMethod]
        //public void GetUsersList()
        //{
        //    //Arrange
        //    var userService = new UserService(new UserRepository());
        //    var generatedUsersCount = UserGenerator.users.Count;
        //    //Act
        //    var users = userService.GetAllGameTables();
        //    //Assert
        //    Assert.AreEqual(generatedUsersCount, users.Count());
        //}

        //[TestMethod]
        //public void AddUserToUsersList()
        //{
        //    //Arrange
        //    var userService = new UserService(new UserRepository());
        //    var generatedUsersCount = UserGenerator.users.Count;
        //    //Act
        //    userService.AddGameTable(GetTestUser());
        //    var users = userService.GetAllGameTables();
        //    //Assert
        //    Assert.AreEqual(generatedUsersCount + 1, users.Count());
        //}

        //[TestMethod]
        //public void GetUser()
        //{
        //    //Arrange
        //    var userService = new UserService(new UserRepository());
        //    var generatedUsersCount = UserGenerator.users.Count;
        //    var newUserId = UserGenerator.users.Max(x => x.Id) + 1;
        //    //Act
        //    userService.AddGameTable(GetTestUser());
        //    var user = userService.GetGameTable(newUserId);
        //    //Assert
        //    Assert.AreEqual(generatedUsersCount + 1, user.Id);
        //}

        //[TestMethod]
        //public void EditUser()
        //{
        //    //Arrange
        //    var userService = new UserService(new UserRepository());
        //    string login = "cde";
        //    var newUserId = UserGenerator.users.Max(x => x.Id) + 1;
        //    //Act
        //    userService.AddGameTable(GetTestUser());
        //    var user = userService.GetGameTable(newUserId);
        //    user.Login = login;
        //    userService.EditGameTable(user);
        //    var newUser = userService.GetGameTable(newUserId);
        //    //Assert
        //    Assert.AreEqual(login, newUser.Login);
        //}

        //[TestMethod]
        //public void DeleteUser()
        //{
        //    //Arrange
        //    var userService = new UserService(new UserRepository());
        //    var generatedUsersCount = UserGenerator.users.Count;
        //    var newUserId = UserGenerator.users.Max(x => x.Id) + 1;
        //    //Act
        //    userService.AddGameTable(GetTestUser());
        //    userService.DeleteGameTable(newUserId);
        //    var users = userService.GetAllGameTables();
        //    //Assert
        //    Assert.AreEqual(generatedUsersCount, users.Count());
        //}

        //private static User GetTestUser()
        //{
        //    var newUserId = UserGenerator.users.Max(x => x.Id) + 1;
        //    return new User()
        //    {
        //        Id = newUserId,
        //        Login = "abc"
        //    };
        //}
    }
}