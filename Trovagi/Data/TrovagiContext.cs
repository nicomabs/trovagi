using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trovagi.Models;

namespace Trovagi.Data
{
    public class TrovagiContext : DbContext
    {
        public TrovagiContext(DbContextOptions<TrovagiContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=trovagi.db");
    }
}
