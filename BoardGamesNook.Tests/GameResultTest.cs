using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GameResultTest
    {
        [TestMethod]
        public void GetGameResultList()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var generatedGameResultsCount = GameResultGenerator.GameResults.Count;
            //Act
            var gameResults = gameResultService.GetAllGameResults();
            //Assert
            Assert.AreEqual(generatedGameResultsCount, gameResults.Count());
        }

        [TestMethod]
        public void AddGameResultToGameResultsList()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var generatedGameResultsCount = GameResultGenerator.GameResults.Count;
            //Act
            gameResultService.AddGameResult(GetTestGameResult());
            var gameResults = gameResultService.GetAllGameResults();
            //Assert
            Assert.AreEqual(generatedGameResultsCount + 1, gameResults.Count());
        }

        [TestMethod]
        public void GetGameResult()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var newGameResultId = GameResultGenerator.GameResults.Max(x => x.Id) + 1;
            //Act
            gameResultService.AddGameResult(GetTestGameResult());
            var boardGame = gameResultService.GetGameResult(newGameResultId);
            //Assert
            Assert.AreEqual(newGameResultId, boardGame.Id);
        }

        [TestMethod]
        public void GetByNickname()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var newGamerId = Guid.NewGuid().ToString();
            var testGamer = GetTestGamer(newGamerId);
            var testNickname = Guid.NewGuid().ToString();
            testGamer.Nickname = testNickname;
            //Act
            gameResultService.AddGameResult(GetTestGameResult(testGamer));
            var gameResults = gameResultService.GetAllByGamerNickname(testNickname);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
        }

        [TestMethod]
        public void GetByTable()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var gameTableService = new GameTableService(new GameTableRepository(),
                new BoardGameService(new BoardGameRepository()),
                new GameParticipationService(new GameParticipationRepository()));
            var newGameTableId = GameTableGenerator.GameTables.Max(x => x.Id) + 1;
            gameTableService.CreateGameTable(GetTestGameTable(newGameTableId), new List<int>());
            var testGameTable = GameTableGenerator.GameTables.FirstOrDefault(x => x.Id == newGameTableId);
            //Act
            gameResultService.AddGameResult(GetTestGameResult(null, testGameTable));
            var gameResults = gameResultService.GetAllGameResultsByTableId(newGameTableId);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
        }

        [TestMethod]
        public void EditGameResult()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var newGameResultId = GameResultGenerator.GameResults.Max(x => x.Id) + 1;
            //Act
            gameResultService.AddGameResult(GetTestGameResult());
            var gameResult = gameResultService.GetGameResult(newGameResultId);
            gameResultService.EditGameResult(gameResult);
            var newGameResult = gameResultService.GetGameResult(newGameResultId);
            //Assert
            Assert.AreEqual(newGameResultId, newGameResult.Id);
            Assert.IsNotNull(newGameResult.ModifiedDate);
        }

        [TestMethod]
        public void DeleteGameResult()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var generatedGameResultsCount = GameResultGenerator.GameResults.Count;
            var newGameResultId = GameResultGenerator.GameResults.Max(x => x.Id) + 1;
            //Act
            gameResultService.AddGameResult(GetTestGameResult());
            gameResultService.DeleteGameResult(newGameResultId);
            var gameResults = gameResultService.GetAllGameResults();
            //Assert
            Assert.AreEqual(generatedGameResultsCount, gameResults.Count());
        }

        private static GameResult GetTestGameResult(Gamer gamer = null, GameTable table = null)
        {
            var newGameResultId = GameResultGenerator.GameResults.Max(x => x.Id) + 1;
            return new GameResult
            {
                Id = newGameResultId,
                GameTableId = table?.Id ?? GameTableGenerator.GameTable1.Id,
                GameTable = table ?? GameTableGenerator.GameTable1,
                GamerId = gamer?.Id ?? GamerGenerator.Gamer1.Id,
                Gamer = gamer ?? GamerGenerator.Gamer1
            };
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

        private static GameTable GetTestGameTable(int newGameTableId)
        {
            return new GameTable
            {
                Id = newGameTableId,
                BoardGames = new List<BoardGame>(),
                GameParticipations = null,
                CreatedGamer = GamerGenerator.Gamer1,
                Active = true
            };
        }
    }
}