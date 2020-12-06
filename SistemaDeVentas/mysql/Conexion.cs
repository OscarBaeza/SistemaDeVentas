using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaDeVentas.mysql
{
    class Conexion
    {
        //Esta clase será la que nos ayudara a conectarnos con la base de datos, cada vez que lo ocupemos solo
        //debemos mandar llamarla con su metodo obtenerConexion.
        public static MySqlConnection obtenerConexion()
        {
            //Comando SQL que sera la conexion a la base de datos.
            MySqlConnection conexion = new MySqlConnection("server=localhost;database=sistemaventas;Uid=root;pwd=root;");
            conexion.Open();
            //Retorno de la conexion
            return conexion;
        }
    }
}
