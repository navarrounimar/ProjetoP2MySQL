using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.Contexto;
using ProjetoP2.Models;

namespace ProjetoP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiosController : ControllerBase
    {
        private readonly RoletaContextMySQL _context;

        public PremiosController(RoletaContextMySQL context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Premio>> GetPremios()
        {
            return _context.Premios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Premio> GetPremio(int id)
        {
            var premio = _context.Premios.Find(id);

            if (premio == null)
            {
                return NotFound();
            }

            return premio;
        }

        [HttpPost]
        public ActionResult<Premio> PostPremio(Premio premio)
        {
            _context.Premios.Add(premio);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPremio), new { id = premio.Id }, premio);
        }

        [HttpPut("{id}")]
        public IActionResult PutPremio(int id, Premio premio)
        {
            if (id != premio.Id)
            {
                return BadRequest();
            }

            _context.Entry(premio).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePremio(int id)
        {
            var premio = _context.Premios.Find(id);

            if (premio == null)
            {
                return NotFound();
            }

            _context.Premios.Remove(premio);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
