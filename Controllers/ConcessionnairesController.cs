using Microsoft.AspNetCore.Mvc;
using WebConcessionnaire.API.Models;
using WebConcessionnaire.API.Repositories;

namespace WebConcessionnaire.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcessionnairesController : ControllerBase
    {
        private readonly IConcessionnaireRepository _repository;

        public ConcessionnairesController(IConcessionnaireRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concessionnaire>>> GetConcessionnaires()
        {
            var concessionnaires = await _repository.GetAll();
            return concessionnaires == null ? NotFound() : Ok(concessionnaires);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Concessionnaire>> GetConcessionnaire(int id)
        {
            var resultat = await _repository.GetById(id);
            return resultat == null ? NotFound() : Ok(resultat);
        }


        [HttpPost]
        public async Task<ActionResult<Concessionnaire>> PostConcessionnaire(Concessionnaire concessionnaire)
        {
            var resultat = await _repository.Add(concessionnaire);
            return Ok(resultat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcessionnaire(int id, Concessionnaire concessionnaire)
        {
            if (id != concessionnaire.Id)
                return BadRequest();

            var resultat =  await _repository.Update(id, concessionnaire);
            return Ok(resultat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcessionnaire(int id)
        {
            var concessionnaire = await _repository.GetById(id);
            if (concessionnaire == null)
                return NotFound();

            await _repository.DeleteById(id);

            return NoContent();
        }
    }
}
