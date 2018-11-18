using System;
using NUnit.Framework;
using Runpath.services.Interfaces;
using Runpath.services;
using Moq;
using System.Linq;

namespace Runpath.test
{
    [TestFixture]
    public class TestPhotoService:BaseTest
    {
        private IPhotoService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new PhotoService(PhotoRepository.Object);

        }

        [Test]
        public void TestThatOnlyPhotsOfGivenAlbumIsReturned()
        {
            var result = _sut.GetPhotosByAlbum(1);
            Assert.That(result.Count()==3);
        }

       
    }
}
