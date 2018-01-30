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
            var generatedGameParticipationsCount = GameParticipationGenerator.GameParticipations.Count;
            //Act
            var gameParticipations = gameParticipationService.GetAllGameParticipations();
            //Assert
            Assert.AreEqual(generatedGameParticipationsCount, gameParticipations.Count());
        }

        [TestMethod]
        public void AddGameParticipationToGameParticipationsList()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var generatedGameParticipationsCount = GameParticipationGenerator.GameParticipations.Count;
            //Act
            gameParticipationService.AddGameParticipation(GetTestGameParticipation());
            var gameParticipations = gameParticipationService.GetAllGameParticipations();
            //Assert
            Assert.AreEqual(generatedGameParticipationsCount + 1, gameParticipations.Count());
        }

        [TestMethod]
        public void GetGameParticipation()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var newGameParticipationId = GameParticipationGenerator.GameParticipations.Max(x => x.Id) + 1;
            //Act
            gameParticipationService.AddGameParticipation(GetTestGameParticipation());
            var boardGame = gameParticipationService.GetGameParticipation(newGameParticipationId);
            //Assert
            Assert.AreEqual(newGameParticipationId, boardGame.Id);
        }

        [TestMethod]
        public void EditGameParticipation()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var newGameParticipationId = GameParticipationGenerator.GameParticipations.Max(x => x.Id) + 1;
            //Act
            gameParticipationService.AddGameParticipation(GetTestGameParticipation());
            var gameParticipation = gameParticipationService.GetGameParticipation(newGameParticipationId);
            gameParticipationService.Edit(gameParticipation);
            var newGameParticipation = gameParticipationService.GetGameParticipation(newGameParticipationId);
            //Assert
            Assert.AreEqual(newGameParticipationId, newGameParticipation.Id);
            Assert.IsNotNull(newGameParticipation.ModifiedDate);
        }

        [TestMethod]
        public void DeleteGameParticipation()
        {
            //Arrange
            var gameParticipationService = new GameParticipationService(new GameParticipationRepository());
            var generatedGameParticipationsCount = GameParticipationGenerator.GameParticipations.Count;
            var newGameParticipationId = GameParticipationGenerator.GameParticipations.Max(x => x.Id) + 1;
            //Act
            gameParticipationService.AddGameParticipation(GetTestGameParticipation());
            gameParticipationService.Delete(newGameParticipationId);
            var gameParticipations = gameParticipationService.GetAllGameParticipations();
            //Assert
            Assert.AreEqual(generatedGameParticipationsCount, gameParticipations.Count());
        }

        private static GameParticipation GetTestGameParticipation()
        {
            var newGameParticipationId = GameParticipationGenerator.GameParticipations.Max(x => x.Id) + 1;
            return new GameParticipation
            {
                Id = newGameParticipationId,
                GameTableId = GameTableGenerator.GameTable1.Id,
                GameTable = GameTableGenerator.GameTable1,
                GamerId = GamerGenerator.Gamer1.Id,
                Gamer = GamerGenerator.Gamer1
            };
        }
    }
}