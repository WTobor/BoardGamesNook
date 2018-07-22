using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services;
using BoardGamesNook.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GameResultTest
    {
        private static readonly Guid _testGuid1 = Guid.NewGuid();
        private static readonly Guid _testGuid2 = Guid.NewGuid();
        private readonly Mock<IGameResultRepository> _gameResultRepositoryMock;
        private readonly Mock<IGamerRepository> _gamerRepositoryMock;
        private readonly Mock<IGameTableRepository> _gameTableRepositoryMock;

        private readonly GameResult _testGameResult = new GameResult
        {
            Id = 1,
            GameTableId = 1,
            GameTable = new GameTable(),
            GamerId = _testGuid1,
            Gamer = new Gamer()
        };

        private readonly GameResultDto _testGameResultDto = new GameResultDto
        {
            Id = 1,
            GameTableId = 1,
            GamerId = _testGuid1.ToString()
        };

        private readonly List<GameResultDto> _testGameResultDtoList = new List<GameResultDto>
        {
            new GameResultDto
            {
                Id = 1,
                GameTableId = 1,
                GamerId = _testGuid1.ToString()
            },
            new GameResultDto
            {
                Id = 2,
                GameTableId = 2,
                GamerId = _testGuid2.ToString()
            }
        };

        private readonly List<GameResult> _testGameResultList = new List<GameResult>
        {
            new GameResult
            {
                Id = 1,
                GameTableId = 1,
                GameTable = new GameTable(),
                GamerId = _testGuid1,
                Gamer = new Gamer()
            },
            new GameResult
            {
                Id = 2,
                GameTableId = 2,
                GameTable = new GameTable(),
                GamerId = _testGuid2,
                Gamer = new Gamer()
            }
        };

        public GameResultTest()
        {
            _gameResultRepositoryMock = new Mock<IGameResultRepository>();
            _gamerRepositoryMock = new Mock<IGamerRepository>();
            _gameTableRepositoryMock = new Mock<IGameTableRepository>();
        }

        [TestMethod]
        public void GetGameResultList()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.GetAll()).Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
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
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
            //Act
            gameResultService.AddGameResult(_testGameResultDto, new Gamer());
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Add(It.Is<GameResult>(x => x.Equals(_testGameResult))),
                Times.Once());
        }

        [TestMethod]
        public void AddManyGameResultToGameResultsList()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock => mock.AddMany(It.IsAny<List<GameResult>>()));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
            //Act
            gameResultService.AddGameResults(_testGameResultDtoList, new Gamer());
            //Assert
            _gameResultRepositoryMock.Verify(
                mock => mock.AddMany(It.Is<List<GameResult>>(x => x.Equals(_testGameResultList))),
                Times.Once());
        }

        [TestMethod]
        public void GetGameResult()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>())).Returns(new GameResult());
            _gamerRepositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).Returns(new Gamer());
            _gameTableRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>())).Returns(new GameTable());
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
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
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
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
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
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
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
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
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object);
            //Act
            gameResultService.DeactivateGameResult(_testGameResult.Id);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testGameResult.Id))),
                Times.Once());
        }
    }
}