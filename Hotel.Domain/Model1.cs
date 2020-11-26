using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Hotel.Domain
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Reservaciones")
        {
        }

        public virtual DbSet<Reservaciones> Reservaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservaciones>()
                .Property(e => e.Email_R)
                .IsUnicode(false);

            modelBuilder.Entity<Reservaciones>()
                .Property(e => e.Nombre_R)
                .IsUnicode(false);

            modelBuilder.Entity<Reservaciones>()
                .Property(e => e.Apellidos_R)
                .IsUnicode(false);

            modelBuilder.Entity<Reservaciones>()
                .Property(e => e.Habitacion_R)
                .IsUnicode(false);

            modelBuilder.Entity<Reservaciones>()
                .Property(e => e.Especificaion_R)
                .IsUnicode(false);
        }
    }
}
