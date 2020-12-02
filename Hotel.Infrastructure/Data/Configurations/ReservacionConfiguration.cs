using Hotel.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Data.Configurations
{
    public class ReservacionConfiguration : IEntityTypeConfiguration<Reservaciones>
    {
        public void Configure(EntityTypeBuilder<Reservaciones> builder)
        {
            builder.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservac__9E953BE126C5B0A6");

            builder.Property(e => e.IdReserva).HasColumnName("Id_Reserva");

            builder.Property(e => e.ApellidosR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Apellidos_R");

            builder.Property(e => e.EmailR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Email_R");

            builder.Property(e => e.EspecificaionR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Especificaion_R");

            builder.Property(e => e.FechaEntradaR)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Entrada_R");

            builder.Property(e => e.FechaSalidaR)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Salida_R");

            builder.Property(e => e.HabitacionR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Habitacion_R");

            builder.Property(e => e.NombreR)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_R");

            builder.Property(e => e.TelefonoR)
                    .HasMaxLength(10)
                    .HasColumnName("Telefono_R");
        }
        
    }
}
