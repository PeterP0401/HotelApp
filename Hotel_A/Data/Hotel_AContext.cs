using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain;

namespace Hotel_A.Data
{
    public class Hotel_AContext : DbContext
    {
        public Hotel_AContext (DbContextOptions<Hotel_AContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel.Domain.Reservaciones> Reservaciones { get; set; }
    }
}
