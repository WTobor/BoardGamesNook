using BoardGamesNook.Validators;
using BoardGamesNook.ViewModels.BoardGame;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class ValidationTest
    {
        private readonly BoardGameValidator _boardGameValidator;

        public ValidationTest()
        {
            _boardGameValidator = new BoardGameValidator();
        }

        [TestMethod]
        public void MaxPlayerEquals0ThrowsError()
        {
            _boardGameValidator.ShouldHaveValidationErrorFor(boardGame => boardGame.MaxPlayers, 0);
        }

        [TestMethod]
        public void MaxPlayerGreaterThan0Passes()
        {
            _boardGameValidator.ShouldNotHaveValidationErrorFor(boardGame => boardGame.MaxPlayers, 1);
        }

        [TestMethod]
        public void MaxTimeEquals0ThrowsError()
        {
            _boardGameValidator.ShouldHaveValidationErrorFor(boardGame => boardGame.MaxTime, 0);
        }

        [TestMethod]
        public void MaxTimeGreaterThan0Passes()
        {
            _boardGameValidator.ShouldNotHaveValidationErrorFor(boardGame => boardGame.MaxTime, 1);
        }

        [TestMethod]
        public void MaxPlayersLessThanMinPlayersThrowsError()
        {
            var boardGame = new BoardGameViewModel
            {
                MinPlayers = 1,
                MaxPlayers = 0
            };
            _boardGameValidator.ShouldHaveValidationErrorFor(x => x.MaxPlayers, boardGame);
        }

        [TestMethod]
        public void MaxPlayersEqualsMinPlayersPasses()
        {
            var boardGame = new BoardGameViewModel
            {
                MinPlayers = 1,
                MaxPlayers = 1
            };
            _boardGameValidator.ShouldNotHaveValidationErrorFor(x => x.MaxPlayers, boardGame);
        }

        [TestMethod]
        public void MaxPlayersGreaterThanMinPlayersPasses()
        {
            var boardGame = new BoardGameViewModel
            {
                MinPlayers = 1,
                MaxPlayers = 2
            };
            _boardGameValidator.ShouldNotHaveValidationErrorFor(x => x.MaxPlayers, boardGame);
        }
    }
}