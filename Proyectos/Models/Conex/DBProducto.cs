using MySql.Data.MySqlClient;

namespace Proyectos.Models.Conex
{
    public class DBProducto
    {
        string stringConex = "server=localhost; user=Backend; database=backen;password=123456789;port=3306;";
        public Producto GetProducto(int codigo)
        {
            //Producto vasio
            Producto producto = new Producto();
            //querinn -concatenar
            string query = "Select*from producto where codigo=" + codigo;
            //connecion mysql-using=abre la coneciion 
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producto.Codigo = reader.GetInt32("Codigo");
                            producto.Nombre = reader.GetString("Nombre");
                            producto.FechaCreacion = reader.GetDateTime("FechaCreacion");
                            producto.TipoProducto = reader.GetString("TipoProducto");
                            producto.Marca = reader.GetString("Marca");
                            producto.Precio = reader.GetFloat("Precio");
                            producto.Stock = reader.GetInt32("Stock");

                        }
                    }
                }

            }
            return producto;
        }

        public Boolean SetProducto(Producto producto)
        {
            string queryInsert = "INSERT INTO producto (Codigo,Nombre,FechaCreacion,TipoProducto,Marca,Precio,Stock) VALUES (@codigo, @nombre,@fechacreacion,@tipoproducto,@marca,@precio,@stock)";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("codigo", producto.Codigo);
                    command.Parameters.AddWithValue("@nombre",producto.Nombre);
                    command.Parameters.AddWithValue("@fechacreacion", producto.FechaCreacion);
                    command.Parameters.AddWithValue("@tipoproducto", producto.TipoProducto);
                    command.Parameters.AddWithValue("@marca", producto.Marca);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.Parameters.AddWithValue("@stock", producto.Stock);



                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean UpdateProducto(Producto producto)
        {
            string queryInsert = "UPDATE producto SET Nombre=@nombre,FechaCreacion=@fechaCreacion,TipoProducto=@tipoproducto,Marca=@marca,Precio=@precio,Stock=@stock WHERE Codigo=@codigo";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("codigo", producto.Codigo);
                    command.Parameters.AddWithValue("@nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@fechacreacion", producto.FechaCreacion);
                    command.Parameters.AddWithValue("@tipoproducto", producto.TipoProducto);
                    command.Parameters.AddWithValue("@marca", producto.Marca);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.Parameters.AddWithValue("@stock", producto.Stock);



                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean DeleteProducto(int codigo)
        {
            string queryDelete = "DELETE FROM producto WHERE codigo=" + codigo;
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex)) 
            {
                using (MySqlCommand command = new MySqlCommand(queryDelete, mySqlConnection))
                {
                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
      
        public List<Producto> GetUsuarioPorProductoCodigo(int codigo)
        {
            //Producto vasio
            List<Producto> lstproducto = new List<Producto>();
            Producto producto = new Producto();

            //querinn -concatenar
            string query = "Select* from producto where Fk_idUsuario = " + codigo;
            //connecion mysql-using=abre la coneciion 
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producto.Codigo = reader.GetInt32("Codigo");
                            producto.Nombre = reader.GetString("Nombre");
                            producto.FechaCreacion = reader.GetDateTime("FechaCreacion");
                            producto.TipoProducto = reader.GetString("TipoProducto");
                            producto.Marca = reader.GetString("Marca");
                            producto.Precio = reader.GetFloat("Precio");
                            producto.Stock = reader.GetInt32("Stock");

                        };
                        lstproducto.Add(producto);
                    }
                }

            }
            return lstproducto;
        }

    }
}

