using System;
using Hotel.Domain.Entity;
using Hotel.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hotel.Infrastructure.Models
{
    public partial class BDHotelContext : DbContext
    {
        public BDHotelContext()
        {
        }

        public BDHotelContext(DbContextOptions<BDHotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservaciones> Reservaciones { get; set; }
        public virtual DbSet<UsuarioCliente> UsuarioClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-O2OFPMFD;Initial Catalog=BDHotel;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservaciones>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservac__9E953BE126C5B0A6");

                entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");

                entity.Property(e => e.ApellidosR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Apellidos_R");

                entity.Property(e => e.EmailR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Email_R");

                entity.Property(e => e.EspecificaionR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Especificaion_R");

                entity.Property(e => e.FechaEntradaR)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Entrada_R");

                entity.Property(e => e.FechaSalidaR)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Salida_R");

                entity.Property(e => e.HabitacionR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Habitacion_R");

                entity.Property(e => e.NombreR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_R");

                entity.Property(e => e.TelefonoR)
                    .HasMaxLength(10)
                    .HasColumnName("Telefono_R");
            });

            modelBuilder.Entity<UsuarioCliente>(entity =>
            {
                entity.HasKey(e => e.IdClientes)
                    .HasName("PK__Usuario___731F3B2E151367E0");

                entity.ToTable("Usuario_clientes");

                entity.Property(e => e.IdClientes).HasColumnName("Id_Clientes");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_de_Nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            modelBuilder.ApplyConfiguration<Reservaciones>(new ReservacionConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
