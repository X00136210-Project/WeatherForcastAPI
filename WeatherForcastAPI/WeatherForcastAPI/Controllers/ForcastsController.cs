using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForcastAPI.Data; //Data folder
using WeatherForcastAPI.Models; //Models folder

namespace WeatherForcastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForcastsController : ControllerBase
    {
        private readonly WeatherForcastContext _context;

        public ForcastsController(WeatherForcastContext context)
        {
            _context = context;
        }

        // GET: api/Forcasts
        [HttpGet]
        public IEnumerable<Forcast> GetForcasts()
        {
            return _context.Forcasts;
        }

        //get by city name - changed from getting by ID
        // GET: api/Forcasts/5
        [HttpGet("{name}")]
        public IActionResult GetForcast(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var forcast = _context.Forcasts.FirstOrDefault(e => e.Name.ToUpper() == name.ToUpper());

            if (forcast == null)
            {
                return NotFound();
            }

            return Ok(forcast);
        }

        // PUT: api/Forcasts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForcast([FromRoute] string id, [FromBody] Forcast forcast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forcast.ID)
            {
                return BadRequest();
            }

            _context.Entry(forcast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForcastExists(id))
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

        // POST: api/Forcasts
        [HttpPost]
        public async Task<IActionResult> PostForcast([FromBody] Forcast forcast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Forcasts.Add(forcast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForcast", new { id = forcast.ID }, forcast);
        }

        // DELETE: api/Forcasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForcast([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var forcast = await _context.Forcasts.FindAsync(id);
            if (forcast == null)
            {
                return NotFound();
            }

            _context.Forcasts.Remove(forcast);
            await _context.SaveChangesAsync();

            return Ok(forcast);
        }

        
        private bool ForcastExists(string id)
        {
            return _context.Forcasts.Any(e => e.ID == id);
        }
    }
}