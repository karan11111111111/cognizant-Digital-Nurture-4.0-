using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailSenderMock = null!;
        private CustomerComm _customerComm = null!;

        [OneTimeSetUp]
        public void Init()
        {
            _mailSenderMock = new Mock<IMailSender>();
            _mailSenderMock.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _customerComm = new CustomerComm(_mailSenderMock.Object);
        }

        [Test]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            var result = _customerComm.SendMailToCustomer();
            Assert.IsTrue(result);
        }
    }
}

