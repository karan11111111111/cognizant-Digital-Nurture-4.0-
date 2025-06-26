using NUnit.Framework;
using Moq;
using MagicFilesLib;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _mockExplorer = null!;
        private ICollection<string> _mockFiles = null!;

        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            _mockFiles = new List<string> { _file1, _file2 };
            _mockExplorer = new Mock<IDirectoryExplorer>();
            _mockExplorer.Setup(de => de.GetFiles(It.IsAny<string>())).Returns(_mockFiles);
        }

        [Test]
        public void GetFiles_ReturnsExpectedFiles()
        {
            var result = _mockExplorer.Object.GetFiles("C:/somepath");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, _file1);
        }
    }
}

