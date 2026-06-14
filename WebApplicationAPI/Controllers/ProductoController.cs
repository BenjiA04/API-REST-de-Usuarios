using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Context;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> PostProducto(Producto productos)
        {
            var categoriaExiste = await _context.Categorías.AnyAsync(c => c.Id == productos.CategoriaId);
            var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.Id == productos.ProveedorId);

            var dto = new Producto
            {
                Nombre = productos.Nombre,
                Precio = productos.Precio,
                Stock = productos.Stock,
                CategoriaId = productos.CategoriaId,
                ProveedorId = productos.ProveedorId
            };

            if (categoriaExiste == null || proveedorExiste == null)
                return BadRequest("Categoría o proveedor no existen.");

            try
            {
                _context.Productos.Add(dto);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProducto", new { id = dto.Id });
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Ocurrió un error al guardar.");
            }
        }

        [HttpGet("BusquedaPersonalizada")]
        public async Task<ActionResult> GetProducto()
        {
            var maximo = await _context.Productos
                                .Include(p => p.Categoria)
                                .Include(p => p.Proveedor)
                                .OrderByDescending(p => p.Precio)
                                .FirstOrDefaultAsync();

            var minimo = await _context.Productos
                                .Include(p => p.Categoria)
                                .Include(p => p.Proveedor)
                                .OrderBy(p => p.Precio)
                                .FirstOrDefaultAsync();

            var sumaTotal = await _context.Productos.SumAsync(p => p.Precio);
            var promedioTotal = await _context.Productos.AverageAsync(p => p.Precio);


            if (maximo == null)
                return NotFound();

            var productoMasCaro = new ProductoDTO
            {
                Id = maximo.Id,
                Nombre = maximo.Nombre,
                Precio = maximo.Precio,
                Stock = maximo.Stock,
                Categoria = maximo.Categoria.Nombre,
                Proveedor = maximo.Proveedor.Nombre
            };

            var productoMasBarato = new ProductoDTO
            {
                Id = minimo.Id,
                Nombre = minimo.Nombre,
                Precio = minimo.Precio,
                Stock = minimo.Stock,
                Categoria = minimo.Categoria.Nombre,
                Proveedor = minimo.Proveedor.Nombre
            };

            return Ok(new
            {
                ProductoMasCaro = productoMasCaro,
                ProductoMasBarato = productoMasBarato,
                SumaTotal = sumaTotal,
                PromedioTotal = promedioTotal
            });
        }

        [HttpGet("BuscarPorCategoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductosPorCategoria(string categoria)
        {
            var categoriaBuscada = await _context.Productos
                                         .Include(p => p.Categoria)
                                         .Include(p => p.Proveedor)
                                         .Where(p => p.Categoria.Nombre == categoria)
                                         .ToListAsync();

            var productosDTO = categoriaBuscada.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
                Categoria = p.Categoria.Nombre,
                Proveedor = p.Proveedor.Nombre
            }).ToList();

            if (categoriaBuscada == null)
            {
                return NotFound("Esta categoria no contiene productos");
            }

            return productosDTO;
        }

        [HttpGet("BuscarPorProveedor/{proveedor}")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductosPorProveedor(string proveedor)
        {
            var proveedorBuscado = await _context.Productos
                                         .Include(p => p.Categoria)
                                         .Include(p => p.Proveedor)
                                         .Where(p => p.Proveedor.Nombre == proveedor)
                                         .ToListAsync();

            var productosDTO = proveedorBuscado.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
                Categoria = p.Categoria.Nombre,
                Proveedor = p.Proveedor.Nombre
            }).ToList();

            if (proveedorBuscado == null)
            {
                return NotFound("Este proveedor no esta en el sistema o no contiene productos");
            }

            return productosDTO;
        }

        [HttpGet("CantidadProductos")]
        public async Task<ActionResult> GetTotalProductos()
        {
            var totalProductos = await _context.Productos.CountAsync();

            return Ok($"Total: {totalProductos}");
        }
    }
}
