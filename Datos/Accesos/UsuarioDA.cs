using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos.Accesos
{
    public class UsuarioDA
    {
        readonly string cadena = "server = localhost; Port=3306; Database = examen; Uid = root; Pwd = 12345;";
        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string idusuario, string clave)
        {
            Usuario user = null;
            try
            {
                string sql = "SELECT * FROM usuario WHERE Idusuario = @Idusuario and Clave = @Clave;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Idusuario", idusuario);
                cmd.Parameters.AddWithValue("Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    user = new Usuario();
                    user.Idusuario = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Clave = reader[2].ToString();

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return user;
        }
    }
}
