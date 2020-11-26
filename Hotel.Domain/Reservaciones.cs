namespace Hotel.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservaciones
    {
        [Key]
        public int Id_Reserva { get; set; }

        [StringLength(30)]
        public string Email_R { get; set; }

        [StringLength(30)]
        public string Nombre_R { get; set; }

        [StringLength(30)]
        public string Apellidos_R { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Entrada_R { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Salida_R { get; set; }

        [StringLength(10)]
        public string Telefono_R { get; set; }

        [StringLength(30)]
        public string Habitacion_R { get; set; }

        [StringLength(30)]
        public string Especificaion_R { get; set; }
    }
}
