using Hotel.Domain.Entity;
using Hotel.Domain.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Repositories
{
    public class ReservacionRepository : IReservacionesIRepository
    {
        private readonly BDHotelContext _context;
        public ReservacionRepository(BDHotelContext context)
        {
            this._context = context;   
        }
        public async Task<Domain.Entity.Reservaciones> GetReservacion(int Id_Reserva)
        {
            return await _context.Reservaciones.SingleOrDefaultAsync(Reservaciones => Reservaciones.IdReserva == Id_Reserva)
                ?? new Reservaciones();
        }

        public async Task<IEnumerable<Domain.Entity.Reservaciones>> GetReservacion()
        {
            return (IEnumerable<Domain.Entity.Reservaciones>)await _context.Reservaciones.ToListAsync();
        }
        public async Task AddReservacion(Reservaciones reservacion)
        {
            _context.Reservaciones.Add(reservacion);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteReservacion(int Id_Reserva)
        {
            var current = await GetReservacion(Id_Reserva);
            _context.Reservaciones.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;

        }
        public async Task<bool> UpdateReservacion(Reservaciones reservacion)
        {
            var current = await GetReservacion(reservacion.IdReserva);
            current.EmailR = reservacion.EmailR;
            current.NombreR = reservacion.NombreR;
            current.ApellidosR = reservacion.ApellidosR;
            current.FechaEntradaR = reservacion.FechaEntradaR;
            current.FechaSalidaR = reservacion.FechaSalidaR;
            current.TelefonoR = reservacion.TelefonoR;
            current.HabitacionR = reservacion.HabitacionR;
            current.EspecificaionR = reservacion.EspecificaionR;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }

        //Task IReservacionesIRepository.UpdateReservacion(Reservaciones reservacion)
        //{
        //    throw new System.NotImplementedException();
        //}


        // public ReservacionRepository : IReservacionesIRepository

    }
}
