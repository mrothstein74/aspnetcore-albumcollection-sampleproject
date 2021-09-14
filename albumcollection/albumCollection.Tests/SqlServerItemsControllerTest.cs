using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using albumcollection.Tests;
using Microsoft.EntityFrameworkCore;
using albumcollection.Data;

namespace albumCollection.Tests
{
    public class SqlServerItemsControllerTest : AlbumsControllerTest
    {
        public SqlServerItemsControllerTest()
            : base(
                new DbContextOptionsBuilder<MvcAlbumContext>()
                    .UseSqlServer(@"Server=db,1433;Database=MvcAlbumContext;User=sa;Password=r22rbf8*PUHjqzb3;")
                    .Options)
        {
        }
    }
}
