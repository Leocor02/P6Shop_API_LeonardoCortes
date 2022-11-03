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
    public class UserStoresController : ControllerBase
    {
        private readonly P6SHOPPINGContext _context;

        public UserStoresController(P6SHOPPINGContext context)
        {
            _context = context;
        }

        // GET: api/UserStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStore>>> GetUserStores()
        {
            return await _context.UserStores.ToListAsync();
        }

        // GET: api/UserStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStore>> GetUserStore(int id)
        {
            var userStore = await _context.UserStores.FindAsync(id);

            if (userStore == null)
            {
                return NotFound();
            }

            return userStore;
        }

        // PUT: api/UserStores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStore(int id, UserStore userStore)
        {
            if (id != userStore.Iduser)
            {
                return BadRequest();
            }

            _context.Entry(userStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoreExists(id))
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

        // POST: api/UserStores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserStore>> PostUserStore(UserStore userStore)
        {
            _context.UserStores.Add(userStore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserStoreExists(userStore.Iduser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserStore", new { id = userStore.Iduser }, userStore);
        }

        // DELETE: api/UserStores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStore(int id)
        {
            var userStore = await _context.UserStores.FindAsync(id);
            if (userStore == null)
            {
                return NotFound();
            }

            _context.UserStores.Remove(userStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserStoreExists(int id)
        {
            return _context.UserStores.Any(e => e.Iduser == id);
        }
    }
}
