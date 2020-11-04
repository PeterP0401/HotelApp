using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Domain.Entities;

namespace HotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reservaciones1Controller : ControllerBase
    {
        private readonly HotelAppContext _context;

        public Reservaciones1Controller(HotelAppContext context)
        {
            _context = context;
        }

        // GET: api/Reservaciones1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservaciones>>> GetReservaciones()
        {
            return await _context.Reservaciones.ToListAsync();
        }

        // GET: api/Reservaciones1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservaciones>> GetReservaciones(int id)
        {
            var reservaciones = await _context.Reservaciones.FindAsync(id);

            if (reservaciones == null)
            {
                return NotFound();
            }

            return reservaciones;
        }

        // PUT: api/Reservaciones1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaciones(int id, Reservaciones reservaciones)
        {
            if (id != reservaciones.Id_Reserva)
            {
                return BadRequest();
            }

            _context.Entry(reservaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservaciones1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservaciones>> PostReservaciones(Reservaciones reservaciones)
        {
            _context.Reservaciones.Add(reservaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaciones", new { id = reservaciones.Id_Reserva }, reservaciones);
        }

        // DELETE: api/Reservaciones1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservaciones>> DeleteReservaciones(int id)
        {
            var reservaciones = await _context.Reservaciones.FindAsync(id);
            if (reservaciones == null)
            {
                return NotFound();
            }

            _context.Reservaciones.Remove(reservaciones);
            await _context.SaveChangesAsync();

            return reservaciones;
        }

        private bool ReservacionesExists(int id)
        {
            return _context.Reservaciones.Any(e => e.Id_Reserva == id);
        }
    }
}
