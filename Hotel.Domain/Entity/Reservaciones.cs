using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entity
{
    public class Reservaciones
    {
        [Key]
        public int IdReserva { get; set; }

        [EmailAddress]
        public string EmailR { get; set; }

        public string NombreR { get; set; }

        public string ApellidosR { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaEntradaR { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaSalidaR { get; set; }

        public string TelefonoR { get; set; }

        public string HabitacionR { get; set; }

        public string EspecificaionR { get; set; }
    }
}
