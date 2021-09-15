using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using albumcollection.Models;

namespace albumcollection.Data
{

    public class MvcAlbumContext : DbContext
    {
        public MvcAlbumContext(DbContextOptions<MvcAlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Album { get; set; }
    }
}
