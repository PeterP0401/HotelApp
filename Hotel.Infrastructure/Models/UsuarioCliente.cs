using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Infrastructure.Models
{
    public partial class UsuarioCliente
    {
        public int IdClientes { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
    }
}
