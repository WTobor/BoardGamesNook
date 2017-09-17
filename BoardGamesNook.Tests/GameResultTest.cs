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
            var generatedGameResultsCount = GameResultGenerator.gameResults.Count;
            //Act
            var gameResults = gameResultService.GetAll();
            //Assert
            Assert.AreEqual(generatedGameResultsCount, gameResults.Count());
        }

        [TestMethod]
        public void AddGameResultToGameResultsList()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var generatedGameResultsCount = GameResultGenerator.gameResults.Count;
            //Act
            gameResultService.Add(GetTestGameResult());
            var gameResults = gameResultService.GetAll();
            //Assert
            Assert.AreEqual(generatedGameResultsCount + 1, gameResults.Count());
        }

        [TestMethod]
        public void GetGameResult()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var newGameResultId = GameResultGenerator.gameResults.Max(x => x.Id) + 1;
            //Act
            gameResultService.Add(GetTestGameResult());
            var boardGame = gameResultService.Get(newGameResultId);
            //Assert
            Assert.AreEqual(newGameResultId, boardGame.Id);
        }

        [TestMethod]
        public void GetByNick()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var gamerService = new GamerService(new GamerRepository());
            var newGamerId = Guid.NewGuid().ToString();
            var testGamer = GetTestGamer(newGamerId);
            var testNick = Guid.NewGuid().ToString();
            testGamer.Nick = testNick;
            //Act
            gameResultService.Add(GetTestGameResult(testGamer));
            var gameResults = gameResultService.GetAllByGamerNick(testNick);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
        }

        [TestMethod]
        public void GetByTable()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var gameTableService = new GameTableService(new GameTableRepository());
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            gameTableService.Add(GetTestGameTable(newGameTableId));
            var testGameTable = GameTableGenerator.gameTables.Where(x => x.Id == newGameTableId).FirstOrDefault();
            //Act
            gameResultService.Add(GetTestGameResult(null, testGameTable));
            var gameResults = gameResultService.GetAllByTableId(newGameTableId);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
        }

        [TestMethod]
        public void EditGameResult()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var newGameResultId = GameResultGenerator.gameResults.Max(x => x.Id) + 1;
            DateTimeOffset now = DateTimeOffset.UtcNow;
            //Act
            gameResultService.Add(GetTestGameResult());
            var gameResult = gameResultService.Get(newGameResultId);
            gameResult.ModifiedDate = now;
            gameResultService.Edit(gameResult);
            var newGameResult = gameResultService.Get(newGameResultId);
            //Assert
            Assert.AreEqual(now, newGameResult.ModifiedDate);
        }

        [TestMethod]
        public void DeleteGameResult()
        {
            //Arrange
            var gameResultService = new GameResultService(new GameResultRepository());
            var generatedGameResultsCount = GameResultGenerator.gameResults.Count;
            var newGameResultId = GameResultGenerator.gameResults.Max(x => x.Id) + 1;
            //Act
            gameResultService.Add(GetTestGameResult());
            gameResultService.Delete(newGameResultId);
            var gameResults = gameResultService.GetAll();
            //Assert
            Assert.AreEqual(generatedGameResultsCount, gameResults.Count());
        }

        private static GameResult GetTestGameResult(Gamer gamer = null, GameTable table = null)
        {
            var newGameResultId = GameResultGenerator.gameResults.Max(x => x.Id) + 1;
            return new GameResult()
            {
                Id = newGameResultId,
                GameTableId = table?.Id ?? GameTableGenerator.gameTable1.Id,
                GameTable = table ?? GameTableGenerator.gameTable1,
                GamerId = gamer?.Id ?? GamerGenerator.gamer1.Id,
                Gamer = gamer ?? GamerGenerator.gamer1
            };
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

        private static GameTable GetTestGameTable(int newGameTableId)
        {
            return new GameTable()
            {
                Id = newGameTableId,
                BoardGames = new List<BoardGame>(),
                GameParticipations = null,
                CreatedGamer = GamerGenerator.gamer1,
                Active = true
            };
        }
    }
}