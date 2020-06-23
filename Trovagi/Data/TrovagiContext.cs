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

        public DbSet<Hotel> Tournaments { get; set; }
        public DbSet<City> Enrollments { get; set; }
    }
}
