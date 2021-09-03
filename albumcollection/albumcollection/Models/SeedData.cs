using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using albumcollection.Data;



namespace albumcollection.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAlbumContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAlbumContext>>()))
            {
                // Look for any Albums.
                if (context.Album.Any())
                {
                    return;   // DB has been seeded
                }

                context.Album.AddRange(
                    new Album
                    {
                        Artist = "The Clash",
                        Title = "London Calling",
                        ReleaseYear = "1979",
                        Genre = "Punk",
                        Label = "CBS"
                    },

                    new Album
                    {
                        Artist = "U.K. Subs",
                        Title = "Brand New Age",
                        ReleaseYear = "1980",
                        Genre = "Punk",
                        Label = "GEM"
                    },

                    new Album
                    {
                        Artist = "Miles Davis",
                        Title = "Kind Of Blue",
                        ReleaseYear = "1959",
                        Genre = "Jazz",
                        Label = "Columbia"
                    },

                    new Album
                    {
                        Artist = "Phil Ochs",
                        Title = "All The News That's Fit To Sing",
                        ReleaseYear = "1964",
                        Genre = "Folk",
                        Label = "Elektra"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}