using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmigosController : ControllerBase
    {
        private readonly AmigoDbContext _context;

        public AmigosController(AmigoDbContext context)
        {
            _context = context;
        }

        // GET: api/Amigos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amigo>>> Getamigo()
        {
          if (_context.amigo == null)
          {
              return NotFound();
          }
            return await _context.amigo.ToListAsync();
        }

        // GET: api/Amigos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amigo>> GetAmigo(int id)
        {
          if (_context.amigo == null)
          {
              return NotFound();
          }
            var amigo = await _context.amigo.FindAsync(id);

            if (amigo == null)
            {
                return NotFound();
            }

            return amigo;
        }

        // PUT: api/Amigos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmigo(int id, Amigo amigo)
        {
            if (id != amigo.Id)
            {
                return BadRequest();
            }

            _context.Entry(amigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
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

        // POST: api/Amigos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amigo>> PostAmigo(Amigo amigo)
        {
          if (_context.amigo == null)
          {
              return Problem("Entity set 'AmigoDbContext.amigo'  is null.");
          }
            _context.amigo.Add(amigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmigo", new { id = amigo.Id }, amigo);
        }

        // DELETE: api/Amigos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmigo(int id)
        {
            if (_context.amigo == null)
            {
                return NotFound();
            }
            var amigo = await _context.amigo.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }

            _context.amigo.Remove(amigo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmigoExists(int id)
        {
            return (_context.amigo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
