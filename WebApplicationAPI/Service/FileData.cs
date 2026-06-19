using System.Text.Json;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Service
{
    public class FileData:IFileData
    {
        private string _path = Path.Combine(Directory.GetCurrentDirectory(), "Files");

        public async Task Create(Usuario usuario)
        {
            // Si la carpteta no exite la crea.
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            string filePath = Path.Combine(_path, "usuarios.txt");

            using (StreamWriter p = new StreamWriter(filePath, true))
            {
                await Task.Delay(1000);
                var json = JsonSerializer.Serialize(usuario);
                await p.WriteLineAsync(json);
            }
        }

        public async Task<List<Usuario>> Read()
        {
            string filePath = Path.Combine(_path, "usuarios.txt");
            List<Usuario> usuarios = new List<Usuario>();

            if (!File.Exists(filePath))
            {
                return usuarios;
            }

            using (StreamReader p = new StreamReader(filePath))
            {
                string? linea;

                while ((linea = await p.ReadLineAsync()) != null)
                {
                    Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);

                    if (usuario != null)
                    {
                        await Task.Delay(1000);
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }
    }
}
