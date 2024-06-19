using Microsoft.AspNetCore.Mvc;
using Segundo_Parcial.Models;
using System.Collections.Generic;
using System.Linq;

namespace Segundo_Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Nombre = "Alice", Apellido = "Johnson", Documento = "1234567890", Telefono = "1234567890" }
        };

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Simulate auto-incrementing primary key
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        // PUT api/user/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.Nombre = user.Nombre;
            existingUser.Apellido = user.Apellido;
            existingUser.Documento = user.Documento;
            existingUser.Direccion = user.Direccion;
            existingUser.Email = user.Email;
            existingUser.Telefono = user.Telefono;
            existingUser.Estado = user.Estado;

            return NoContent();
        }

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
