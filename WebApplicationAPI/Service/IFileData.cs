using WebApplicationAPI.Models;

namespace WebApplicationAPI.Service
{
    public interface IFileData
    {
        public Task Create(Usuario usuario);
        public Task<List<Usuario>> Read();
    }
}
