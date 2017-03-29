using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class BoardGameServiceTest
    {
        [TestMethod]
        public void GetEmptyBoardGameList()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            //Act
            var boardGames = boardGameService.GetAll();
            //Assert
            Assert.AreEqual(0, boardGames.Count());
        }

        [TestMethod]
        public void AddBoardGameToEmptyBoardGamesList()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGames = boardGameService.GetAll();
            //Assert
            Assert.AreEqual(1, boardGames.Count());
        }

        [TestMethod]
        public void GetBoardGame()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGame = boardGameService.Get(1);
            //Assert
            Assert.AreEqual(1, boardGame.Id);
        }

        [TestMethod]
        public void EditBoardGame()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            string name = "test2";
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGame = boardGameService.Get(1);
            boardGame.Name = name;
            boardGameService.Edit(boardGame);
            var newBoardGame = boardGameService.Get(1);
            //Assert
            Assert.AreEqual(name, newBoardGame.Name);
        }

        [TestMethod]
        public void DeleteBoardGame()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            //Act
            boardGameService.Add(GetTestBoardGame());
            boardGameService.Delete(1);
            var boardGames = boardGameService.GetAll();
            //Assert
            Assert.AreEqual(0, boardGames.Count());
        }
        
        private static BoardGame GetTestBoardGame()
        {
            return new BoardGame()
            {
                Id = 1,
                Name = "test"
            };
        }
    }
}