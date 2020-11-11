using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain
{
    public class Reservaciones
    {
        [Key]
        public int Id_Reserva { get; set; }

        [EmailAddress]
        public string Email_R { get; set; }

        public string Nombre_R { get; set; }

        public string Apellidos_R { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Entrada_R { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Salida_R { get; set; }

        public int Telefono_R { get; set; }

        public string Habitacion_R { get; set; }

        public string Especificaion_R { get; set; }
    }
}
