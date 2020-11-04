using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Domain.Entities;

namespace HotelApp.Controllers
{
    public class ReservacionesController : Controller
    {
        private readonly HotelAppContext _context;

        public ReservacionesController(HotelAppContext context)
        {
            _context = context;
        }

        // GET: Reservaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservaciones.ToListAsync());
        }

        // GET: Reservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaciones = await _context.Reservaciones
                .FirstOrDefaultAsync(m => m.Id_Reserva == id);
            if (reservaciones == null)
            {
                return NotFound();
            }

            return View(reservaciones);
        }

        // GET: Reservaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Reserva,Email_R,Nombre_R,Apellidos_R,Fecha_Entrada_R,Fecha_Salida_R,Telefono_R,Habitacion_R,Especificaion_R")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaciones = await _context.Reservaciones.FindAsync(id);
            if (reservaciones == null)
            {
                return NotFound();
            }
            return View(reservaciones);
        }

        // POST: Reservaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Reserva,Email_R,Nombre_R,Apellidos_R,Fecha_Entrada_R,Fecha_Salida_R,Telefono_R,Habitacion_R,Especificaion_R")] Reservaciones reservaciones)
        {
            if (id != reservaciones.Id_Reserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionesExists(reservaciones.Id_Reserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaciones = await _context.Reservaciones
                .FirstOrDefaultAsync(m => m.Id_Reserva == id);
            if (reservaciones == null)
            {
                return NotFound();
            }

            return View(reservaciones);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaciones = await _context.Reservaciones.FindAsync(id);
            _context.Reservaciones.Remove(reservaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionesExists(int id)
        {
            return _context.Reservaciones.Any(e => e.Id_Reserva == id);
        }
    }
}
