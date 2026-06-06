using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Custom;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using WebApplicationAPI.Context;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Utilidades _utilidades;
        public AccesoController(AppDbContext context, Utilidades utilidades)
        {
            _context = context;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> registrarUser(UsuarioDTO objeto)
        {
            var modeloUsuario = new UsuarioAutenticado
            {
                nombreUsuario = objeto.nombreUsuario,
                contraseña = _utilidades.encriptarSHA256(objeto.contraseña)
            };

            await _context.UsuarioAutenticados.AddAsync(modeloUsuario);
            await _context.SaveChangesAsync();

            if (modeloUsuario.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _context.UsuarioAutenticados
                                          .Where(u => u.nombreUsuario == objeto.nombreUsuario &&
                                                 u.contraseña == _utilidades.encriptarSHA256(objeto.contraseña))
                                          .FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado) });
        }

        [HttpPost]
        [Route("RefrescarToken")]
        [Authorize]
        public async Task<IActionResult> refrezcarToken()
        {
            var nombreUsuario = User.Identity?.Name;

            if (string.IsNullOrEmpty(nombreUsuario))
                return Unauthorized();

            var usuario = await _context.UsuarioAutenticados
                .FirstOrDefaultAsync(u => u.nombreUsuario == nombreUsuario);

            if (usuario == null)
                return Unauthorized();

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuario) });
        }
    }
}
