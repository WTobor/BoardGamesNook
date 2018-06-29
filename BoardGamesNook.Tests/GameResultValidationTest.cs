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

        [DataTestMethod]
        [DataRow(1,2)]
        public void PlayersNumberThrowsError(int playersNumber, int place)
        {
            var gameResult = new GameResultViewModel
            {
                PlayersNumber = playersNumber,
                Place = place
            };
            _gameResultValidator.ShouldHaveValidationErrorFor(x => x.PlayersNumber, gameResult);
        }

        [DataTestMethod]
        [DataRow(1,1)]
        [DataRow(2,1)]
        public void PlayersNumberPasses(int playersNumber, int place)
        {
            var gameResult = new GameResultViewModel
            {
                PlayersNumber = playersNumber,
                Place = place
            };
            _gameResultValidator.ShouldNotHaveValidationErrorFor(x => x.PlayersNumber, gameResult);
        }
    }
}