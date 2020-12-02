using Hotel.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IReservacionesIRepository
    {

        Task AddReservacion(Reservaciones reservacion);
        Task<bool> DeleteReservacion(int Id_Reserva);
        Task <IEnumerable<Reservaciones>> GetReservacion();
        Task<Reservaciones> GetReservacion(int Id_Reserva);
        Task<bool> UpdateReservacion(Reservaciones reservacion);

    }
}
