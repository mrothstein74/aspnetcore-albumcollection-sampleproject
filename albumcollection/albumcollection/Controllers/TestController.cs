using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using albumcollection.Models;
using albumcollection.services;

namespace albumcollection.Controllers
{
    public class TestController: ControllerBase
    {
        #region Property
        private readonly IAlbumService _albumService;
        #endregion

        #region Constructor
        public TestController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        #endregion

        [HttpGet(nameof(GetAlbumbyId))]
        public async Task<string> GetAlbumbyId(int AlbumID)
        {
            var result = await _albumService.GetAlbumbyId(AlbumID);
            return result;
        }
        [HttpGet(nameof(GetAlbumDetails))]
        public async Task<Album> GetAlbumDetails(int AlbumID)
        {
            var result = await _albumService.GetAlbumDetails(AlbumID);
            return result;
        }
    }
}
