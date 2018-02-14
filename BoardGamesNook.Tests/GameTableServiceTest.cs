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

        private readonly List<GameParticipation> _testGameParticipations = new List<GameParticipation>
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

        private readonly GameTable _testGameTable = new GameTable
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
            _gameTableRepositoryMock.Setup(mock =>
                    mock.GetAllGameTablesByGamerNickname(It.IsAny<string>()))
                .Returns(new List<GameTable> {new GameTable()});
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object), 
                _gameResultRepositoryMock.Object);

            //Act
            var gamerGameTableList = gameTableService.GetAllGameTablesByGamerNickname(nickname);
            //Assert
            Assert.AreEqual(1, gamerGameTableList.Count());
            _gameTableRepositoryMock.Verify(
                mock => mock.GetAllGameTablesByGamerNickname(It.Is<string>(x => x.Equals(nickname))), Times.Once());
        }

        [TestMethod]
        public void AddGameTableToGameTablesList()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(mock => mock.AddGameTable(It.IsAny<GameTable>()));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.CreateGameTable(_testGameTable, new List<int>());
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.AddGameTable(It.Is<GameTable>(x => x.Equals(_testGameTable))),
                Times.Once());
        }

        [TestMethod]
        public void GetAvailableTableBoardGameList()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>()))
                .Returns(_testGameTable);
            _gameTableRepositoryMock.Setup(mock =>
                mock.GetAvailableTableBoardGameList(It.Is<GameTable>(x => x.Equals(_testGameTable))));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.GetAvailableTableBoardGameListById(_testGameTable.Id);
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.Get(It.Is<int>(x => x.Equals(_testGameTable.Id))),
                Times.Once());
            _gameTableRepositoryMock.Verify(
                mock => mock.GetAvailableTableBoardGameList(It.Is<GameTable>(x => x.Equals(_testGameTable))),
                Times.Once());
        }

        [TestMethod]
        public void GetGameTable()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>()));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.GetGameTable(_testGameTable.Id);
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.Get(It.Is<int>(x => x.Equals(_testGameTable.Id))),
                Times.Once());
        }

        //dobry przykład
        [TestMethod]
        public void EditGameTable()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>()))
                .Returns(_testGameTable);
            _gameTableRepositoryMock.Setup(mock => mock.EditGameTable(It.IsAny<GameTable>()));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.EditGameTable(_testGameTable.Id, new List<int>());
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.Get(It.Is<int>(x => x.Equals(_testGameTable.Id))),
                Times.Once());
            _gameTableRepositoryMock.Verify(mock => mock.EditGameTable(It.Is<GameTable>(x => x.Equals(_testGameTable))),
                Times.Once());
        }

        [TestMethod]
        public void EditParticipations()
        {
            //Arrange
            var gamer = new Gamer();
            foreach (var testGameParticipation in _testGameParticipations)
                _gameParticipationRepositoryMock
                    .Setup(mock => mock.Get(It.IsAny<int>()))
                    .Returns(testGameParticipation);
            _gameTableRepositoryMock.Setup(mock =>
                mock.EditGameTableParticipations(It.IsAny<List<GameParticipation>>(),
                    It.Is<Gamer>(x => x.Equals(gamer))));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object),
                _gameResultRepositoryMock.Object);
            //Act
            gameTableService.EditGameTableParticipations(_testGameParticipations, gamer);
            //Assert
            _gameTableRepositoryMock.Verify(
                mock => mock.EditGameTableParticipations(
                    It.Is<List<GameParticipation>>(x => x.Equals(_testGameParticipations)),
                    It.Is<Gamer>(x => x.Equals(gamer))),
                Times.Once());
        }

        [TestMethod]
        public void DeactivateGameTable()
        {
            //Arrange
            _gameTableRepositoryMock.Setup(mock => mock.Deactivate(It.IsAny<int>()));
            var gameTableService = new GameTableService(_gameTableRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object),
                new GameParticipationService(_gameParticipationRepositoryMock.Object), new GameResultRepository());
            //Act
            gameTableService.DeactivateGameTable(_testGameTable.Id);
            //Assert
            _gameTableRepositoryMock.Verify(mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testGameTable.Id))),
                Times.Once());
        }
    }
}