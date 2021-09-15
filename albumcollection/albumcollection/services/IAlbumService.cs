using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using albumcollection.Models;

namespace albumcollection.services
{
    public interface IAlbumService
    {
        Task<string> GetAlbumbyId(int AlbumID);
        Task<Album> GetAlbumDetails(int AlbumID);
    }
}
