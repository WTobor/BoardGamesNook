using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using BoardGamesNook.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GameTableServiceTest
    {
        private readonly IGameTableService _gameTableService;

        public GameTableServiceTest()
        {
            _gameTableService = new GameTableService(new GameTableRepository(),
                new BoardGameService(new BoardGameRepository()),
                new GameParticipationService(new GameParticipationRepository()));
        }

        [TestMethod]
        public void GetGameTableListByGamerNickname()
        {
            //Arrange

            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedByTestGamerGameTablesCount =
                GameTableGenerator.GameTables.Count(x => x.CreatedGamer?.Nickname == testGamer?.Nickname);

            //Act
            var gamerGameTableList = _gameTableService.GetAllGameTablesByGamerNickname(testGamer?.Nickname);
            //Assert
            Assert.AreEqual(generatedByTestGamerGameTablesCount, gamerGameTableList.Count());
        }

        [TestMethod]
        public void AddGameTableToGameTablesList()
        {
            //Arrange
            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedGamerGameTablesCount = GameTableGenerator.GameTables.Count(x => x.CreatedGamer == testGamer);

            //Act
            _gameTableService.CreateGameTable(GetTestGameTable(testGamer), new List<int>());
            var gamerGameTableList = _gameTableService.GetAllGameTablesByGamerNickname(testGamer?.Nickname);
            //Assert
            Assert.AreEqual(generatedGamerGameTablesCount + 1, gamerGameTableList.Count());
        }

        [TestMethod]
        public void GetAvailableTableBoardGameList()
        {
            //Arrange
            var generatedBoardGamesCount = BoardGameGenerator.BoardGames.Count;
            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var newTable = GetTestGameTable(testGamer);
            //Act
            _gameTableService.CreateGameTable(newTable, new List<int>());
            var availableTableBoardGameList = _gameTableService.GetAvailableTableBoardGameListById(newTable.Id);
            //Assert
            Assert.AreEqual(generatedBoardGamesCount, availableTableBoardGameList.Count());
        }

        [TestMethod]
        public void GetGameTable()
        {
            //Arrange
            var newGameTableId = GameTableGenerator.GameTables.Max(x => x.Id) + 1;
            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            //Act
            _gameTableService.CreateGameTable(GetTestGameTable(testGamer), new List<int>());
            var gameTable = _gameTableService.GetGameTable(newGameTableId);
            //Assert
            Assert.AreEqual(newGameTableId, gameTable.Id);
        }

        [TestMethod]
        public void EditGameTable()
        {
            //Arrange
            var newGameTableId = GameTableGenerator.GameTables.Max(x => x.Id) + 1;
            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            //Act
            _gameTableService.CreateGameTable(GetTestGameTable(testGamer), new List<int>());
            var gameTable = _gameTableService.GetGameTable(newGameTableId);
            _gameTableService.EditGameTable(gameTable.Id, new List<int>());
            var newGameTable = _gameTableService.GetGameTable(newGameTableId);
            //Assert
            Assert.AreEqual(newGameTableId, newGameTable.Id);
            Assert.IsNotNull(newGameTable.ModifiedDate);
        }

        [TestMethod]
        public void EditParticipations()
        {
            //Arrange
            var newGameTableId = GameTableGenerator.GameTables.Max(x => x.Id) + 1;
            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();

            //Act
            _gameTableService.CreateGameTable(GetTestGameTable(testGamer), new List<int>());
            var gameTable = _gameTableService.GetGameTable(newGameTableId);

            var testGameParticipations = GetTestGameParticipations(testGamer, gameTable);
            _gameTableService.EditParticipations(testGameParticipations, testGamer);
            var newGameTable = _gameTableService.GetGameTable(newGameTableId);

            //Assert
            Assert.AreEqual(testGameParticipations, newGameTable.GameParticipations);
        }

        [TestMethod]
        public void DeleteGameTable()
        {
            //Arrange
            var testGamer = GameTableGenerator.GameTables.Select(x => x.CreatedGamer).FirstOrDefault();
            var generatedGamerGameTablesCount = GameTableGenerator.GameTables.Count(x => x.CreatedGamer == testGamer);
            var newGameTableId = GameTableGenerator.GameTables.Max(x => x.Id) + 1;

            //Act
            _gameTableService.CreateGameTable(GetTestGameTable(testGamer), new List<int>());
            _gameTableService.DeleteGameTable(newGameTableId);
            var gamerGameTableList = _gameTableService.GetAllGameTablesByGamerNickname(testGamer?.Nickname);
            //Assert
            Assert.AreEqual(generatedGamerGameTablesCount, gamerGameTableList.Count());
        }

        private static GameTable GetTestGameTable(Gamer createdGamer)
        {
            var newGameTableId = GameTableGenerator.GameTables.Max(x => x.Id) + 1;
            return new GameTable
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
            var newGameParticipationId = GameParticipationGenerator.GameParticipations.Max(x => x.Id) + 1;
            return new List<GameParticipation>
            {
                new GameParticipation
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