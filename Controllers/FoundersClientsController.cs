using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class FoundersClientsController : Controller
    {
        private readonly ApplicationContext _context;

        public FoundersClientsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rows = _context.FoundersClients.ToList();
            return Ok(rows);
        }

        [HttpGet("{clientId}")]
        public IActionResult GetFoundersByClientId([FromRoute] int clientId)
        {
            var rows = _context.FoundersClients.Where(r => r.ClientId == clientId).ToList();
            if (rows == null || rows.Count == 0)
            {
                return NotFound();
            }
            return Ok(rows);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Create([FromBody] FoundersClients foundersClients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.FoundersClients.Add(foundersClients);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        { 
            var row = await _context.FoundersClients.FindAsync(id);
            if (row == null)
            {
                return NotFound();
            }
            _context.Remove(row);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
