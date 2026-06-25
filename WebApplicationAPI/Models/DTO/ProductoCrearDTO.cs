using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.DTO
{
    public class ProductoCrearDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        public int ProveedorId { get; set; }
    }
}
