using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        // Relaciones
        public Categoría? Categoria { get; set; } // Un producto pertenece a una categoría.
        public Proveedor? Proveedor { get; set; } // Un producto tiene un proveedor.
    }
}
