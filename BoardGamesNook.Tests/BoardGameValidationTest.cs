using BoardGamesNook.Validators;
using BoardGamesNook.ViewModels.BoardGame;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class BoardGameValidationTest
    {
        private readonly BoardGameValidator _boardGameValidator;

        public BoardGameValidationTest()
        {
            _boardGameValidator = new BoardGameValidator();
        }

        [DataTestMethod]
        [DataRow(0)]
        public void MaxPlayersThrowsError(int maxPlayers)
        {
            _boardGameValidator.ShouldHaveValidationErrorFor(boardGame => boardGame.MaxPlayers, maxPlayers);
        }

        [DataTestMethod]
        [DataRow(1)]
        public void MaxPlayersPasses(int maxPlayers)
        {
            _boardGameValidator.ShouldNotHaveValidationErrorFor(boardGame => boardGame.MaxPlayers, maxPlayers);
        }

        [DataTestMethod]
        [DataRow(0)]
        public void MaxTimeThrowsError(int maxTime)
        {
            _boardGameValidator.ShouldHaveValidationErrorFor(boardGame => boardGame.MaxTime, maxTime);
        }

        [DataTestMethod]
        [DataRow(1)]
        public void MaxTimePasses(int maxTime)
        {
            _boardGameValidator.ShouldNotHaveValidationErrorFor(boardGame => boardGame.MaxTime, maxTime);
        }

        [DataTestMethod]
        [DataRow(1, 0)]
        public void MaxPlayersWithMinPlayersThrowsError(int minPlayers, int maxPlayers)
        {
            var boardGame = new BoardGameViewModel
            {
                MinPlayers = 1,
                MaxPlayers = 0
            };
            _boardGameValidator.ShouldHaveValidationErrorFor(x => x.MaxPlayers, boardGame);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        public void MaxPlayersWithMinPlayersPasses(int minPlayers, int maxPlayers)
        {
            var boardGame = new BoardGameViewModel
            {
                MinPlayers = minPlayers,
                MaxPlayers = maxPlayers
            };
            _boardGameValidator.ShouldNotHaveValidationErrorFor(x => x.MaxPlayers, boardGame);
        }
    }
}