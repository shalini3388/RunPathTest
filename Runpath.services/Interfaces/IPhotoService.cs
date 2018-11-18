using Runpath.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runpath.services.Interfaces
{
    public interface IPhotoService
    {
        List<Photo> GetPhotosByAlbum(int albumId);
    }
}
