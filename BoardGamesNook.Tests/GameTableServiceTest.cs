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
        public void GetGameTableList()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var generatedGameTablesCount = GameTableGenerator.gameTables.Count;
            //Act
            var GameTables = gameTableService.GetAllByGamerNick("");
            //Assert
            Assert.AreEqual(generatedGameTablesCount, GameTables.Count());
        }

        [TestMethod]
        public void AddGameTableToGameTablesList()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var generatedGameTablesCount = GameTableGenerator.gameTables.Count;
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            //Act
            gameTableService.Add(GetTestGameTable());
            var GameTables = gameTableService.GetAllByGamerNick("");
            //Assert
            Assert.AreEqual(generatedGameTablesCount + 1, GameTables.Count());
        }

        [TestMethod]
        public void GetAvailableTableBoardGameList()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var generatedBoardGamesCount = BoardGameGenerator.boardGames.Count;
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            var newTable = GetTestGameTable();
            //Act
            gameTableService.Add(newTable);
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
            //Act
            gameTableService.Add(GetTestGameTable());
            var gameTable = gameTableService.Get(newGameTableId);
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
            //Act
            gameTableService.Add(GetTestGameTable());
            var gameTable = gameTableService.Get(newGameTableId);
            gameTable.ModifiedDate = now;
            gameTableService.Edit(gameTable);
            var newGameTable = gameTableService.Get(newGameTableId);
            //Assert
            Assert.AreEqual(now, newGameTable.ModifiedDate);
        }

        [TestMethod]
        public void DeleteGameTable()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var generatedGameTablesCount = GameTableGenerator.gameTables.Count;
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            //Act
            gameTableService.Add(GetTestGameTable());
            gameTableService.Delete(newGameTableId);
            var gameTables = gameTableService.GetAllByGamerNick("");
            //Assert
            Assert.AreEqual(generatedGameTablesCount, gameTables.Count());
        }

        private static GameTable GetTestGameTable()
        {
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;
            return new GameTable()
            {
                Id = newGameTableId,
                BoardGames = new List<BoardGame>(),
                GameParticipationInfo = null,
                Active = true
            };
        }
    }
}