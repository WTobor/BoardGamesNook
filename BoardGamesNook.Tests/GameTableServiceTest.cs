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
        public void GetGameTableListByGamerNick()
        {
            //Arrange
            var gameTableService = new GameTableService(new GameTableRepository());
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedByTestGamerGameTablesCount = GameTableGenerator.gameTables.Count(x => x.CreatedGamer?.Nick == testGamer?.Nick);

            //Act
            var gamerGameTableList = gameTableService.GetAllByGamerNick(testGamer?.Nick);
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
            gameTableService.Add(GetTestGameTable(testGamer));
            var gamerGameTableList = gameTableService.GetAllByGamerNick(testGamer?.Nick);
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
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            //Act
            gameTableService.Add(GetTestGameTable(testGamer));
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
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            //Act
            gameTableService.Add(GetTestGameTable(testGamer));
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
            var testGamer = GameTableGenerator.gameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedGamerGameTablesCount = GameTableGenerator.gameTables.Count(x => x.CreatedGamer == testGamer);
            var newGameTableId = GameTableGenerator.gameTables.Max(x => x.Id) + 1;

            //Act
            gameTableService.Add(GetTestGameTable(testGamer));
            gameTableService.Delete(newGameTableId);
            var gamerGameTableList = gameTableService.GetAllByGamerNick(testGamer?.Nick);
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
                GameParticipationInfo = null,
                CreatedGamer = createdGamer,
                Active = true
            };
        }
    }
}