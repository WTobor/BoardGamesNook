using System;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerBoardGameServiceTest
    {
        [TestMethod]
        public void GetGamerBoardGameList()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var generatedGamerBoardGamesCount = GamerBoardGameGenerator.gamerBoardGames.Count;
            //Act
            var gamerBoardGames = gamerBoardGameService.GetAllGamerBoardGames();
            //Assert
            Assert.AreEqual(generatedGamerBoardGamesCount, gamerBoardGames.Count());
        }

        [TestMethod]
        public void AddGamerBoardGameToBoardGamesList()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            var lastAddedGamerBoardGame = GamerBoardGameGenerator.gamerBoardGames.LastOrDefault();
            //Assert
            Assert.AreEqual(newGamerBoardGameId, lastAddedGamerBoardGame?.Id);
        }

        [TestMethod]
        public void GetGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            var boardGame = gamerBoardGameService.GetGamerBoardGame(newGamerBoardGameId);
            //Assert
            Assert.AreEqual(newGamerBoardGameId, boardGame.Id);
        }

        [TestMethod]
        public void EditGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            var gamerId = Guid.NewGuid().ToString();
            var boardGameId = 2;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            var boardGame = gamerBoardGameService.GetGamerBoardGame(newGamerBoardGameId);
            boardGame.GamerId = gamerId;
            boardGame.BoardGameId = boardGameId;
            gamerBoardGameService.EditGamerBoardGame(boardGame);
            var newBoardGame = gamerBoardGameService.GetGamerBoardGame(newGamerBoardGameId);
            //Assert
            Assert.AreEqual(gamerId, newBoardGame.GamerId);
            Assert.AreEqual(boardGameId, newBoardGame.BoardGameId);
        }

        [TestMethod]
        public void DeleteGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var generatedGamerBoardGamesCount = GamerBoardGameGenerator.gamerBoardGames.Count;
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame(newGamerBoardGameId));
            gamerBoardGameService.DeleteGamerBoardGame(newGamerBoardGameId);
            var boardGames = gamerBoardGameService.GetAllGamerBoardGames();
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