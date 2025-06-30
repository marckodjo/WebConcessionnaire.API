using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebConcessionnaire.API.Data;
using WebConcessionnaire.API.Models;

namespace WebConcessionnaire.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcessionnairesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ConcessionnairesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/concessionnaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concessionnaire>>> GetConcessionnaires()
        {
            return await _context.Concessionnaires.ToListAsync();
        }

        // GET: api/concessionnaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concessionnaire>> GetConcessionnaire(int id)
        {
            var concessionnaire = await _context.Concessionnaires.FindAsync(id);

            if (concessionnaire == null)
                return NotFound();

            return concessionnaire;
        }


        // POST: api/concessionnaires
        [HttpPost]
        public async Task<ActionResult<Concessionnaire>> PostConcessionnaire(Concessionnaire concessionnaire)
        {
            _context.Concessionnaires.Add(concessionnaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConcessionnaire), new { id = concessionnaire.Id }, concessionnaire);
        }

        // PUT: api/concessionnaires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcessionnaire(int id, Concessionnaire concessionnaire)
        {
            if (id != concessionnaire.Id)
                return BadRequest();

            _context.Entry(concessionnaire).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/concessionnaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcessionnaire(int id)
        {
            var concessionnaire = await _context.Concessionnaires.FindAsync(id);
            if (concessionnaire == null)
                return NotFound();

            _context.Concessionnaires.Remove(concessionnaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
