using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain;

namespace Hotel_App.Data
{
    public class Hotel_AppContext : DbContext
    {
        public Hotel_AppContext (DbContextOptions<Hotel_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel.Domain.Reservaciones> Reservaciones { get; set; }

        public DbSet<Hotel.Domain.Empleados> Empleados { get; set; }

        public DbSet<Hotel.Domain.Usuario_clientes> Usuario_clientes { get; set; }
    }
}
