using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaDeVentas.mysql
{
    class Funciones
    {
        //En esta parte están las funciones requeridas para los productos
        public static int AgregarProducto(ProductoDAO add)
        {
            //Creamos una variable llamada retorno que será la que nos indicara si se agrego a la base de datos
            int retorno = 0;
            //Utilizamos el siguiente comando SQL para agregarlo a la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO PRODUCTOS(NOMBRE, DESCRIPCION, " +
                "ALMACEN, PRECIO)values('{0}','{1}','{2}','{3}')", add.nombre, add.descripcion, add.precio, add.cantidad), Conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
