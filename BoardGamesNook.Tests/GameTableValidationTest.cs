using BoardGamesNook.Validators;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GameTableValidationTest
    {
        private readonly GameTableValidator _gameTableValidator;

        public GameTableValidationTest()
        {
            _gameTableValidator = new GameTableValidator();
        }

        [TestMethod]
        public void CityHasNumbersThrowsError()
        {
            _gameTableValidator.ShouldHaveValidationErrorFor(boardGame => boardGame.City, "123");
        }

        [TestMethod]
        public void CityHasOnlyLettersPasses()
        {
            _gameTableValidator.ShouldNotHaveValidationErrorFor(gameTable => gameTable.City, "abc");
        }

        [TestMethod]
        public void CityTooShortThrowsError()
        {
            _gameTableValidator.ShouldHaveValidationErrorFor(gameTable => gameTable.City, "a");
        }

        [TestMethod]
        public void CityLongEnoughtPasses()
        {
            _gameTableValidator.ShouldNotHaveValidationErrorFor(gameTable => gameTable.City, "abc");
        }
    }
}