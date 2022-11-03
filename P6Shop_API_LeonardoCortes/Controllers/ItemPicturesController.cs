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
    public class ItemPicturesController : ControllerBase
    {
        private readonly P6SHOPPINGContext _context;

        public ItemPicturesController(P6SHOPPINGContext context)
        {
            _context = context;
        }

        // GET: api/ItemPictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPicture>>> GetItemPictures()
        {
            return await _context.ItemPictures.ToListAsync();
        }

        // GET: api/ItemPictures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPicture>> GetItemPicture(int id)
        {
            var itemPicture = await _context.ItemPictures.FindAsync(id);

            if (itemPicture == null)
            {
                return NotFound();
            }

            return itemPicture;
        }

        // PUT: api/ItemPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPicture(int id, ItemPicture itemPicture)
        {
            if (id != itemPicture.IditemPicture)
            {
                return BadRequest();
            }

            _context.Entry(itemPicture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPictureExists(id))
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

        // POST: api/ItemPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPicture>> PostItemPicture(ItemPicture itemPicture)
        {
            _context.ItemPictures.Add(itemPicture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPicture", new { id = itemPicture.IditemPicture }, itemPicture);
        }

        // DELETE: api/ItemPictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPicture(int id)
        {
            var itemPicture = await _context.ItemPictures.FindAsync(id);
            if (itemPicture == null)
            {
                return NotFound();
            }

            _context.ItemPictures.Remove(itemPicture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPictureExists(int id)
        {
            return _context.ItemPictures.Any(e => e.IditemPicture == id);
        }
    }
}
