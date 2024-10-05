namespace Proyectos.Models
{
    public class Usuario
    {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Clave { get; set; }
            public List<Producto>? Producto { get; set; }

        }
    }

