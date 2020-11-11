using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain
{
    public class Empleados
    {
        [Key]
        public int Id_Empleados { get; set; }

        [EmailAddress]
        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Puesto { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_de_Nacimiento { get; set; }

        public string Contraseña { get; set; }

        public int Telefono { get; set; }
    }
}
