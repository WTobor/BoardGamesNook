using BoardGamesNook.Validators;
using BoardGamesNook.ViewModels.GameResult;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GameResultValidationTest
    {
        private readonly GameResultValidator _gameResultValidator;

        public GameResultValidationTest()
        {
            _gameResultValidator = new GameResultValidator();
        }

        [TestMethod]
        public void PlayersNumberLessThanPlaceThrowsError()
        {
            var gameResult = new GameResultViewModel
            {
                PlayersNumber = 1,
                Place = 2
            };
            _gameResultValidator.ShouldHaveValidationErrorFor(x => x.PlayersNumber, gameResult);
        }

        [TestMethod]
        public void PlayersNumberEqualsPlacePasses()
        {
            var gameResult = new GameResultViewModel
            {
                PlayersNumber = 1,
                Place = 1
            };
            _gameResultValidator.ShouldNotHaveValidationErrorFor(x => x.PlayersNumber, gameResult);
        }

        [TestMethod]
        public void PlayersNumberGreaterThanPlacePasses()
        {
            var gameResult = new GameResultViewModel
            {
                PlayersNumber = 2,
                Place = 1
            };
            _gameResultValidator.ShouldNotHaveValidationErrorFor(x => x.PlayersNumber, gameResult);
        }
    }
}