using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Context;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.DTO;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriasDTO>> PostProveedor(CategoriasDTO categoria)
        {
            var dto = new Categoría
            {
                Nombre = categoria.Nombre,
            };

            try
            {
                _context.Categorías.Add(dto);
                await _context.SaveChangesAsync();
                return Ok(dto);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Ocurrió un error al guardar.");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorías.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorías.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Proveedor eliminado", categoria });
        }
    }
}
