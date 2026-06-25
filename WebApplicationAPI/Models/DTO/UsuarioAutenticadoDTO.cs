using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.DTO
{
    public class UsuarioAutenticadoDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombreUsuario { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La contraseña no puede contener menos de 8 caracteres.")]
        public string contraseña { get; set; }
    }
}
