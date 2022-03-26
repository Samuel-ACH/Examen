using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Usuario
    {
        public string Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public Usuario()
        {
        }

        public Usuario(string idusuario, string nombre, string clave)
        {
            Idusuario = idusuario;
            Nombre = nombre;
            Clave = clave;
        }
    }
}
