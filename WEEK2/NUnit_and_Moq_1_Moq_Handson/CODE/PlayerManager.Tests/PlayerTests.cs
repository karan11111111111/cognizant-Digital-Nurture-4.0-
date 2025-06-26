using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper = null!;

        [OneTimeSetUp]
        public void Init()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_WithValidName_ReturnsPlayer()
        {
            _mockPlayerMapper.Setup(pm => pm.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
            _mockPlayerMapper.Setup(pm => pm.AddNewPlayerIntoDb(It.IsAny<string>())).Verifiable();

            var player = Player.RegisterNewPlayer("Virat", _mockPlayerMapper.Object);

            Assert.IsNotNull(player);
            Assert.AreEqual("Virat", player.Name);
            Assert.AreEqual("India", player.Country);
        }

        [Test]
        public void RegisterNewPlayer_WithExistingName_ThrowsException()
        {
            _mockPlayerMapper.Setup(pm => pm.IsPlayerNameExistsInDb("Rohit")).Returns(true);

            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer("Rohit", _mockPlayerMapper.Object));
        }
    }
}
