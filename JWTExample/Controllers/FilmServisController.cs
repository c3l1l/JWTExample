using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTExample.Models;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmServisController : ControllerBase
    {
        private readonly FilmDBContext _context;

        public FilmServisController(FilmDBContext context)
        {
            _context = context;
        }

        // GET: api/FilmServis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filmler>>> GetFilmlers()
        {
            return await _context.Filmlers.ToListAsync();
        }

        // GET: api/FilmServis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filmler>> GetFilmler(int id)
        {
            var filmler = await _context.Filmlers.FindAsync(id);

            if (filmler == null)
            {
                return NotFound();
            }

            return filmler;
        }

        // PUT: api/FilmServis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmler(int id, Filmler filmler)
        {
            if (id != filmler.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(filmler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmlerExists(id))
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

        // POST: api/FilmServis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filmler>> PostFilmler(Filmler filmler)
        {
            _context.Filmlers.Add(filmler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmler", new { id = filmler.FilmId }, filmler);
        }

        // DELETE: api/FilmServis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmler(int id)
        {
            var filmler = await _context.Filmlers.FindAsync(id);
            if (filmler == null)
            {
                return NotFound();
            }

            _context.Filmlers.Remove(filmler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmlerExists(int id)
        {
            return _context.Filmlers.Any(e => e.FilmId == id);
        }
    }
}
