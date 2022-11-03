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
    public class InvoiceInventoriesController : ControllerBase
    {
        private readonly P6SHOPPINGContext _context;

        public InvoiceInventoriesController(P6SHOPPINGContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceInventory>>> GetInvoiceInventories()
        {
            return await _context.InvoiceInventories.ToListAsync();
        }

        // GET: api/InvoiceInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceInventory>> GetInvoiceInventory(int id)
        {
            var invoiceInventory = await _context.InvoiceInventories.FindAsync(id);

            if (invoiceInventory == null)
            {
                return NotFound();
            }

            return invoiceInventory;
        }

        // PUT: api/InvoiceInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceInventory(int id, InvoiceInventory invoiceInventory)
        {
            if (id != invoiceInventory.InvoiceIdinvoice)
            {
                return BadRequest();
            }

            _context.Entry(invoiceInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceInventoryExists(id))
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

        // POST: api/InvoiceInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceInventory>> PostInvoiceInventory(InvoiceInventory invoiceInventory)
        {
            _context.InvoiceInventories.Add(invoiceInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvoiceInventoryExists(invoiceInventory.InvoiceIdinvoice))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvoiceInventory", new { id = invoiceInventory.InvoiceIdinvoice }, invoiceInventory);
        }

        // DELETE: api/InvoiceInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceInventory(int id)
        {
            var invoiceInventory = await _context.InvoiceInventories.FindAsync(id);
            if (invoiceInventory == null)
            {
                return NotFound();
            }

            _context.InvoiceInventories.Remove(invoiceInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceInventoryExists(int id)
        {
            return _context.InvoiceInventories.Any(e => e.InvoiceIdinvoice == id);
        }
    }
}
