using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoardGamesNook.Tests
{
    [TestClass]
    public class GamerServiceTest
    {
        private readonly Mock<IGamerRepository> _gamerRepositoryMock;

        private readonly Gamer _testGamer = new Gamer
        {
            Id = Guid.NewGuid(),
            Nickname = "test"
        };

        public GamerServiceTest()
        {
            _gamerRepositoryMock = new Mock<IGamerRepository>();
        }


        [TestMethod]
        public void GetGamersList()
        {
            //Arrange
            _gamerRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Gamer> {new Gamer()});
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            var gamers = gamerService.GetAllGamers();
            //Assert
            Assert.AreEqual(1, gamers.Count());
            _gamerRepositoryMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void AddGamerToGamersList()
        {
            //Arrange
            _gamerRepositoryMock.Setup(mock => mock.Add(It.IsAny<Gamer>()));
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.AddGamer(_testGamer);
            //Assert
            _gamerRepositoryMock.Verify(mock => mock.Add(It.Is<Gamer>(x => x.Equals(_testGamer))),
                Times.Once());
        }

        [TestMethod]
        public void GetGamer()
        {
            //Arrange
            _gamerRepositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>()));
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.GetGamer(_testGamer.Id);
            //Assert
            _gamerRepositoryMock.Verify(mock => mock.Get(It.Is<Guid>(x => x.Equals(_testGamer.Id))),
                Times.Once());
        }

        [TestMethod]
        public void GetByEmail()
        {
            //Arrange
            var mail = "test";
            _gamerRepositoryMock.Setup(mock => mock.GetByEmail(It.IsAny<string>()))
                .Returns(new Gamer());
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.GetGamerByEmail(mail);

            //Assert
            _gamerRepositoryMock.Verify(mock => mock.GetByEmail(It.Is<string>(x => x.Equals(mail))),
                Times.Once());
        }

        [TestMethod]
        public void GetByNickname()
        {
            //Arrange
            var nickname = "test";
            _gamerRepositoryMock.Setup(mock => mock.GetByNickname(It.IsAny<string>()))
                .Returns(new Gamer());
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.GetGamerBoardGameByNickname(nickname);
            //Assert
            _gamerRepositoryMock.Verify(mock => mock.GetByNickname(It.Is<string>(x => x.Equals(nickname))),
                Times.Once());
        }

        [TestMethod]
        public void ExistsGamerNickname()
        {
            //Arrange
            var nickname = "test";
            _gamerRepositoryMock.Setup(mock => mock.NicknameExists(It.IsAny<string>()));
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.NicknameExists(nickname);
            _gamerRepositoryMock.Verify(mock => mock.NicknameExists(It.Is<string>(x => x.Equals(nickname))),
                Times.Once());
        }

        [TestMethod]
        public void EditGamer()
        {
            //Arrange
            _gamerRepositoryMock.Setup(mock => mock.Edit(It.IsAny<Gamer>()));
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.EditGamer(_testGamer);
            //Assert
            _gamerRepositoryMock.Verify(mock => mock.Edit(It.Is<Gamer>(x => x.Equals(_testGamer))),
                Times.Once());
        }

        [TestMethod]
        public void DeactivateGamer()
        {
            //Arrange
            _gamerRepositoryMock.Setup(mock => mock.Deactivate(It.IsAny<Guid>()));
            var gamerService = new GamerService(_gamerRepositoryMock.Object);
            //Act
            gamerService.DeactivateGamer(_testGamer.Id);
            //Assert
            _gamerRepositoryMock.Verify(mock => mock.Deactivate(It.Is<Guid>(x => x.Equals(_testGamer.Id))),
                Times.Once());
        }
    }
}