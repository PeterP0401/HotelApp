using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain;
using Hotel_App.Data;

namespace Hotel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_clientesController : ControllerBase
    {
        private readonly Hotel_AppContext _context;

        public Usuario_clientesController(Hotel_AppContext context)
        {
            _context = context;
        }

        // GET: api/Usuario_clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario_clientes>>> GetUsuario_clientes()
        {
            return await _context.Usuario_clientes.ToListAsync();
        }

        // GET: api/Usuario_clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario_clientes>> GetUsuario_clientes(int id)
        {
            var usuario_clientes = await _context.Usuario_clientes.FindAsync(id);

            if (usuario_clientes == null)
            {
                return NotFound();
            }

            return usuario_clientes;
        }

        // PUT: api/Usuario_clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario_clientes(int id, Usuario_clientes usuario_clientes)
        {
            if (id != usuario_clientes.Id_Clientes)
            {
                return BadRequest();
            }

            _context.Entry(usuario_clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuario_clientesExists(id))
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

        // POST: api/Usuario_clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario_clientes>> PostUsuario_clientes(Usuario_clientes usuario_clientes)
        {
            _context.Usuario_clientes.Add(usuario_clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario_clientes", new { id = usuario_clientes.Id_Clientes }, usuario_clientes);
        }

        // DELETE: api/Usuario_clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario_clientes>> DeleteUsuario_clientes(int id)
        {
            var usuario_clientes = await _context.Usuario_clientes.FindAsync(id);
            if (usuario_clientes == null)
            {
                return NotFound();
            }

            _context.Usuario_clientes.Remove(usuario_clientes);
            await _context.SaveChangesAsync();

            return usuario_clientes;
        }

        private bool Usuario_clientesExists(int id)
        {
            return _context.Usuario_clientes.Any(e => e.Id_Clientes == id);
        }
    }
}
