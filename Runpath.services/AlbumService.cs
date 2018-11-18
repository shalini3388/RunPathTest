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
    public class AlbumService:IAlbumService
    {
        private IRepository<AlbumDto> _repository;
        private IPhotoService _photoService;
        private const string albumUrl = "http://jsonplaceholder.typicode.com/albums";

        public AlbumService(IRepository<AlbumDto> repository, IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
        }

        public IEnumerable<Album> GetAlbumByUser(int userId)
        {
            return _repository.GetAll(albumUrl).Where(a => a.UserId == userId).Select(ua => new Album()
            {
                Id=ua.Id,
                Title=ua.Title,
                UserId=ua.UserId,
                Photos=_photoService.GetPhotosByAlbum(ua.Id)
            });
        }
    }
}
