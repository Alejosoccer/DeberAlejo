using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlejandroDeber.Models;

namespace AlejandroDeber.Data
{
    public class MainContext : DbContext
    {
        public MainContext (DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public DbSet<Lavadora> Lavadora { get; set; }

        public DbSet<Television> Televison { get; set; }

        public DbSet<Nevera> Nevera { get; set; }

        public DbSet<Microonda> Microonda { get; set; }

        public DbSet<Persona> Persona { get; set; }
    }
}
