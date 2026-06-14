using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using WebApplicationAPI.Context;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.DTO;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProveedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> PostProveedor(ProveedorDTO proveedor)
        {
            var dto = new Proveedor
            {
                Nombre = proveedor.Nombre,
                Contacto = proveedor.Contacto,
            };

            try
            {
                _context.Proveedores.Add(dto);
                await _context.SaveChangesAsync();
                return Ok(dto);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Ocurrió un error al guardar.");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Proveedor eliminado", proveedor });
        }
    }
}
