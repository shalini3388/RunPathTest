using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Runpath.services;
using Runpath.services.Interfaces;
using System.Linq;

namespace Runpath.test
{
    [TestFixture]
    public class TestAlbumService:BaseTest
    {
        private IAlbumService sut;
        private Mock<IPhotoService> MockPhotoService;

        [SetUp]
        public void setup()
        {
            MockPhotoService = new Mock<IPhotoService>();
            sut = new AlbumService(AlbumRepository.Object, MockPhotoService.Object);
        }

        [Test]
        public void TestThatOnlyRelevantPhotosAreReturned()
        {
            var result = sut.GetAlbumByUser(1);

            NUnit.Framework.Assert.That(result.All(a => a.UserId == 1));
            NUnit.Framework.Assert.That(result.Count() == 2);
        }
    }
}
