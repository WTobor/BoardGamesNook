using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class BoardGameServiceTest
    {
        [TestMethod]
        public void GetBoardGameList()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            var generatedBoardGamesCount = BoardGameGenerator.boardGames.Count;
            //Act
            var boardGames = boardGameService.GetAll();
            //Assert
            Assert.AreEqual(generatedBoardGamesCount, boardGames.Count());
        }

        [TestMethod]
        public void AddBoardGameToBoardGamesList()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            var generatedBoardGamesCount = BoardGameGenerator.boardGames.Count;
            var newBoardGameId = BoardGameGenerator.boardGames.Max(x => x.Id) + 1;
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGames = boardGameService.GetAll();
            //Assert
            Assert.AreEqual(generatedBoardGamesCount + 1, boardGames.Count());
        }

        [TestMethod]
        public void GetBoardGame()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            var newBoardGameId = BoardGameGenerator.boardGames.Max(x => x.Id) + 1;
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGame = boardGameService.Get(newBoardGameId);
            //Assert
            Assert.AreEqual(newBoardGameId, boardGame.Id);
        }

        [TestMethod]
        public void EditBoardGame()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            var newBoardGameId = BoardGameGenerator.boardGames.Max(x => x.Id) + 1;
            string name = "test2";
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGame = boardGameService.Get(newBoardGameId);
            boardGame.Name = name;
            boardGameService.Edit(boardGame);
            var newBoardGame = boardGameService.Get(newBoardGameId);
            //Assert
            Assert.AreEqual(name, newBoardGame.Name);
        }

        [TestMethod]
        public void DeleteBoardGame()
        {
            //Arrange
            var boardGameService = new BoardGameService(new BoardGameRepository());
            var generatedBoardGamesCount = BoardGameGenerator.boardGames.Count;
            var newBoardGameId = BoardGameGenerator.boardGames.Max(x => x.Id) + 1;
            //Act
            boardGameService.Add(GetTestBoardGame());
            boardGameService.Delete(newBoardGameId);
            var boardGames = boardGameService.GetAll();
            //Assert
            Assert.AreEqual(generatedBoardGamesCount, boardGames.Count());
        }
        
        private static BoardGame GetTestBoardGame()
        {
            var newBoardGameId = BoardGameGenerator.boardGames.Max(x => x.Id) + 1;
            return new BoardGame()
            {
                Id = newBoardGameId,
                Name = "test"
            };
        }
    }
}