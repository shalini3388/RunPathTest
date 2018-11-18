using Runpath.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runpath.services.Interfaces
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAlbumByUser(int userId);
    }
}
