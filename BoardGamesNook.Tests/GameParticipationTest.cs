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
    public class GameParticipationTest
    {
        private readonly Mock<IGameParticipationRepository> _gameParticipationRepositoryMock;

        private readonly GameParticipation _testGameParticipation = new GameParticipation
        {
            Id = 1,
            GameTableId = 1,
            GameTable = new GameTable(),
            GamerId = "testGamerId",
            Gamer = new Gamer()
        };

        public GameParticipationTest()
        {
            _gameParticipationRepositoryMock = new Mock<IGameParticipationRepository>();
        }

        [TestMethod]
        public void GetGameParticipationList()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(x => x.GetAll())
                .Returns(new List<GameParticipation> {new GameParticipation()});
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            var gameParticipations = gameParticipationService.GetAllGameParticipations();
            //Assert
            Assert.AreEqual(1, gameParticipations.Count());
            _gameParticipationRepositoryMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void AddGameParticipationToGameParticipationsList()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(mock =>
                mock.Add(It.IsAny<GameParticipation>()));
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            gameParticipationService.AddGameParticipation(_testGameParticipation);
            //Assert
            _gameParticipationRepositoryMock.Verify(
                mock => mock.Add(It.Is<GameParticipation>(x => x.Equals(_testGameParticipation))), Times.Once());
        }

        [TestMethod]
        public void GetGameParticipation()
        {
            //Arrange
            _gameParticipationRepositoryMock
                .Setup(mock => mock.Get(It.IsAny<int>()))
                .Returns(_testGameParticipation);
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            var gameParticipation = gameParticipationService.GetGameParticipation(_testGameParticipation.Id);
            //Assert
            _gameParticipationRepositoryMock.Verify(
                mock => mock.Get(It.Is<int>(x => x.Equals(_testGameParticipation.Id))), Times.Once());
        }

        [TestMethod]
        public void EditGameParticipation()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(mock =>
                mock.Edit(It.IsAny<GameParticipation>()));
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            gameParticipationService.Edit(_testGameParticipation);
            //Assert
            _gameParticipationRepositoryMock.Verify(
                mock => mock.Edit(It.Is<GameParticipation>(x => x.Equals(_testGameParticipation))), Times.Once());
        }

        [TestMethod]
        public void DeactivateGameParticipation()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(mock =>
                mock.Deactivate(It.IsAny<int>()));
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            gameParticipationService.DeactivateGameParticipation(_testGameParticipation.Id);
            //Assert
            _gameParticipationRepositoryMock.Verify(
                mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testGameParticipation.Id))), Times.Once());
        }
    }
}