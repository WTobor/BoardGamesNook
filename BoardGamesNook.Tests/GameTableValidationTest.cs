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

        [DataTestMethod]
        [DataRow("a")]
        [DataRow("123")]
        public void CityThrowsError(string city)
        {
            _gameTableValidator.ShouldHaveValidationErrorFor(boardGame => boardGame.City, city);
        }

        [DataTestMethod]
        [DataRow("abc")]
        public void CityPasses(string city)
        {
            _gameTableValidator.ShouldNotHaveValidationErrorFor(gameTable => gameTable.City, city);
        }
    }
}