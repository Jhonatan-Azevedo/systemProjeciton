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
    public class ContratoItemParceiroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratoItemParceiroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ContratoItemParceiro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratoItemParceiro>>> GetContratoItemParceiros()
        {
            return await _context.ContratoItemParceiros.ToListAsync();
        }

        // GET: api/ContratoItemParceiro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratoItemParceiro>> GetContratoItemParceiro(int id)
        {
            var contratoItemParceiro = await _context.ContratoItemParceiros.FindAsync(id);

            if (contratoItemParceiro == null)
            {
                return NotFound();
            }

            return contratoItemParceiro;
        }

        // PUT: api/ContratoItemParceiro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratoItemParceiro(int id, ContratoItemParceiro contratoItemParceiro)
        {
            if (id != contratoItemParceiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(contratoItemParceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoItemParceiroExists(id))
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

        // POST: api/ContratoItemParceiro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContratoItemParceiro>> PostContratoItemParceiro(ContratoItemParceiro contratoItemParceiro)
        {
            _context.ContratoItemParceiros.Add(contratoItemParceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratoItemParceiro", new { id = contratoItemParceiro.Id }, contratoItemParceiro);
        }

        // DELETE: api/ContratoItemParceiro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContratoItemParceiro(int id)
        {
            var contratoItemParceiro = await _context.ContratoItemParceiros.FindAsync(id);
            if (contratoItemParceiro == null)
            {
                return NotFound();
            }

            _context.ContratoItemParceiros.Remove(contratoItemParceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoItemParceiroExists(int id)
        {
            return _context.ContratoItemParceiros.Any(e => e.Id == id);
        }
    }
}
