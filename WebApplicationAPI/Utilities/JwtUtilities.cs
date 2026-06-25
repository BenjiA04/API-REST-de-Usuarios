using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Custom
{
    public class JwtUtilities
    {
        private readonly IConfiguration _config;
        public JwtUtilities(IConfiguration config)
        {
            _config = config;
        }

        public string encriptarSHA256(string texto)
        {
            // Crear el algoritmo SHA-256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir el texto a bytes y calcular el hash256
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                // Convertir el array de bytes a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Convierte a hexadecimal
                    builder.Append(bytes[i].ToString("X2"));
                }

                return builder.ToString();
            }
        }

        public string generarJWT(UsuarioAutenticado modelo)
        {
            // Crear la informacion del usuario para token
            var userClaim = new[]
            {
                new Claim(ClaimTypes.Name, modelo.nombreUsuario)
            };

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["settings:secretkey"]!));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);

            // Crear detalle de token
            var jwtConfig = new JwtSecurityToken(

                claims: userClaim,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
