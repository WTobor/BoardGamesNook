using System;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using BoardGamesNook.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerBoardGameServiceTest
    {
        private readonly IGamerBoardGameService _gamerBoardGameService;

        public GamerBoardGameServiceTest()
        {
            _gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository(),
                new BoardGameService(new BoardGameRepository()));
        }

        [TestMethod]
        public void GetGamerBoardGameList()
        {
            //Arrange
            var generatedGamerBoardGamesCount = GamerBoardGameGenerator.GamerBoardGames.Count;
            //Act
            var gamerBoardGames = _gamerBoardGameService.GetAllGamerBoardGames();
            //Assert
            Assert.AreEqual(generatedGamerBoardGamesCount, gamerBoardGames.Count());
        }

        [TestMethod]
        public void AddGamerBoardGameToBoardGamesList()
        {
            //Arrange
            var newGamerBoardGameId = GamerBoardGameGenerator.GamerBoardGames.Max(x => x.Id) + 1;
            //Act
            _gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            var lastAddedGamerBoardGame = GamerBoardGameGenerator.GamerBoardGames.LastOrDefault();
            //Assert
            Assert.AreEqual(newGamerBoardGameId, lastAddedGamerBoardGame?.Id);
        }

        [TestMethod]
        public void GetGamerBoardGame()
        {
            //Arrange
            var newGamerBoardGameId = GamerBoardGameGenerator.GamerBoardGames.Max(x => x.Id) + 1;
            //Act
            _gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            var boardGame = _gamerBoardGameService.GetGamerBoardGame(newGamerBoardGameId);
            //Assert
            Assert.AreEqual(newGamerBoardGameId, boardGame.Id);
        }

        [TestMethod]
        public void EditGamerBoardGame()
        {
            //Arrange
            var newGamerBoardGameId = GamerBoardGameGenerator.GamerBoardGames.Max(x => x.Id) + 1;
            var gamerId = Guid.NewGuid().ToString();
            var boardGameId = 2;
            //Act
            _gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            var boardGame = _gamerBoardGameService.GetGamerBoardGame(newGamerBoardGameId);
            boardGame.GamerId = gamerId;
            boardGame.BoardGameId = boardGameId;
            _gamerBoardGameService.EditGamerBoardGame(boardGame);
            var newBoardGame = _gamerBoardGameService.GetGamerBoardGame(newGamerBoardGameId);
            //Assert
            Assert.AreEqual(gamerId, newBoardGame.GamerId);
            Assert.AreEqual(boardGameId, newBoardGame.BoardGameId);
            Assert.IsNotNull(newBoardGame.ModifiedDate);
        }

        [TestMethod]
        public void DeleteGamerBoardGame()
        {
            //Arrange
            var generatedGamerBoardGamesCount = GamerBoardGameGenerator.GamerBoardGames.Count;
            var newGamerBoardGameId = GamerBoardGameGenerator.GamerBoardGames.Max(x => x.Id) + 1;
            //Act
            _gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            _gamerBoardGameService.DeleteGamerBoardGame(newGamerBoardGameId);
            var boardGames = _gamerBoardGameService.GetAllGamerBoardGames();
            //Assert
            Assert.AreEqual(generatedGamerBoardGamesCount, boardGames.Count());
        }

        private static GamerBoardGame GetTestGamerBoardGame(int newGamerBoardGameId)
        {
            return new GamerBoardGame
            {
                Id = newGamerBoardGameId,
                GamerId = "aqwsderfgt",
                BoardGameId = 1
            };
        }
    }
}