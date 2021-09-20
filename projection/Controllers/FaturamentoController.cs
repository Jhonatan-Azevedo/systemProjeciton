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
    public class FaturamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FaturamentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Faturamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faturamento>>> GetFaturamentos()
        {
            return await _context.Faturamentos.ToListAsync();
        }

        // GET: api/Faturamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faturamento>> GetFaturamento(int id)
        {
            var faturamento = await _context.Faturamentos.FindAsync(id);

            if (faturamento == null)
            {
                return NotFound();
            }

            return faturamento;
        }

        // PUT: api/Faturamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaturamento(int id, Faturamento faturamento)
        {
            if (id != faturamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(faturamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaturamentoExists(id))
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

        // POST: api/Faturamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Faturamento>> PostFaturamento(Faturamento faturamento)
        {
            _context.Faturamentos.Add(faturamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaturamento", new { id = faturamento.Id }, faturamento);
        }

        // DELETE: api/Faturamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaturamento(int id)
        {
            var faturamento = await _context.Faturamentos.FindAsync(id);
            if (faturamento == null)
            {
                return NotFound();
            }

            _context.Faturamentos.Remove(faturamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaturamentoExists(int id)
        {
            return _context.Faturamentos.Any(e => e.Id == id);
        }
    }
}
