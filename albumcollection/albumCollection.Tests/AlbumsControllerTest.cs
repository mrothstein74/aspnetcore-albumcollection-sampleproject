using System.Linq;
using albumcollection;
using albumcollection.Controllers;
using albumcollection.Data;
using albumcollection.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace albumcollection.Tests
{
    public abstract class AlbumsControllerTest
    {
        #region Seeding
        protected AlbumsControllerTest(DbContextOptions<MvcAlbumContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();

        }

        protected DbContextOptions<MvcAlbumContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new MvcAlbumContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Album.AddRange(
                    new Album
                    {
                        Artist = "New York Dolls",
                        Title = "Too Much Too Soon",
                        ReleaseYear = "1974",
                        Genre = "Glam",
                        Label = "Mercury"
                    },

                    new Album
                    {
                        Artist = "Thelonious Monk",
                        Title = "Thelonious Monk Plays",
                        ReleaseYear = "1954",
                        Genre = "Jazz",
                        Label = "Prestige"
                    },

                    new Album
                    {
                        Artist = "Discharge",
                        Title = "Why",
                        ReleaseYear = "1981",
                        Genre = "Punk",
                        Label = "Clay"
                    },

                    new Album
                    {
                        Artist = "Pink Floyd",
                        Title = "The Piper at the Gates of Dawn",
                        ReleaseYear = "1967",
                        Genre = "Rock",
                        Label = "Columbia"
                    }
                );
                context.SaveChanges();
            }
        }
        #endregion

        #region CanGetItems
        [Fact]
        public void Can_get_items()
        {
            using (var context = new MvcAlbumContext(ContextOptions))
            {
                var controller = new AlbumsController(context);

                var items = controller.Get().ToList();

                Assert.Equal(3, items.Count);
                Assert.Equal("Why", items[2].Title);
            }
        }
        #endregion

        #region CanAddItem
        [Fact]
        public void Can_add_item()
        {
            using (var context = new MvcAlbumContext(ContextOptions))
            {
                var controller = new AlbumsController(context);

                var album = new Album
                {
                    Artist = "Evacuate",
                    Title = "2012",
                    ReleaseYear = "2012",
                    Genre = "Punk",
                    Label = "Evacuate"
                };

                var items = controller.Get().ToList();

                Assert.Equal("Evacuate", items[0].Artist);
            }
        }
        #endregion
    }
}
