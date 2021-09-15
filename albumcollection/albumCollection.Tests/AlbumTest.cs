using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using albumcollection.Controllers;
using albumcollection.Models;
using albumcollection.services;
using Xunit;

namespace albumCollection.Tests
{
    public class AlbumTest
    {
        #region Property
        public Mock<IAlbumService> mock = new Mock<IAlbumService>();
        #endregion

        [Fact]
        public async void GetAlbumbyId()
        {
            mock.Setup(p => p.GetAlbumbyId(1)).ReturnsAsync("Low Budget");
            TestController album = new TestController(mock.Object);
            string result = await album.GetAlbumbyId(1);
            Assert.Equal("Low Budget", result);
        }
        [Fact]
        public async void GetAlbumDetails()
        {
            var albumData = new Album()
            {
                Id = 1,
                Artist = "The Kinks",
                Title = "Low Budget",
                Label = "Arista",
                Genre = "Rock",
                ReleaseYear = "1979"
            };
            mock.Setup(p => p.GetAlbumDetails(1)).ReturnsAsync(albumData);
            TestController album = new TestController(mock.Object);
            var result = await album.GetAlbumDetails(1);
            Assert.True(albumData.Equals(result));
        }
    }
}
