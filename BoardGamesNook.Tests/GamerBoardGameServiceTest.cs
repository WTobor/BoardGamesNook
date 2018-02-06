using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerBoardGameServiceTest
    {
        private readonly Mock<IBoardGameRepository> _boardGameRepositoryMock;
        private readonly Mock<IGamerBoardGameRepository> _gamerBoardGameRepositoryMock;

        private readonly GamerBoardGame _testGamerBoardGame = new GamerBoardGame
        {
            Id = 1,
            GamerId = "aqwsderfgt",
            BoardGameId = 1
        };

        public GamerBoardGameServiceTest()
        {
            _gamerBoardGameRepositoryMock = new Mock<IGamerBoardGameRepository>();
            _boardGameRepositoryMock = new Mock<IBoardGameRepository>();
        }

        [TestMethod]
        public void GetGamerBoardGameList()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(x => x.GetAll())
                .Returns(new List<GamerBoardGame> {new GamerBoardGame()});
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));

            //Act
            var gamerBoardGames = gamerBoardGameService.GetAllGamerBoardGames();
            //Assert
            Assert.AreEqual(1, gamerBoardGames.Count());
            _gamerBoardGameRepositoryMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void AddGamerBoardGameToBoardGamesList()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(mock =>
                mock.Add(It.Is<GamerBoardGame>(x => x.Equals(_testGamerBoardGame))));
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            gamerBoardGameService.Add(_testGamerBoardGame);
            //Assert
            _gamerBoardGameRepositoryMock.Verify(
                mock => mock.Add(It.Is<GamerBoardGame>(x => x.Equals(_testGamerBoardGame))), Times.Once());
        }

        [TestMethod]
        public void GetGamerBoardGame()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(mock => mock.Get(It.Is<int>(x => x.Equals(_testGamerBoardGame.Id))))
                .Returns(_testGamerBoardGame);
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            var gamerBoardGame = gamerBoardGameService.GetGamerBoardGame(_testGamerBoardGame.Id);
            //Assert
            Assert.AreEqual(_testGamerBoardGame.Id, gamerBoardGame.Id);
            _gamerBoardGameRepositoryMock.Verify(mock => mock.Get(It.Is<int>(x => x.Equals(_testGamerBoardGame.Id))),
                Times.Once());
        }

        [TestMethod]
        public void EditGamerBoardGame()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(mock =>
                mock.Edit(It.Is<GamerBoardGame>(x => x.Equals(_testGamerBoardGame))));
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            gamerBoardGameService.EditGamerBoardGame(_testGamerBoardGame);
            //Assert
            _gamerBoardGameRepositoryMock.Verify(
                mock => mock.Edit(It.Is<GamerBoardGame>(x => x.Equals(_testGamerBoardGame))), Times.Once());
        }

        [TestMethod]
        public void DeactivateGamerBoardGame()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(mock =>
 mock.Deactivate(It.Is<int>(x => x.Equals(_testGamerBoardGame.Id))));
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            gamerBoardGameService.DeactivateGamerBoardGame(_testGamerBoardGame.Id);
            //Assert
            _gamerBoardGameRepositoryMock.Verify(
                mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testGamerBoardGame.Id))), Times.Once());
        }
    }
}