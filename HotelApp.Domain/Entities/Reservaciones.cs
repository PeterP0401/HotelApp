using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelApp.Domain.Entities
{
    public class Reservaciones
    {
        [Key]
        public int Id_Reserva { get; set; }
        [EmailAddress]
        public string Email_R { get; set; }

        public string Nombre_R { get; set; }

        public string Apellidos_R { get; set; }

        public DateTime Fecha_Entrada_R { get; set; }

        public DateTime Fecha_Salida_R { get; set; }

        public Int64 Telefono_R { get; set; }

        public string Habitacion_R { get; set; }

        public string Especificaion_R { get; set; }
    }
}
