using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain;
using Hotel_A.Data;

namespace Hotel_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private readonly Hotel_AContext _context;

        public ReservacionesController(Hotel_AContext context)
        {
            _context = context;
        }

        // GET: api/Reservaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservaciones>>> GetReservaciones()
        {
            return await _context.Reservaciones.ToListAsync();
        }

        // GET: api/Reservaciones/5
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

        // PUT: api/Reservaciones/5
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

        // POST: api/Reservaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservaciones>> PostReservaciones([FromBody] Reservaciones reservaciones)
        {
            _context.Reservaciones.Add(reservaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaciones", new { id = reservaciones.Id_Reserva }, reservaciones);
        }

        // DELETE: api/Reservaciones/5
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
