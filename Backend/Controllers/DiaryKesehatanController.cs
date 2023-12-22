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
    public class DiaryKesehatanController : ControllerBase
    {
        private readonly SehatyContext _context;

        public DiaryKesehatanController(SehatyContext context)
        {
            _context = context;
        }

        // GET: api/DiaryKesehatan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaryKesehatan>> GetDiaryKesehatan(int id)
        {
            var diaryKesehatan = await _context.DiaryKesehatans.FindAsync(id);

            if (diaryKesehatan == null)
            {
                return NotFound();
            }

            return diaryKesehatan;
        }

        // PUT: api/DiaryKesehatan/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaryKesehatan(int id, DiaryKesehatan diaryKesehatan)
        {
            if (id != diaryKesehatan.Id)
            {
                return BadRequest();
            }

            _context.Entry(diaryKesehatan).State = EntityState.Modified;

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

        // POST: api/DiaryKesehatan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaryKesehatan>> PostDiaryKesehatan(DiaryKesehatan diaryKesehatan)
        {
            _context.DiaryKesehatans.Add(diaryKesehatan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaryKesehatan", new { id = diaryKesehatan.Id }, diaryKesehatan);
        }
    }
}