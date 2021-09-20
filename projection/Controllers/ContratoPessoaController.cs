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
    public class ContratoPessoaController : ControllerBase
    {
        private readonly AppDbContext _context;
        //teste
        public ContratoPessoaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ContratoPessoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratoPessoa>>> GetContratoPessoa()
        {
            return await _context.ContratoPessoa.ToListAsync();
        }

        // GET: api/ContratoPessoa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratoPessoa>> GetContratoPessoa(int id)
        {
            var contratoPessoa = await _context.ContratoPessoa.FindAsync(id);

            if (contratoPessoa == null)
            {
                return NotFound();
            }

            return contratoPessoa;
        }

        // PUT: api/ContratoPessoa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratoPessoa(int id, ContratoPessoa contratoPessoa)
        {
            if (id != contratoPessoa.Id)
            {
                return BadRequest();
            }

            _context.Entry(contratoPessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoPessoaExists(id))
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

        // POST: api/ContratoPessoa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContratoPessoa>> PostContratoPessoa(ContratoPessoa contratoPessoa)
        {
            _context.ContratoPessoa.Add(contratoPessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratoPessoa", new { id = contratoPessoa.Id }, contratoPessoa);
        }

        // DELETE: api/ContratoPessoa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContratoPessoa(int id)
        {
            var contratoPessoa = await _context.ContratoPessoa.FindAsync(id);
            if (contratoPessoa == null)
            {
                return NotFound();
            }

            _context.ContratoPessoa.Remove(contratoPessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoPessoaExists(int id)
        {
            return _context.ContratoPessoa.Any(e => e.Id == id);
        }
    }
}
