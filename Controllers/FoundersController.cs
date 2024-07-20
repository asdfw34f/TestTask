using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/founders")]
    [ApiController]
    public class FoundersController: ControllerBase
    {
        private readonly ApplicationContext _context;

        public FoundersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var founders = _context.Founders.ToList();
            return Ok(founders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var founder = _context.Founders.Find(id);
            if (founder == null)
            {
                return NotFound();
            }
            return Ok(founder);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Create([FromBody] Founder founder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Founders.Add(founder);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Founder founder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            founder.Id = id;
            _context.Founders.Update(founder);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var founder = _context.Founders.Find(id);
            if (founder == null)
            {
                return NotFound();
            }
            _context.Remove(founder);
            _context.SaveChanges();
            return Ok();
        }

    }
}
