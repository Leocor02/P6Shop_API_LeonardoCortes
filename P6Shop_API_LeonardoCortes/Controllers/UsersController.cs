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
    //[ApiKey]
    public class UsersController : ControllerBase
    {
        private readonly P6SHOPPINGContext _context;

        public Tools.Crypto MyCrypto { get; set; }

        public UsersController(P6SHOPPINGContext context)
        {
            _context = context;
            MyCrypto = new Tools.Crypto();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/GetUserInfo?email=luis%40gmail.com
        [HttpGet("GetUserInfo")]
        public ActionResult<IEnumerable<UserDTO>> GetUserInfo(string email)
        {
            //las consultas linq se parecen mucho a las que normales que hemos hecho en T-SQL
            //una de las diferencias es que podemos usar una "tabla temporal" para almacenar
            //los resultados y luego usarla para llenar los atributos de un modelo DTO
            var query = (from u in _context.Users
                         join r in _context.UserRoles on u.IduserRole equals r.IduserRole
                         join c in _context.Countries on u.Idcountry equals c.Idcountry
                         where u.Email == email && u.Active == true
                         select new
                         {
                          idusuario = u.Iduser,
                          nombre = u.Name,
                          email = u.Email,
                          correorespaldo = u.BackUpEmail,
                          telefono = u.PhoneNumber,
                          idrol = r.IduserRole,
                          idpais = c.Idcountry,
                          roldesc = r.UserRoleDescription,
                          pais = c.CountryName
                         }).ToList();

            List<UserDTO> list = new List<UserDTO>();

            foreach (var item in query)
            {
                UserDTO NewItem = new UserDTO();

                NewItem.IDUsuario = item.idusuario;
                NewItem.Nombre = item.nombre;
                NewItem.CorreoElectronico = item.email;
                NewItem.CorreoRespaldo = item.correorespaldo;
                NewItem.NumeroTelefono = item.telefono;
                NewItem.IDRol = item.idrol;
                NewItem.IDPais = item.idpais;
                NewItem.RolDescripcion = item.roldesc;
                NewItem.PaisNombre = item.pais;

                list.Add(NewItem);
            }
            
            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // GET: api/Users/ValidateLogin?UserName=adf&UserPassword=123
        [HttpGet("ValidateLogin")]
        public async Task<ActionResult<User>> ValidateLogin(string UserName, string UserPassword)
        {
            string ApiLevelEncryptedPassword = MyCrypto.EncriptarEnUnSentido(UserPassword);

            var user = await _context.Users.SingleOrDefaultAsync(e => e.Email == UserName &&
            e.UserPassword == ApiLevelEncryptedPassword);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Iduser)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            string ApiLevelEncryptedPass = MyCrypto.EncriptarEnUnSentido(user.UserPassword);

            user.UserPassword = ApiLevelEncryptedPass;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Iduser }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Iduser == id);
        }
    }
}
