using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inzOprogramowania.DataContext;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AdsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Ads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ads>>> GetAds()
        {
          if (_context.Ads == null)
          {
              return NotFound();
          }
            return await _context.Ads.ToListAsync();
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ads>> GetAds(long id)
        {
          if (_context.Ads == null)
          {
              return NotFound();
          }
            var ads = await _context.Ads.FindAsync(id);

            if (ads == null)
            {
                return NotFound();
            }

            return ads;
        }

        // PUT: api/Ads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAds(long id, Ads ads)
        {
            if (id != ads.AdsId)
            {
                return BadRequest();
            }

            _context.Entry(ads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsExists(id))
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

        // POST: api/Ads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ads>> PostAds(Ads ads)
        {
          if (_context.Ads == null)
          {
              return Problem("Entity set 'DatabaseContext.Ads'  is null.");
          }
            _context.Ads.Add(ads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAds", new { id = ads.AdsId }, ads);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAds(long id)
        {
            if (_context.Ads == null)
            {
                return NotFound();
            }
            var ads = await _context.Ads.FindAsync(id);
            if (ads == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ads);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdsExists(long id)
        {
            return (_context.Ads?.Any(e => e.AdsId == id)).GetValueOrDefault();
        }
    }
}
