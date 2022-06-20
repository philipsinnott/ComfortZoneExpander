using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComfortZoneExpanderAPI.Models;

namespace ComfortZoneExpanderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyItemController : ControllerBase
    {
        private readonly DailyItemContext _context;

        public DailyItemController(DailyItemContext context)
        {
            _context = context;
        }

        // GET: api/DailyItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyItem>>> GetDailyItems()
        {
          if (_context.DailyItems == null)
          {
              return NotFound();
          }
            return await _context.DailyItems.ToListAsync();
        }

        // GET: api/DailyItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyItem>> GetDailyItem(int id)
        {
          if (_context.DailyItems == null)
          {
              return NotFound();
          }
            var dailyItem = await _context.DailyItems.FindAsync(id);

            if (dailyItem == null)
            {
                return NotFound();
            }

            return dailyItem;
        }

        // PUT: api/DailyItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyItem(int id, DailyItem dailyItem)
        {
            if (id != dailyItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyItemExists(id))
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

        // POST: api/DailyItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyItem>> PostDailyItem(DailyItem dailyItem)
        {
          if (_context.DailyItems == null)
          {
              return Problem("Entity set 'DailyItemContext.DailyItems'  is null.");
          }
            _context.DailyItems.Add(dailyItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyItem", new { id = dailyItem.Id }, dailyItem);
        }

        // DELETE: api/DailyItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyItem(int id)
        {
            if (_context.DailyItems == null)
            {
                return NotFound();
            }
            var dailyItem = await _context.DailyItems.FindAsync(id);
            if (dailyItem == null)
            {
                return NotFound();
            }

            _context.DailyItems.Remove(dailyItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyItemExists(int id)
        {
            return (_context.DailyItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
