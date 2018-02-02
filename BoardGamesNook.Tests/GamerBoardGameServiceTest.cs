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

        private readonly GamerBoardGame testGamerBoardGame = new GamerBoardGame
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
            _gamerBoardGameRepositoryMock.Setup(x => x.Add(testGamerBoardGame));
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            gamerBoardGameService.Add(testGamerBoardGame);
            //Assert
            _gamerBoardGameRepositoryMock.Verify(mock => mock.Add(testGamerBoardGame), Times.Once());
        }

        [TestMethod]
        public void GetGamerBoardGame()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(x => x.Get(testGamerBoardGame.Id)).Returns(testGamerBoardGame);
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            var gamerBoardGame = gamerBoardGameService.GetGamerBoardGame(testGamerBoardGame.Id);
            //Assert
            Assert.AreEqual(testGamerBoardGame.Id, gamerBoardGame.Id);
            _gamerBoardGameRepositoryMock.Verify(mock => mock.Get(testGamerBoardGame.Id), Times.Once());
        }

        [TestMethod]
        public void EditGamerBoardGame()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(x => x.Edit(testGamerBoardGame));
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            gamerBoardGameService.EditGamerBoardGame(testGamerBoardGame);
            //Assert
            _gamerBoardGameRepositoryMock.Verify(mock => mock.Edit(testGamerBoardGame), Times.Once());
        }

        [TestMethod]
        public void DeactivateGamerBoardGame()
        {
            //Arrange
            _gamerBoardGameRepositoryMock.Setup(x => x.Deactivate(testGamerBoardGame.Id));
            var gamerBoardGameService = new GamerBoardGameService(_gamerBoardGameRepositoryMock.Object,
                new BoardGameService(_boardGameRepositoryMock.Object));
            //Act
            gamerBoardGameService.DeactivateGamerBoardGame(testGamerBoardGame.Id);
            //Assert
            _gamerBoardGameRepositoryMock.Verify(mock => mock.Deactivate(testGamerBoardGame.Id), Times.Once());
        }
    }
}