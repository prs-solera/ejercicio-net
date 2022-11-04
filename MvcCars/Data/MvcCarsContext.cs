using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCars.Models;

namespace MvcCars.Data
{
    public class MvcCarsContext : DbContext
    {
        public MvcCarsContext (DbContextOptions<MvcCarsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCars.Models.Owner> Owner { get; set; } = default!;

        public DbSet<MvcCars.Models.Vehicle> Vehicle { get; set; }

        public DbSet<MvcCars.Models.Claim> Claim { get; set; }
    }
}
