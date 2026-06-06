using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Context;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext contexto)
        {
            _context = contexto;
        }

        // Metodo Post
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUser(Usuario usuario)
        {
            try
            {
                if (_CorreoDuplicado(usuario.Correo))
                {
                    return Conflict("El correo colocado ya existe");
                }
                else
                {
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetUsuario", new { id = usuario.Id });
                }
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Ocurrió un error al guardar.");
            }
        }


        // Metodo Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioID(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if(usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return usuario;
        }


        private bool _CorreoDuplicado(string correo)
        {
            return _context.Usuarios.Any(u => u.Correo == correo);
        }


        // Metodo put
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuario(int id, Usuario usuario)
        {
            if(id != usuario.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_UserExists(id))
                {
                    return NotFound("No se encontró el usuario.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool _UserExists(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }


        // Metodo delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeletUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario No Encontrado");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok(new {message = "usuario eliminado", usuario});
        }

    }
}
