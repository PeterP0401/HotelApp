using Hotel.GUI.Controllers;
using Hotel.GUI.Models;
using System;
using Xunit;

namespace Hotel.XUnitTest
{
    public class UnitTest1
    {
        public ReservacionesController Controller { get; set; }
        public UnitTest1()
        {
            Controller = new ReservacionesController();
        }
        [Fact]
        public void Crear_Reservacion_Campos_Llenos()
        {

            Reservaciones ObjReservaciones = new Reservaciones
            {

            };
            //var
        }
    }
}
