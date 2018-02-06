using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GameTableServiceTest
    {
        private readonly Mock<IBoardGameRepository> _boardGameRepositoryMock;
        private readonly Mock<IGameParticipationRepository> _gameParticipationRepositoryMock;
        private readonly Mock<IGameTableRepository> _gameTableRepositoryMock;
        private readonly Mock<IGameResultRepository> _gameResultRepositoryMock;

        private readonly List<GameParticipation> testGameParticipations = new List<GameParticipation>
        {
            new GameParticipation
            {
                Id = 1,
                CreatedGamerId = "test",
                Gamer = new Gamer(),
                GameTable = new GameTable(),
                GameTableId = 1,
                Active = true
            }
        };

        private readonly GameTable testGameTable = new GameTable
        {
            Id = 1,
            BoardGames = new List<BoardGame>(),
            GameParticipations = null,
            Active = true
        };

        public GameTableServiceTest()
        {
            _gameTableRepositoryMock = new Mock<IGameTableRepository>();
            _boardGameRepositoryMock = new Mock<IBoardGameRepository>();
            _gameParticipationRepositoryMock = new Mock<IGameParticipationRepository>();
            _gameResultRepositoryMock = new Mock<IGameResultRepository>();
        }

        [TestMethod]
        public void GetGameTableListByGamerNickname()
        {
            //Arrange
            var nickname = "test";
            _gameTableRepositoryMock.Setup(x => x.GetAllGameTablesByGamerNickname(nickname))
                .Returns(new List<GameTable> {new GameTable()});
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object), _gameResultRepositoryMock.Object);

            //Act
            var gamerGameTableList = gameTableService.GetAllGameTablesByGamerNickname(nickname);
            //Assert
            Assert.AreEqual(1, gamerGameTableList.Count());
            _gameTableRepositoryMock.Verify(mock => mock.GetAllGameTablesByGamerNickname(nickname), Times.Once());
        }

        [TestMethod]
        public void AddGameTableToGameTablesList()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(x => x.AddGameTable(testGameTable));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.CreateGameTable(testGameTable, new List<int>());
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.AddGameTable(testGameTable), Times.Once());
        }

        [TestMethod]
        public void GetAvailableTableBoardGameList()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(x => x.Get(testGameTable.Id)).Returns(testGameTable);
            _gameTableRepositoryMock.Setup(x => x.GetAvailableTableBoardGameList(testGameTable));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.GetAvailableTableBoardGameListById(testGameTable.Id);
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.GetAvailableTableBoardGameList(testGameTable), Times.Once());
        }

        [TestMethod]
        public void GetGameTable()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(x => x.Get(testGameTable.Id));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            var gameTable = gameTableService.GetGameTable(testGameTable.Id);
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.Get(testGameTable.Id), Times.Once());
        }

        //dobry przykład
        [TestMethod]
        public void EditGameTable()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(x => x.Get(testGameTable.Id)).Returns(testGameTable);
            _gameTableRepositoryMock.Setup(x => x.EditGameTable(testGameTable));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.EditGameTable(testGameTable.Id, new List<int>());
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.EditGameTable(testGameTable), Times.Once());
        }

        //dobry przykład
        [TestMethod]
        public void EditParticipations()
        {
            //Arrange
            var gamer = new Gamer();
            foreach (var testGameParticipation in testGameParticipations)
                _gameParticipationRepositoryMock.Setup(x => x.Get(testGameParticipation.Id))
                    .Returns(testGameParticipation);
            _gameTableRepositoryMock.Setup(x => x.EditGameTableParticipations(testGameParticipations, gamer));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);

            //Act
            gameTableService.EditGameTableParticipations(testGameParticipations, gamer);

            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.EditGameTableParticipations(testGameParticipations, gamer),
                Times.Once());
        }

        [TestMethod]
        public void DeactivateGameTable()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(x => x.Deactivate(testGameTable.Id));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object), new GameResultRepository());

            //Act
            gameTableService.DeactivateGameTable(testGameTable.Id);
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.Deactivate(testGameTable.Id), Times.Once());
        }
    }
}