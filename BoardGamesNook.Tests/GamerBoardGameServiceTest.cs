using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerBoardGameServiceTest
    {
        [TestMethod]
        public void GetEmptyGamerBoardGameList()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            //Act
            var gamerBoardGames = gamerBoardGameService.GetAll();
            //Assert
            Assert.AreEqual(0, gamerBoardGames.Count());
        }

        [TestMethod]
        public void AddGamerBoardGameToEmptyBoardGamesList()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            var boardGames = gamerBoardGameService.GetAll();
            //Assert
            Assert.AreEqual(1, boardGames.Count());
        }

        [TestMethod]
        public void GetGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            var boardGame = gamerBoardGameService.Get(1);
            //Assert
            Assert.AreEqual(1, boardGame.Id);
        }

        [TestMethod]
        public void EditGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            int gamerId = 2;
            int boardGameId = 2;
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            var boardGame = gamerBoardGameService.Get(1);
            boardGame.GamerId = gamerId;
            boardGame.BoardGameId = boardGameId;
            gamerBoardGameService.Edit(boardGame);
            var newBoardGame = gamerBoardGameService.Get(1);
            //Assert
            Assert.AreEqual(gamerId, newBoardGame.GamerId);
            Assert.AreEqual(boardGameId, newBoardGame.BoardGameId);
        }


        [TestMethod]
        public void DeleteGamerBoardGame()
        {
            //Arrange
            var gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
            //Act
            gamerBoardGameService.Add(GetTestGamerBoardGame());
            gamerBoardGameService.Delete(1);
            var boardGames = gamerBoardGameService.GetAll();
            //Assert
            Assert.AreEqual(0, boardGames.Count());
        }

        private static GamerBoardGame GetTestGamerBoardGame()
        {
            return new GamerBoardGame()
            {
                Id = 1,
                GamerId = 1,
                BoardGameId = 1
            };
        }
    }
}

