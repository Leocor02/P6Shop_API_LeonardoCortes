using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P6Shop_API_LeonardoCortes.Attributes;
using P6Shop_API_LeonardoCortes.Models;
using P6Shop_API_LeonardoCortes.Models.DTOs;

namespace P6Shop_API_LeonardoCortes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class InventoriesController : ControllerBase
    {
        private readonly P6SHOPPINGContext _context;

        public InventoriesController(P6SHOPPINGContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            return await _context.Inventories.ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // Get: api/Inventories/GetItemList
        [HttpGet("GetItemList")]
        public ActionResult<IEnumerable<ItemDTO>> GetItemList()
        {
            var query = from i in _context.Inventories
                        where i.Active == true
                        select new
                        {
                            ID = i.Idinventory,
                            Name = i.ItemName,
                            Description = i.ItemDescription,
                            MainImageURL = i.ItemImageUrl,
                            Price = i.ItemPrice,
                            Stock = i.ItemStock,
                            SKU = i.ItemSku,
                            ManufacturerNumber = i.ItemManufacturerNumber,
                            UPC = i.ItemUpc,
                            IDCurrency = i.Idcurrency,
                            IDStore = i.Idstore
                        };

            List < ItemDTO > inventoryList = new List<ItemDTO>();
            
            foreach (var item in query)
            {
                inventoryList.Add(
                    new ItemDTO
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        MainImageURL = item.MainImageURL,
                        Price = item.Price,
                        Stock = item.Stock,
                        SKU = item.SKU, 
                        ManufacturerNumber = item.ManufacturerNumber,
                        UPC = item.UPC,
                        IDCurrency = item.IDCurrency,
                        IDStore = item.IDStore
                    }
                    );
            }

            if (inventoryList == null)
            {
                return NotFound();
            }

            return inventoryList;
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.Idinventory)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Idinventory }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Idinventory == id);
        }
    }
}
