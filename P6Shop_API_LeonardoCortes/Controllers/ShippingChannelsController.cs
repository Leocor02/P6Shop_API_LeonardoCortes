using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P6Shop_API_LeonardoCortes.Attributes;
using P6Shop_API_LeonardoCortes.Models;

namespace P6Shop_API_LeonardoCortes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ShippingChannelsController : ControllerBase
    {
        private readonly P6SHOPPINGContext _context;

        public ShippingChannelsController(P6SHOPPINGContext context)
        {
            _context = context;
        }

        // GET: api/ShippingChannels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingChannel>>> GetShippingChannels()
        {
            return await _context.ShippingChannels.ToListAsync();
        }

        // GET: api/ShippingChannels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingChannel>> GetShippingChannel(int id)
        {
            var shippingChannel = await _context.ShippingChannels.FindAsync(id);

            if (shippingChannel == null)
            {
                return NotFound();
            }

            return shippingChannel;
        }

        // PUT: api/ShippingChannels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingChannel(int id, ShippingChannel shippingChannel)
        {
            if (id != shippingChannel.IdshippingChannel)
            {
                return BadRequest();
            }

            _context.Entry(shippingChannel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingChannelExists(id))
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

        // POST: api/ShippingChannels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShippingChannel>> PostShippingChannel(ShippingChannel shippingChannel)
        {
            _context.ShippingChannels.Add(shippingChannel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippingChannel", new { id = shippingChannel.IdshippingChannel }, shippingChannel);
        }

        // DELETE: api/ShippingChannels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingChannel(int id)
        {
            var shippingChannel = await _context.ShippingChannels.FindAsync(id);
            if (shippingChannel == null)
            {
                return NotFound();
            }

            _context.ShippingChannels.Remove(shippingChannel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShippingChannelExists(int id)
        {
            return _context.ShippingChannels.Any(e => e.IdshippingChannel == id);
        }
    }
}
