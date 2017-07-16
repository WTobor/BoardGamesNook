using System;
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
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.Add(GetTestGamer(newGamerId));
            var gamers = gamerService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamersCount + 1, gamers.Count());
        }

        [TestMethod]
        public void GetGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.Add(GetTestGamer(newGamerId));
            var gamer = gamerService.Get(newGamerId);
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(lastAddedGamer?.Id, gamer.Id);
        }

        [TestMethod]
        public void GetByEmail()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            var testGamer = GetTestGamer(newGamerId);
            gamerService.Add(testGamer);
            var gamer = gamerService.GetByEmail(testGamer.Email);
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(lastAddedGamer?.Id, gamer.Id);
        }

        [TestMethod]
        public void GetByNick()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            var testGamer = GetTestGamer(newGamerId);
            var testNick = Guid.NewGuid().ToString();
            testGamer.Nick = testNick;
            //Act
            gamerService.Add(testGamer);
            var gamer = gamerService.GetByNick(testNick);
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(lastAddedGamer?.Id, gamer.Id);
        }

        [TestMethod]
        public void ExistsGamerNick()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.Add(GetTestGamer(newGamerId));
            var nickExists = gamerService.NickExists(GetTestGamer(newGamerId)?.Nick);
            //Assert
            Assert.AreEqual(true, nickExists);
        }

        [TestMethod]
        public void EditGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            string name = "test2";
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.Add(GetTestGamer(newGamerId));
            var gamer = gamerService.Get(newGamerId);
            gamer.Name = name;
            gamerService.Edit(gamer);
            var newGamer = gamerService.Get(newGamerId);
            //Assert
            Assert.AreEqual(name, newGamer.Name);
        }

        [TestMethod]
        public void DeactivateGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.Add(GetTestGamer(newGamerId));
            gamerService.Deactivate(newGamerId.ToString());
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(false, lastAddedGamer.Active);
        }

        private static Gamer GetTestGamer(string gamerId)
        {
            return new Gamer()
            {
                Id = gamerId,
                Nick = "test",
                Name = "test",
                Email = $"{gamerId}@test.pl"
            };
        }
    }
}