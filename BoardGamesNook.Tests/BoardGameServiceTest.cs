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

        private readonly BoardGame testBoardGame = new BoardGame
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
            _boardGameRepositoryMock.Setup(mock => mock.Add(testBoardGame));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);
            //Act
            boardGameService.Add(testBoardGame);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Add(testBoardGame), Times.Once());
        }

        [TestMethod]
        public void GetBoardGame()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Get(testBoardGame.Id));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);
            //Act
            boardGameService.Get(testBoardGame.Id);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Get(testBoardGame.Id), Times.Once());
        }

        [TestMethod]
        public void EditBoardGame()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Edit(testBoardGame));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);

            //Act
            boardGameService.Edit(testBoardGame);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Edit(testBoardGame), Times.Once());
        }

        [TestMethod]
        public void DeactivateBoardGame()
        {
            //Arrange
            _boardGameRepositoryMock.Setup(mock => mock.Deactivate(testBoardGame.Id));
            var boardGameService = new BoardGameService(_boardGameRepositoryMock.Object);
            //Act
            boardGameService.DeactivateBoardGame(testBoardGame.Id);
            //Assert
            _boardGameRepositoryMock.Verify(mock => mock.Deactivate(testBoardGame.Id), Times.Once());
        }
    }
}