using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController: ControllerBase
    {
        private readonly ApplicationContext _context;
        
        public ClientsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _context.Clients.ToList();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            client.Id = id;
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.Remove(client);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}