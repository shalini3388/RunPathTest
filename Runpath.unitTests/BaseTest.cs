using Moq;
using NUnit.Framework;
using Runpath.domain.Dto;
using Runpath.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runpath.test
{
    [TestFixture]
    public class BaseTest
    {
        protected Mock<IRepository<AlbumDto>> AlbumRepository;
        protected Mock<IRepository<PhotoDto>> PhotoRepository;
        
        [SetUp]
        public void Setup()
        {
            AlbumRepository = new Mock<IRepository<AlbumDto>>();
            PhotoRepository = new Mock<IRepository<PhotoDto>>();

            var albums = new List<AlbumDto>()
            {
                new AlbumDto(){Id=1,Title="test",UserId=1},
                new AlbumDto(){Id=1,Title="test",UserId=2},
                new AlbumDto(){Id=1,Title="test",UserId=3},
                new AlbumDto(){Id=2,Title="test",UserId=1},
                new AlbumDto(){Id=2,Title="test",UserId=4},
                new AlbumDto(){Id=1,Title="test",UserId=4},
            };

            var photos = new List<PhotoDto>()
            {
                new PhotoDto(){Id=1, AlbumId=1, Title="test"},
                new PhotoDto(){Id=1, AlbumId=1, Title="test"},
                new PhotoDto(){Id=1, AlbumId=1, Title="test"},
                new PhotoDto(){Id=1, AlbumId=2, Title="test"},
                new PhotoDto(){Id=1, AlbumId=2, Title="test"},
                new PhotoDto(){Id=1, AlbumId=3, Title="test"},
                new PhotoDto(){Id=1, AlbumId=4, Title="test"},
            };

            AlbumRepository.Setup(m => m.GetAll(It.IsAny<string>())).Returns(albums);
            PhotoRepository.Setup(m => m.GetAll(It.IsAny<string>())).Returns(photos);

        }
    }
}
