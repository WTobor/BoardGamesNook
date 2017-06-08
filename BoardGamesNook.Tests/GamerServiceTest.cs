using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BoardGamesNook.Repository.Generators;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerServiceTest
    {
        [TestMethod]
        public void GetGamersList()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            //Act
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamersCount, gamers.Count());
        }

        [TestMethod]
        public void AddGamerToGamersList()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            //Act
            gamerService.Add(GetTestGamer());
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamersCount + 1, gamers.Count());
        }

        [TestMethod]
        public void GetGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            var newGamerId = GamerGenerator.gamers.Max(x => x.Id) + 1;
            //Act
            gamerService.Add(GetTestGamer());
            var gamer = gamerService.Get(newGamerId);
            //Assert
            Assert.AreEqual(generatedGamersCount + 1, gamer.Id);
        }

        [TestMethod]
        public void GetByEmail()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            var email = "test@test.pl";
            //Act
            gamerService.Add(GetTestGamer());
            var gamer = gamerService.GetByEmail(email);
            //Assert
            Assert.AreEqual(generatedGamersCount + 1, gamer.Id);
        }

        [TestMethod]
        public void EditGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            string name = "test2";
            var newGamerId = GamerGenerator.gamers.Max(x => x.Id) + 1;
            //Act
            gamerService.Add(GetTestGamer());
            var gamer = gamerService.Get(newGamerId);
            gamer.Name = name;
            gamerService.Edit(gamer);
            var newGamer = gamerService.Get(newGamerId);
            //Assert
            Assert.AreEqual(name, newGamer.Name);
        }

        [TestMethod]
        public void DeleteGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            var newGamerId = GamerGenerator.gamers.Max(x => x.Id) + 1;
            //Act
            gamerService.Add(GetTestGamer());
            gamerService.Delete(newGamerId);
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamersCount, gamers.Count());
        }

        private static Gamer GetTestGamer()
        {
            var newGamerId = GamerGenerator.gamers.Max(x => x.Id) + 1;
            return new Gamer()
            {
                Id = newGamerId,
                Name = "test",
                Email = "test@test.pl"
            };
        }
    }
}