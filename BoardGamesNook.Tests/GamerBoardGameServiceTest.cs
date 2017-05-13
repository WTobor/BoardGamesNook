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
            var gamerBoardGames = gamerBoardGameService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamerBoardGamesCount, gamerBoardGames.Count());
        }

        [TestMethod]
        public void AddGamerBoardGameToBoardGamesList()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var generatedGamerBoardGamesCount = GamerBoardGameGenerator.gamerBoardGames.Count;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            var boardGames = gamerBoardGameService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamerBoardGamesCount + 1, boardGames.Count());
        }

        [TestMethod]
        public void GetGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            var boardGame = gamerBoardGameService.Get(newGamerBoardGameId);
            //Assert
            Assert.AreEqual(newGamerBoardGameId, boardGame.Id);
        }

        [TestMethod]
        public void EditGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            var generatedGamerBoardGamesCount = GamerBoardGameGenerator.gamerBoardGames.Count;
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            int gamerId = 2;
            int boardGameId = 2;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            var boardGame = gamerBoardGameService.Get(newGamerBoardGameId);
            boardGame.GamerId = gamerId;
            boardGame.BoardGameId = boardGameId;
            gamerBoardGameService.Edit(boardGame);
            var newBoardGame = gamerBoardGameService.Get(newGamerBoardGameId);
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
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            gamerBoardGameService.Delete(newGamerBoardGameId);
            var boardGames = gamerBoardGameService.GetAll();
            //Assert
            Assert.AreEqual(generatedGamerBoardGamesCount, boardGames.Count());
        }

        private static GamerBoardGame GetTestGamerBoardGame()
        {
            var newGamerBoardGameId = GamerBoardGameGenerator.gamerBoardGames.Max(x => x.Id) + 1;
            return new GamerBoardGame()
            {
                Id = newGamerBoardGameId,
                GamerId = 1,
                BoardGameId = 1
            };
        }
    }
}

