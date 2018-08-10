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

        private static readonly Gamer _testGamer1 = new Gamer
        {
            Id = _testGuid1
        };

        private static readonly Gamer _testGamer2 = new Gamer
        {
            Id = _testGuid2
        };

        private static readonly GameTable _testGameTable1 = new GameTable
        {
            Id = 1
        };

        private static readonly GameTable _testGameTable2 = new GameTable
        {
            Id = 2
        };

        private static readonly BoardGame _testBoardGame = new BoardGame
        {
            Id = 1
        };

        private readonly Mock<IBoardGameRepository> _boardGameRepositoryMock;

        private readonly Mock<IGameResultRepository> _gameResultRepositoryMock;
        private readonly Mock<IGamerRepository> _gamerRepositoryMock;
        private readonly Mock<IGameTableRepository> _gameTableRepositoryMock;

        private readonly GameResult _testGameResult = new GameResult
        {
            Id = 1,
            GameTableId = 1,
            GameTable = _testGameTable1,
            GamerId = _testGuid1,
            Gamer = _testGamer1,
            BoardGameId = 1,
            BoardGame = _testBoardGame
        };

        private readonly GameResultDto _testGameResultDto = new GameResultDto
        {
            Id = 1,
            GameTableId = 1,
            GamerId = _testGuid1.ToString(),
            BoardGameId = 1
        };

        private readonly List<GameResultDto> _testGameResultDtoList = new List<GameResultDto>
        {
            new GameResultDto
            {
                Id = 1,
                GameTableId = 1,
                GamerId = _testGuid1.ToString(),
                BoardGameId = 1
            },
            new GameResultDto
            {
                Id = 2,
                GameTableId = 2,
                GamerId = _testGuid2.ToString(),
                BoardGameId = 1
            }
        };

        private readonly List<GameResult> _testGameResultList = new List<GameResult>
        {
            new GameResult
            {
                Id = 1,
                GameTableId = 1,
                GameTable = _testGameTable1,
                GamerId = _testGuid1,
                Gamer = _testGamer1,
                BoardGameId = 1,
                BoardGame = _testBoardGame
            },
            new GameResult
            {
                Id = 2,
                GameTableId = 2,
                GameTable = _testGameTable1,
                GamerId = _testGuid2,
                Gamer = _testGamer2,
                BoardGameId = 1,
                BoardGame = _testBoardGame
            }
        };

        public GameResultTest()
        {
            _gameResultRepositoryMock = new Mock<IGameResultRepository>();
            _gamerRepositoryMock = new Mock<IGamerRepository>();
            _gameTableRepositoryMock = new Mock<IGameTableRepository>();
            _boardGameRepositoryMock = new Mock<IBoardGameRepository>();
        }

        [TestMethod]
        public void GetGameResultList()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(x => x.GetAll()).Returns(new List<GameResult> {new GameResult()});
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
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
            _gameTableRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>())).Returns(_testGameTable1);
            _boardGameRepositoryMock.Setup(mock => mock.Get(It.IsAny<int>())).Returns(_testBoardGame);
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object,
                _boardGameRepositoryMock.Object
            );

            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
            //Act
            gameResultService.AddGameResult(_testGameResultDto, _testGamer1);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Add(It.Is<GameResult>(
                    x => x.GameTableId == _testGameResult.GameTableId &&
                         x.GameTable.Id == _testGameResult.GameTable.Id &&
                         x.GamerId == _testGameResult.GamerId &&
                         x.Gamer == _testGameResult.Gamer &&
                         x.Place == _testGameResult.Place &&
                         x.PlayersNumber == _testGameResult.PlayersNumber &&
                         x.BoardGameId == _testGameResult.BoardGameId &&
                         x.BoardGame.Id == _testGameResult.BoardGame.Id &&
                         x.Active == _testGameResult.Active
                )),
                Times.Once());
        }

        [TestMethod]
        public void AddManyGameResultToGameResultsList()
        {
            //Arrange
            _gameResultRepositoryMock.Setup(mock => mock.AddMany(It.IsAny<List<GameResult>>()));
            var gameResultService = new GameResultService(_gameResultRepositoryMock.Object, _gamerRepositoryMock.Object,
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddServicesProfiles(); });
            //Act
            gameResultService.AddGameResults(_testGameResultDtoList, new Gamer());
            //Assert
            _gameResultRepositoryMock.Verify(
                mock => mock.AddMany(It.Is<List<GameResult>>(
                    x => x.Count == _testGameResultList.Count &&
                         x[0].BoardGameId ==
                         _testGameResultList[0].BoardGameId &&
                         x[0].BoardGame.Id ==
                         _testGameResultList[0].BoardGame.Id &&
                         x[0].GameTableId ==
                         _testGameResultList[0].GameTableId &&
                         x[0].GameTable.Id ==
                         _testGameResultList[0].GameTable.Id &&
                         x[0].GamerId == _testGameResultList[0].GamerId &&
                         x[0].Gamer.Id == _testGameResultList[0].Gamer.Id
                )),
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
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
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
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
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
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
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
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
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
                _gameTableRepositoryMock.Object, _boardGameRepositoryMock.Object);
            //Act
            gameResultService.DeactivateGameResult(_testGameResult.Id);
            //Assert
            _gameResultRepositoryMock.Verify(mock => mock.Deactivate(It.Is<int>(x => x.Equals(_testGameResult.Id))),
                Times.Once());
        }
    }
}