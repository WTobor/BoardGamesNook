using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var boardGames = boardGameService.GetAllGamerBoardGames();
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
            var boardGames = boardGameService.GetAllGamerBoardGames();
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
            var name = "test2";
            //Act
            boardGameService.Add(GetTestBoardGame());
            var boardGame = boardGameService.Get(newBoardGameId);
            boardGame.Name = name;
            boardGameService.Edit(boardGame);
            var newBoardGame = boardGameService.Get(newBoardGameId);
            //Assert
            Assert.AreEqual(name, newBoardGame.Name);
            Assert.IsNotNull(newBoardGame.ModifiedDate);
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
            var boardGames = boardGameService.GetAllGamerBoardGames();
            //Assert
            Assert.AreEqual(generatedBoardGamesCount, boardGames.Count());
        }

        private static BoardGame GetTestBoardGame()
        {
            var newBoardGameId = BoardGameGenerator.boardGames.Max(x => x.Id) + 1;
            return new BoardGame
            {
                Id = newBoardGameId,
                Name = "test"
            };
        }
    }
}