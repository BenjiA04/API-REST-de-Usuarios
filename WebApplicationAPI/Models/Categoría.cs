using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    public class Categoría
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        // Relacion
        public ICollection<Producto> Productos { get; set; } // Una categoría puede tener varios productos.
    }
}
