namespace Proyectos.Models.Conex
{
    public class DB
    {
        public List<Tercero> LstTerceros { get; set; }
        public List<Producto> LstProductos { get; set; }

        public DB()
        {
            this.LstTerceros = new List<Tercero>();
            this.InicializarLstTerceros();

            this.LstProductos = new List<Producto>();
            this.InicializarLdtProductos();
        }
        public void InicializarLstTerceros()
        {
            Tercero tercerUno = new Tercero
            {
                Nombre = "Brayan",
                Apellido = "Amesquita",
                Correo = "Brayan@gmail.com",
                Direccion="Cra 27b #57c 23 sur",
                FechaNacimiento = DateTime.Now,
                Id = 1,
                Telefono = "3947493903",
                Genero = 'f'

            };
            Tercero tercerDos = new Tercero
            {
                Nombre = "Maria",
                Apellido = "Casillas",
                Correo = "Maria@gmail.com",
                Direccion = "Cra 27b #57c 23 sur",
                FechaNacimiento = DateTime.Now,
                Id = 2,
                Telefono = "584846546",
                Genero = 'M'
            };
            Tercero tercerTres = new Tercero
            {
                Nombre = "Edgar",
                Apellido = "Suarez",
                Correo = "EdgarS@gmail.com",
                Direccion = "Cra 27b #57c 23 sur",
                FechaNacimiento = DateTime.Now,
                Id = 3,
                Telefono = "5656546541",
                Usuario = { }
            };
            this.LstTerceros.Add(tercerUno);
            this.LstTerceros.Add(tercerDos);
            this.LstTerceros.Add(tercerTres);
        }
        public void InicializarLdtProductos()
        {

            Producto productoUno = new Producto
            {
                Codigo = 1,
                Nombre = "Jean Negro de Mujer",
                FechaCreacion = DateTime.Now,
                TipoProducto = "Ropa",
                Marca = "Zara",
                Precio = 60000,
                Stock = 2

            };
            Producto productoDos = new Producto
            {
                Codigo = 2,
                Nombre = "blusa colegial",
                FechaCreacion = DateTime.Now,
                TipoProducto = "Ropa",
                Marca = "Wibe",
                Precio = 48000,
                Stock = 1

            };
            Producto productoTres = new Producto
            {
                Codigo = 3,
                Nombre = "Chaqueta Impermedable",
                FechaCreacion = DateTime.Now,
                TipoProducto = "Ropa",
                Marca = "Shein",
                Precio = 85000,
                Stock = 1

            };
            Producto productoCuatro = new Producto
            {
                Codigo = 4,
                Nombre = "Camisa de Colombia",
                FechaCreacion = DateTime.Now,
                TipoProducto = "Ropa",
                Marca = "Zara",
                Precio = 70000,
                Stock = 3

            };

            this.LstProductos.Add(productoUno);
            this.LstProductos.Add(productoDos);
            this.LstProductos.Add(productoTres);
            this.LstProductos.Add(productoCuatro);

        }

    }
}

