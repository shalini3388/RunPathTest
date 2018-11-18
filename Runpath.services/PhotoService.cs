using Runpath.domain;
using Runpath.domain.Dto;
using Runpath.repository.Interface;
using Runpath.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runpath.services
{
    public class PhotoService:IPhotoService
    {
        private IRepository<PhotoDto> _repository;
        private const string photoUrl= "http://jsonplaceholder.typicode.com/photos";

        public PhotoService(IRepository<PhotoDto> repository)
        {
            _repository = repository;
        }

        public List<Photo> GetPhotosByAlbum(int albumId)
        {
            return _repository.GetAll(photoUrl).Where(p => p.AlbumId == albumId).Select(p=>new Photo()
            {
                Id=p.Id,
                AlbumId=p.AlbumId,
                ThumbnailUrl=p.ThumbnailUrl,
                Title=p.Title,
                Url=p.Url
            }).ToList();
        }

    }
}
