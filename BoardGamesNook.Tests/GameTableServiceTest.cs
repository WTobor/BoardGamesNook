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
    public class GameTableServiceTest
    {
        [TestMethod]
        public void GetGameTableListByGamerNickname()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedByTestGamerGameTablesCount = GameTableGenerator.gameTables.Count(x => x.CreatedGamer?.Nickname == testGamer?.Nickname);

            //Act
            var gamerGameTableList = gameTableService.GetAllGameTablesByGamerNickname(testGamer?.Nickname);
            //Assert
            Assert.AreEqual(generatedByTestGamerGameTablesCount, gamerGameTableList.Count());
        }

        [TestMethod]
        public void AddGameTableToGameTablesList()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedGamerGameTablesCount = GameTableGenerator.gameTables.Count(x => x.CreatedGamer == testGamer);

            //Act
            gameTableService.AddGameTable(GetTestGameTable(testGamer));
            var gamerGameTableList = gameTableService.GetAllGameTablesByGamerNickname(testGamer?.Nickname);
            //Assert
            Assert.AreEqual(generatedGamerGameTablesCount + 1, gamerGameTableList.Count());
        }

        [TestMethod]
        public void GetAvailableTableBoardGameList()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var generatedBoardGamesCount = BoardGameGenerator.boardGames.Count;
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var newTable = GetTestGameTable(testGamer);
            //Act
            gameTableService.AddGameTable(newTable);
            var availableTableBoardGameList = gameTableService.GetAvailableTableBoardGameList(newTable);
            //Assert
            Assert.AreEqual(generatedBoardGamesCount, availableTableBoardGameList.Count());
        }

        [TestMethod]
        public void GetGameTable()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            //Act
            gameTableService.AddGameTable(GetTestGameTable(testGamer));
            var gameTable = gameTableService.GetGameTable(newGameTableId);
            //Assert
            Assert.AreEqual(newGameTableId, gameTable.Id);
        }

        [TestMethod]
        public void EditGameTable()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            DateTimeOffset now = DateTimeOffset.UtcNow;
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            //Act
            gameTableService.AddGameTable(GetTestGameTable(testGamer));
            var gameTable = gameTableService.GetGameTable(newGameTableId);
            gameTable.ModifiedDate = now;
            gameTableService.EditGameTable(gameTable);
            var newGameTable = gameTableService.GetGameTable(newGameTableId);
            //Assert
            Assert.AreEqual(now, newGameTable.ModifiedDate);
        }

        [TestMethod]
        public void EditParticipations()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            DateTimeOffset now = DateTimeOffset.UtcNow;
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();

            //Act
            gameTableService.AddGameTable(GetTestGameTable(testGamer));
            var gameTable = gameTableService.GetGameTable(newGameTableId);

            var testGameParticipations = GetTestGameParticipations(testGamer, gameTable);
            gameTableService.EditParticipations(testGameParticipations, testGamer);
            var newGameTable = gameTableService.GetGameTable(newGameTableId);

            //Assert
            Assert.AreEqual(testGameParticipations, newGameTable.GameParticipations);
        }

        [TestMethod]
        public void DeleteGameTable()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedGamerGameTablesCount = GameTableGenerator.gameTables.Count(x => x.CreatedGamer == testGamer);
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;

            //Act
            gameTableService.AddGameTable(GetTestGameTable(testGamer));
            gameTableService.DeleteGameTable(newGameTableId);
            var gamerGameTableList = gameTableService.GetAllGameTablesByGamerNickname(testGamer?.Nickname);
            //Assert
            Assert.AreEqual(generatedGamerGameTablesCount, gamerGameTableList.Count());
        }

        private static GameTable GetTestGameTable(Gamer createdGamer)
        {
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            return new GameTable()
            {
                Id = newGameTableId,
                BoardGames = new List<BoardGame>(),
                GameParticipations = null,
                CreatedGamer = createdGamer,
                Active = true
            };
        }

        private static List<GameParticipation> GetTestGameParticipations(Gamer createdGamer, GameTable gameTable)
        {
            var newGameParticipationId = GameParticipationGenerator.gameParticipations.Max(x => x.Id) + 1;
            return new List<GameParticipation>()
            {
                new GameParticipation()
                {
                    Id = newGameParticipationId,
                    CreatedGamerId = createdGamer.Id,
                    Gamer = createdGamer,
                    GameTable = gameTable,
                    GameTableId = gameTable.Id,
                    Active = true
                }
             };
        }
    }
}