using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Models;
using WebApp.Infrastructure;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HubsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hub>>> GetHubs()
        {
            return await _context.Hubs.ToListAsync();
        }

        // GET: api/Hubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hub>> GetHub(int id)
        {
            var hub = await _context.Hubs.FindAsync(id);

            if (hub == null)
            {
                return NotFound();
            }

            return hub;
        }

        // PUT: api/Hubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHub(int id, Hub hub)
        {
            if (id != hub.Id)
            {
                return BadRequest();
            }

            _context.Entry(hub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubExists(id))
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

        // POST: api/Hubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hub>> PostHub(Hub hub)
        {
            _context.Hubs.Add(hub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHub", new { id = hub.Id }, hub);
        }

        // DELETE: api/Hubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHub(int id)
        {
            var hub = await _context.Hubs.FindAsync(id);
            if (hub == null)
            {
                return NotFound();
            }

            _context.Hubs.Remove(hub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HubExists(int id)
        {
            return _context.Hubs.Any(e => e.Id == id);
        }
    }
}
