namespace Proyectos.Models
{
    public class Producto
    {
        public int Codigo { get; set; }
        public  string Nombre { get; set; }

        public  DateTime FechaCreacion { get; set; }

        public string TipoProducto { get; set; }

        public string Marca { get; set; }

        public float? Precio { get; set; }

        public int Stock { get; set; }
    }
}
