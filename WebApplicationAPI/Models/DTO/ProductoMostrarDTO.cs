namespace WebApplicationAPI.Models.DTO
{
    public class ProductoMostrarDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public string Proveedor { get; set; }
    }
}
