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
    public class TenagaKesehatanController : ControllerBase
    {
        private readonly SehatyContext _context;

        public TenagaKesehatanController(SehatyContext context)
        {
            _context = context;
        }

        // GET: api/TenagaKesehatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenagaKesehatan>>> GetAllTenagaKesehatan()
        {
            return await _context.TenagaKesehatans.ToListAsync();
        }

        // GET: api/TenagaKesehatan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TenagaKesehatan>> GetTenagaKesehatan(int id)
        {
            var tenagaKesehatan = await _context.TenagaKesehatans.FindAsync(id);

            if (tenagaKesehatan == null)
            {
                return NotFound();
            }

            return tenagaKesehatan;
        }

        // PUT: api/TenagaKesehatan/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenagaKesehatan(int id, TenagaKesehatan tenagaKesehatan)
        {
            if (id != tenagaKesehatan.Id)
            {
                return BadRequest();
            }

            _context.Entry(tenagaKesehatan).State = EntityState.Modified;

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

        // POST: api/TenagaKesehatan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TenagaKesehatan>> PostTenagaKesehatan(TenagaKesehatan tenagaKesehatan)
        {
            _context.TenagaKesehatans.Add(tenagaKesehatan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenagaKesehatan", new { id = tenagaKesehatan.Id }, tenagaKesehatan);
        }
    }
}