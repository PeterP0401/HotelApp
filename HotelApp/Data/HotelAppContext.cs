using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelApp.Domain.Entities;

namespace HotelApp.Data
{
    public class HotelAppContext : DbContext
    {
        public HotelAppContext (DbContextOptions<HotelAppContext> options)
            : base(options)
        {
        }

        public DbSet<HotelApp.Domain.Entities.Reservaciones> Reservaciones { get; set; }
    }
}
