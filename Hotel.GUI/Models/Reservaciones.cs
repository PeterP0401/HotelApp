using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.GUI.Models
{
    public class Reservaciones
    {
        public int IdReserva { get; set; }

        public string EmailR { get; set; }

        public string NombreR { get; set; }

        public string ApellidosR { get; set; }

        public DateTime FechaEntradaR { get; set; }

        public DateTime FechaSalidaR { get; set; }

        public string TelefonoR { get; set; }

        public string HabitacionR { get; set; }

        public string EspecificaionR { get; set; }
    }
}
