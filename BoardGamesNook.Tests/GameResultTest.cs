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
    public class GameResultTest
    {
        private readonly Mock<IGameResultRepository> _gameResultRepositoryMock;

        private readonly GameResult testGameResult = new GameResult
        {
            Id = 1,
            GameTableId = 1,
            GameTable = new GameTable(),
            GamerId = "test",
            Gamer = new Gamer()
        };

        public GameResultTest()
        {
            _gameResultRepositoryMock = new Mock<IGameResultRepository>();
        }

        [TestMethod]
        public void GetGameResultList()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.GetAll()).Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            var gameResults = gameResultService.GetAllGameResults();
            //Assert
            Assert.AreEqual(1, gameResults.Count());
            _gameResultRepositoryMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void AddGameResultToGameResultsList()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.Add(testGameResult));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.AddGameResult(testGameResult);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Add(testGameResult), Times.Once());
        }

        [TestMethod]
        public void GetGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.Get(testGameResult.Id));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            var gameResult = gameResultService.GetGameResult(testGameResult.Id);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Get(testGameResult.Id), Times.Once());
        }

        [TestMethod]
        public void GetAllByNickname()
        {
            //Arrange
            var nickname = "test";
            _gameResultRepositoryMock.Setup(x => x.GetAllByGamerNickname(nickname))
                .Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            var gameResults = gameResultService.GetAllByGamerNickname(nickname);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
            _gameResultRepositoryMock.Verify(mock => mock.GetAllByGamerNickname(nickname), Times.Once());
        }

        [TestMethod]
        public void GetByTable()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.GetAllByTableId(testGameResult.GameTableId.Value))
                .Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            var gameResults = gameResultService.GetAllGameResultsByTableId(testGameResult.GameTableId.Value);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
            _gameResultRepositoryMock.Verify(mock => mock.GetAllByTableId(testGameResult.GameTableId.Value),
                Times.Once());
        }

        [TestMethod]
        public void EditGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.Edit(testGameResult));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.EditGameResult(testGameResult);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Edit(testGameResult), Times.Once());
        }

        [TestMethod]
        public void DeactivateGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.Deactivate(testGameResult.Id));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.DeactivateGameResult(testGameResult.Id);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Deactivate(testGameResult.Id), Times.Once());
        }
    }
}