using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using systemProjection.Data;

namespace systemProjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratoItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ContratoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratoItem>>> GetContratoItem()
        {
            return await _context.ContratoItem.ToListAsync();
        }

        // GET: api/ContratoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratoItem>> GetContratoItem(int id)
        {
            var contratoItem = await _context.ContratoItem.FindAsync(id);

            if (contratoItem == null)
            {
                return NotFound();
            }

            return contratoItem;
        }

        // PUT: api/ContratoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratoItem(int id, ContratoItem contratoItem)
        {
            if (id != contratoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(contratoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoItemExists(id))
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

        // POST: api/ContratoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContratoItem>> PostContratoItem(ContratoItem contratoItem)
        {
            _context.ContratoItem.Add(contratoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratoItem", new { id = contratoItem.Id }, contratoItem);
        }

        // DELETE: api/ContratoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContratoItem(int id)
        {
            var contratoItem = await _context.ContratoItem.FindAsync(id);
            if (contratoItem == null)
            {
                return NotFound();
            }

            _context.ContratoItem.Remove(contratoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoItemExists(int id)
        {
            return _context.ContratoItem.Any(e => e.Id == id);
        }
    }
}
