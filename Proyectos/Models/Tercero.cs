namespace Proyectos.Models
{
    public class Tercero
    {
        public  int Id { get; set; }
        public  string Nombre { get; set; }

        public  string Apellido { get; set; }

        public string Telefono { get; set; }

        public  string Correo { get; set; }

        public string? Direccion { get; set; }

        public  DateTime FechaNacimiento { get; set; }

        public char? Genero { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
