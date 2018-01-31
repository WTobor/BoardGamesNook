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

        private readonly GameParticipation testGameParticipation = new GameParticipation
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
            _gameParticipationRepositoryMock.Setup(x => x.Add(testGameParticipation));
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            gameParticipationService.AddGameParticipation(testGameParticipation);
            //Assert
            _gameParticipationRepositoryMock.Verify(mock => mock.Add(testGameParticipation), Times.Once());
        }

        [TestMethod]
        public void GetGameParticipation()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(x => x.Get(testGameParticipation.Id)).Returns(testGameParticipation);
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            var gameParticipation = gameParticipationService.GetGameParticipation(testGameParticipation.Id);
            //Assert
            _gameParticipationRepositoryMock.Verify(mock => mock.Get(testGameParticipation.Id), Times.Once());
        }

        [TestMethod]
        public void EditGameParticipation()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(x => x.Edit(testGameParticipation));
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            gameParticipationService.Edit(testGameParticipation);
            //Assert
            _gameParticipationRepositoryMock.Verify(mock => mock.Edit(testGameParticipation), Times.Once());
        }

        [TestMethod]
        public void DeactivateGameParticipation()
        {
            //Arrange
            _gameParticipationRepositoryMock.Setup(x => x.Deactivate(testGameParticipation.Id));
            var gameParticipationService = new GameParticipationService(_gameParticipationRepositoryMock.Object);
            //Act
            gameParticipationService.DeactivateGameParticipation(testGameParticipation.Id);
            //Assert
            _gameParticipationRepositoryMock.Verify(mock => mock.Deactivate(testGameParticipation.Id), Times.Once());
        }
    }
}