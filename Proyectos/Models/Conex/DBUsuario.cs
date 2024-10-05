using MySql.Data.MySqlClient;

namespace Proyectos.Models.Conex
{
    public class DBUsuario
    {
        string stringConex = "server=localhost; user=Backend; database=backen;password=123456789;port=3306;";
        public Usuario GetUsuarioPorIdTercero(int idTercero)
        {
            //tercero vasio
            Usuario usuario = new Usuario();
            //querinn -concatenar
            string query = "Select*from usuario where Fk_idTercero=" + idTercero;
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
                            usuario.Id = reader.GetInt32("Id");
                            usuario.Nombre = reader.GetString("Nombre");
                            usuario.Clave = reader.GetString("Clave");

                        }
                    }
                }

            }
            return usuario;
        }
       
        public Usuario GetUsuario(int id)
        {
            //tercero vasio
            Usuario usuario = new Usuario();
            //querinn -concatenar
            string query = "Select * from usuario where id=" + id;
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
                            usuario.Id = reader.GetInt32("Id");
                            usuario.Nombre = reader.GetString("Nombre");
                            usuario.Clave = reader.GetString("Clave");

                        }
                    }
                }

            }
            return usuario;
        }

        public List<Usuario> GetListaUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            string query = "Select * from usuario";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {

                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = reader.GetInt32("Id"),
                                Nombre = reader.GetString("Nombre"),
                                Clave = reader.GetString("Clave")
                            };
                            lstUsuarios.Add(usuario);
                        }
                    }

                }
            }

            return lstUsuarios;
        }
        public Boolean SetUsuario(Usuario usuario)
        {
            string queryInsert = "INSERT INTO usuario (Id,Nombre,Clave) VALUES (@id,@nombre,@clave)";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@id", usuario.Id);
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@clave", usuario.Clave);


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


        public Boolean UpdateUsuario(Usuario usuario)
        {
            string queryUpdate = "UPDATE usuario SET Nombre=@nombre,Clave=@clave Where Id=@id";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryUpdate, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@id", usuario.Id);
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@clave", usuario.Clave);


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
        

        public Boolean DeleteUsuario(int id)
        {
            string queryDelete = "DELETE FROM usuario WHERE id=" + id;
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

