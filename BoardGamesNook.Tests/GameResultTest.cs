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

        private readonly GameResult _testGameResult = new GameResult
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
            _gameResultRepositoryMock.Setup(mock => mock.Add(It.IsAny<GameResult>()));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.AddGameResult(_testGameResult);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Add(It.Is<GameResult>(x => x.Equals(_testGameResult))),
                Times.Once());
        }

        [TestMethod]
        public void GetGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>()));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.GetGameResult(_testGameResult.Id);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Get(It.Is<int>(x => x.Equals(_testGameResult.Id))),
                Times.Once());
        }

        [TestMethod]
        public void GetAllByNickname()
        {
            //Arrange
            var nickname = "test";
            _gameResultRepositoryMock.Setup(mock => mock.GetAllByGamerNickname(It.IsAny<string>()))
                .Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            var gameResults = gameResultService.GetAllByGamerNickname(nickname);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
            _gameResultRepositoryMock.Verify(mock => mock.GetAllByGamerNickname(It.Is<string>(x => x.Equals(nickname))),
                Times.Once());
        }

        [TestMethod]
        public void GetByTable()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock =>
                    mock.GetAllByTableId(It.IsAny<int>()))
                .Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            var gameResults = gameResultService.GetAllGameResultsByTableId(_testGameResult.GameTableId.Value);

            //Assert
            Assert.AreEqual(1, gameResults.Count());
            _gameResultRepositoryMock.Verify(
                mock => mock.GetAllByTableId(It.Is<int>(x => x.Equals(_testGameResult.GameTableId.Value))),
                Times.Once());
        }

        [TestMethod]
        public void EditGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock => mock.Edit(It.IsAny<GameResult>()));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.EditGameResult(_testGameResult);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Edit(It.Is<GameResult>(x => x.Equals(_testGameResult))),
                Times.Once());
        }

        [TestMethod]
        public void DeactivateGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock => mock.Deactivate(It.IsAny<int>()));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object);
            //Act
            gameResultService.DeactivateGameResult(_testGameResult.Id);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testGameResult.Id))),
                Times.Once());
        }
    }
}