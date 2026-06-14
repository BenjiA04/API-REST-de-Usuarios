using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Contacto { get; set; }
        
        // Relacion
        public ICollection<Producto> Productos { get; set; } // Un proveedor puede proporcionar varios productos.

    }
}
