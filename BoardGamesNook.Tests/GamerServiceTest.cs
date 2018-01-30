using System;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var gamers = gamerService.GetAllGamers();
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
            gamerService.AddGamer(GetTestGamer(newGamerId));
            var gamers = gamerService.GetAllGamers();
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
            gamerService.AddGamer(GetTestGamer(newGamerId));
            var gamer = gamerService.GetGamer(newGamerId);
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
            gamerService.AddGamer(testGamer);
            var gamer = gamerService.GetGamerByEmail(testGamer.Email);
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(lastAddedGamer?.Id, gamer.Id);
        }

        [TestMethod]
        public void GetByNickname()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            var testGamer = GetTestGamer(newGamerId);
            var testNickname = Guid.NewGuid().ToString();
            testGamer.Nickname = testNickname;
            //Act
            gamerService.AddGamer(testGamer);
            var gamer = gamerService.GetGamerBoardGameByNickname(testNickname);
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(lastAddedGamer?.Id, gamer.Id);
        }

        [TestMethod]
        public void ExistsGamerNickname()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.AddGamer(GetTestGamer(newGamerId));
            var nicknameExists = gamerService.NicknameExists(GetTestGamer(newGamerId)?.Nickname);
            //Assert
            Assert.AreEqual(true, nicknameExists);
        }

        [TestMethod]
        public void EditGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var name = "test2";
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.AddGamer(GetTestGamer(newGamerId));
            var gamer = gamerService.GetGamer(newGamerId);
            gamer.Name = name;
            gamerService.EditGamer(gamer);
            var newGamer = gamerService.GetGamer(newGamerId);
            //Assert
            Assert.AreEqual(name, newGamer.Name);
            Assert.IsNotNull(newGamer.ModifiedDate);
        }

        [TestMethod]
        public void DeactivateGamer()
        {
            //Arrange
            var gamerService = new GamerService(new GamerRepository());
            var generatedGamersCount = GamerGenerator.gamers.Count;
            var newGamerId = Guid.NewGuid().ToString();
            //Act
            gamerService.AddGamer(GetTestGamer(newGamerId));
            gamerService.DeactivateGamer(newGamerId);
            var lastAddedGamer = GamerGenerator.gamers.LastOrDefault();
            //Assert
            Assert.AreEqual(false, lastAddedGamer.Active);
        }

        private static Gamer GetTestGamer(string gamerId)
        {
            return new Gamer
            {
                Id = gamerId,
                Nickname = "test",
                Name = "test",
                Email = $"{gamerId}@test.pl"
            };
        }
    }
}