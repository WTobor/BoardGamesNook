using BoardGamesNook.Validators;
using BoardGamesNook.ViewModels.Gamer;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerValidationTest
    {
        private readonly GamerValidator _gamerValidator;

        public GamerValidationTest()
        {
            _gamerValidator = new GamerValidator();
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("aa")]
        public void NicknameThrowsError(string nick)
        {
            var gamer = new GamerViewModel
            {
                Nickname = nick
            };
            _gamerValidator.ShouldHaveValidationErrorFor(x => x.Nickname, gamer);
        }

        [DataTestMethod]
        [DataRow("aaa")]
        [DataRow("aaaa")]
        public void NicknamePasses(string nick)
        {
            var gamer = new GamerViewModel
            {
                Nickname = nick
            };
            _gamerValidator.ShouldNotHaveValidationErrorFor(x => x.Nickname, gamer);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("aa")]
        [DataRow("1234")]
        public void NameThrowsError(string name)
        {
            var gamer = new GamerViewModel
            {
                Name = name
            };
            _gamerValidator.ShouldHaveValidationErrorFor(x => x.Name, gamer);
        }

        [DataTestMethod]
        [DataRow("aaa")]
        [DataRow("aaaa")]
        public void NamePasses(string name)
        {
            var gamer = new GamerViewModel
            {
                Name = name
            };
            _gamerValidator.ShouldNotHaveValidationErrorFor(x => x.Name, gamer);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("aa")]
        [DataRow("1234")]
        public void SurnameThrowsError(string surname)
        {
            var gamer = new GamerViewModel
            {
                Surname = surname
            };
            _gamerValidator.ShouldHaveValidationErrorFor(x => x.Surname, gamer);
        }

        [DataTestMethod]
        [DataRow("aaa")]
        [DataRow("aaaa")]
        public void SurnamePasses(string surname)
        {
            var gamer = new GamerViewModel
            {
                Surname = surname
            };
            _gamerValidator.ShouldNotHaveValidationErrorFor(x => x.Surname, gamer);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("aa@")]
        public void EmailThrowsError(string email)
        {
            var gamer = new GamerViewModel
            {
                Email = email
            };
            _gamerValidator.ShouldHaveValidationErrorFor(x => x.Email, gamer);
        }

        [DataTestMethod]
        [DataRow("test@test.pl")]
        [DataRow("a@test.com")]
        public void EmailPasses(string email)
        {
            var gamer = new GamerViewModel
            {
                Email = email
            };
            _gamerValidator.ShouldNotHaveValidationErrorFor(x => x.Email, gamer);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("aa")]
        [DataRow("1234")]
        public void CityThrowsError(string city)
        {
            var gamer = new GamerViewModel
            {
                City = city
            };
            _gamerValidator.ShouldHaveValidationErrorFor(x => x.City, gamer);
        }

        [DataTestMethod]
        [DataRow("aaa")]
        [DataRow("aaaa")]
        public void CityPasses(string city)
        {
            var gamer = new GamerViewModel
            {
                City = city
            };
            _gamerValidator.ShouldNotHaveValidationErrorFor(x => x.City, gamer);
        }
    }
}