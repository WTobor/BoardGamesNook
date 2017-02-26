using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerServiceTest
    {
        [TestMethod]
        public void GetEmptyGamersList()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            //Act
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(0, gamers.Count());
        }

        [TestMethod]
        public void AddGamerToEmptyGamersList()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            //Act
            gamerService.Add(GetTestGamer());
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(1, gamers.Count());
        }

        [TestMethod]
        public void GetGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            //Act
            gamerService.Add(GetTestGamer());
            var gamer = gamerService.Get(1);
            //Assert
            Assert.AreEqual(1, gamer.Id);
        }

        [TestMethod]
        public void EditGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            string name = "test2";
            //Act
            gamerService.Add(GetTestGamer());
            var gamer = gamerService.Get(1);
            gamer.Name = name;
            gamerService.Edit(gamer);
            var newGamer = gamerService.Get(1);
            //Assert
            Assert.AreEqual(name, newGamer.Name);
        }

        [TestMethod]
        public void DeleteGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            //Act
            gamerService.Add(GetTestGamer());
            gamerService.Delete(1);
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(0, gamers.Count());
        }
        
        private static Gamer GetTestGamer()
        {
            return new Gamer()
            {
                Id = 1,
                Name = "test"
            };
        }
    }
}