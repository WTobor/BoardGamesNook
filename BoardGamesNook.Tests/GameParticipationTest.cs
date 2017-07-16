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
    public class GameParticipationTest
    {
        [TestMethod]
        public void GetGameParticipationList()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var generatedGameParticipationsCount = GameParticipationGenerator.gameParticipations.Count;
            //Act
            var gameParticipations = gameParticipationService.GetAll();
            //Assert
            Assert.AreEqual(generatedGameParticipationsCount, gameParticipations.Count());
        }

        [TestMethod]
        public void AddGameParticipationToGameParticipationsList()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var generatedGameParticipationsCount = GameParticipationGenerator.gameParticipations.Count;
            //Act
            gameParticipationService.Add(GetTestGameParticipation());
            var gameParticipations = gameParticipationService.GetAll();
            //Assert
            Assert.AreEqual(generatedGameParticipationsCount + 1, gameParticipations.Count());
        }

        [TestMethod]
        public void GetGameParticipation()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var newGameParticipationId = GameParticipationGenerator.gameParticipations.Max(x => x.Id) + 1;
            //Act
            gameParticipationService.Add(GetTestGameParticipation());
            var boardGame = gameParticipationService.Get(newGameParticipationId);
            //Assert
            Assert.AreEqual(newGameParticipationId, boardGame.Id);
        }

        [TestMethod]
        public void EditGameParticipation()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var newGameParticipationId = GameParticipationGenerator.gameParticipations.Max(x => x.Id) + 1;
            DateTimeOffset now = DateTimeOffset.UtcNow;
            //Act
            gameParticipationService.Add(GetTestGameParticipation());
            var gameParticipation = gameParticipationService.Get(newGameParticipationId);
            gameParticipation.ModifiedDate = now;
            gameParticipationService.Edit(gameParticipation);
            var newGameParticipation = gameParticipationService.Get(newGameParticipationId);
            //Assert
            Assert.AreEqual(now, newGameParticipation.ModifiedDate);
        }

        [TestMethod]
        public void DeleteGameParticipation()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var generatedGameParticipationsCount = GameParticipationGenerator.gameParticipations.Count;
            var newGameParticipationId = GameParticipationGenerator.gameParticipations.Max(x => x.Id) + 1;
            //Act
            gameParticipationService.Add(GetTestGameParticipation());
            gameParticipationService.Delete(newGameParticipationId);
            var gameParticipations = gameParticipationService.GetAll();
            //Assert
            Assert.AreEqual(generatedGameParticipationsCount, gameParticipations.Count());
        }

        private static GameParticipation GetTestGameParticipation()
        {
            var newGameParticipationId = GameParticipationGenerator.gameParticipations.Max(x => x.Id) + 1;
            return new GameParticipation()
            {
                Id = newGameParticipationId,
                GameTableId = GameTableGenerator.gameTable1.Id,
                GameTable = GameTableGenerator.gameTable1,
                GamerId = GamerGenerator.gamer1.Id,
                Gamer = GamerGenerator.gamer1
            };
        }
    }
}