using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using albumcollection.Models;
using albumcollection.Data;
using Microsoft.EntityFrameworkCore;

namespace albumcollection.services
{
    public class AlbumService : IAlbumService
    {
        #region Property
        private readonly MvcAlbumContext _albumDbContext;
        #endregion

        #region Constructor
        public AlbumService(MvcAlbumContext albumDbContext)
        {
            _albumDbContext = albumDbContext;
        }
        #endregion

        public async Task<string> GetAlbumbyId(int AlbumID)
        {
            var title = await _albumDbContext.Album.Where(c => c.Id == AlbumID).Select(d => d.Title).FirstOrDefaultAsync();
            return title;
        }

        public async Task<Album> GetAlbumDetails(int AlbumID)
        {
            var album = await _albumDbContext.Album.FirstOrDefaultAsync(c => c.Id == AlbumID);
            return album;
        }
    }
}
