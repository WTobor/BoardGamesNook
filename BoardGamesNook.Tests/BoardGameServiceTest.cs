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
    public class BoardGameServiceTest
    {
        private readonly Mock<IBoardGameRepository> _boardGameRepositoryMock;

        private readonly BoardGame _testBoardGame = new BoardGame
        {
            Id = 1,
            Name = "test"
        };

        public BoardGameServiceTest()
        {
            _boardGameRepositoryMock = new Mock<IBoardGameRepository>();
        }

        [TestMethod]
        public void GetBoardGameList()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.GetAll()).Returns(new List<BoardGame> {new BoardGame()});
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);

            //Act
            var boardGames = boardGameService.GetAllGamerBoardGames();

            //Assert
            Assert.AreEqual(1, boardGames.Count());
            _boardGameRepositoryMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void AddBoardGameToBoardGamesList()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Add(It.Is<BoardGame>(x => x.Equals(_testBoardGame))));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);
            //Act
            boardGameService.Add(_testBoardGame);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Add(It.Is<BoardGame>(i => i.Equals(_testBoardGame))), Times.Once);
        }

        [TestMethod]
        public void GetBoardGame()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Get(It.Is<int>(x => x.Equals(_testBoardGame.Id))));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);
            //Act
            boardGameService.Get(_testBoardGame.Id);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Get(_testBoardGame.Id), Times.Once());
        }

        [TestMethod]
        public void EditBoardGame()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Edit(It.Is<BoardGame>(x => x.Equals(_testBoardGame))));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);

            //Act
            boardGameService.Edit(_testBoardGame);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Edit(It.Is<BoardGame>(x => x.Equals(_testBoardGame))), Times.Once());
        }

        [TestMethod]
        public void DeactivateBoardGame()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testBoardGame.Id))));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);
            //Act
            boardGameService.DeactivateBoardGame(_testBoardGame.Id);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testBoardGame.Id))), Times.Once());
        }
    }
}