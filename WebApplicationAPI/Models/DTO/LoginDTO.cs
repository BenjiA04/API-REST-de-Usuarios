using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        public string nombreUsuario { get; set; }
        [Required]
        public string contraseña { get; set; }
    }
}
