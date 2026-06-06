using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationAPI.Models
{
    public class UsuarioAutenticado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombreUsuario { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "La contraseña no puede contener menos de 8 caracteres.")]
        public string contraseña { get; set; }
    }
}
