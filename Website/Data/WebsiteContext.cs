using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Website.Model;

namespace Website.Data
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext (DbContextOptions<WebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Website.Model.TblUsers> TblUsers { get; set; }

        public DbSet<Website.Model.RandomNum> RandomNum { get; set; }

        public DbSet<Website.Model.TblGames> TblGames { get; set; }
    }
}
