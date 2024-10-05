using MySql.Data.MySqlClient;
using System.Data;

namespace Proyectos.Models.Conex
{
    public class DBTercero
    {
        string stringConex = "server=localhost; user=Backend; database=backen;password=123456789;port=3306;";
        public Tercero GetTercero(int id)
        {
            //tercero vasio
            Tercero tercero = new Tercero();
            //querinn -concatenar
            string query = "Select*from tercero where id=" + id;
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
                            tercero.Id = reader.GetInt32("Id");
                            tercero.Nombre = reader.GetString("Nombre");
                            tercero.Apellido = reader.GetString("Apellido");
                            tercero.Telefono = reader.GetString("Telefono");
                            tercero.Correo = reader.GetString("Correo");
                            tercero.Direccion = reader.GetString("Direccion");
                            tercero.FechaNacimiento = reader.GetDateTime("FechaNacimiento");
                            tercero.Genero = reader.GetChar("Genero");

                        }
                    }
                }

            }
            return tercero;
        }
        public List<Tercero> GetListaTerceros()
        {
            List<Tercero> lstTerceros = new List<Tercero>();
            string query = "Select * from tercero";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {

                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tercero tercero = new Tercero
                            {
                                Id = reader.GetInt32("Id"),
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                Telefono = reader.GetString("Telefono"),
                                Correo = reader.GetString("Correo"),
                                Direccion = reader.GetString("Direccion"),
                                FechaNacimiento = reader.GetDateTime("FechaNacimiento"),
                                Genero = reader.GetChar("Genero")
                            };
                            lstTerceros.Add(tercero);
                        }
                    }

                }
            }

            return lstTerceros;
        }
        public Boolean SetTercero(Tercero tercero)
        {
            string queryInsert = "INSERT INTO tercero (Id,Nombre,Apellido,Correo,Telefono,Direccion,FechaNacimiento,Genero) VALUES (@id,@nombre, @apellido,@correo,@telefono,@direccion,@fechanacimiento,@genero)";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@id", tercero.Id);
                    command.Parameters.AddWithValue("@nombre", tercero.Nombre);
                    command.Parameters.AddWithValue("@apellido", tercero.Apellido);
                    command.Parameters.AddWithValue("@correo", tercero.Correo);
                    command.Parameters.AddWithValue("@telefono", tercero.Telefono);
                    command.Parameters.AddWithValue("@direccion", tercero.Direccion);
                    command.Parameters.AddWithValue("@fechanacimiento", tercero.FechaNacimiento);
                    command.Parameters.AddWithValue("@genero", tercero.Genero);


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

        public Boolean UpdateTercero(Tercero tercero)
        {
            string queryInsert = "UPDATE tercero SET Nombre=@nombre,Apellido=@apellido,Correo=@correo,Telefono=@telefono,Direccion=@direccion,FechaNacimiento=@fechanacimiento,Genero=@genero WHERE Id=@id";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@id", tercero.Id);
                    command.Parameters.AddWithValue("@nombre", tercero.Nombre);
                    command.Parameters.AddWithValue("@apellido", tercero.Apellido);
                    command.Parameters.AddWithValue("@correo", tercero.Correo);
                    command.Parameters.AddWithValue("@telefono", tercero.Telefono);
                    command.Parameters.AddWithValue("@direccion", tercero.Direccion);
                    command.Parameters.AddWithValue("@fechanacimiento", tercero.FechaNacimiento);
                    command.Parameters.AddWithValue("@Genero", tercero.Genero);


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

        public Boolean DeleteTercero(int id)
        {
            string queryDelete = "DELETE FROM tercero WHERE id=" + id;
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
    }
}






