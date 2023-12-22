using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sehaty.Data;
using Sehaty.Models;

namespace Sehaty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UmumController : ControllerBase
    {
        private readonly SehatyContext _context;

        public UmumController(SehatyContext context)
        {
            _context = context;
        }

        // GET: api/Umum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Umum>> GetUmum(int id)
        {
            var umum = await _context.Umums.FindAsync(id);

            if (umum == null)
            {
                return NotFound();
            }

            return umum;
        }

        // PUT: api/Umum/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUmum(int id, Umum umum)
        {
            if (id != umum.Id)
            {
                return BadRequest();
            }

            _context.Entry(umum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return NoContent();
        }

        // POST: api/Umum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Umum>> PostUmum(Umum umum)
        {
            _context.Umums.Add(umum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUmum", new { id = umum.Id }, umum);
        }
    }
}