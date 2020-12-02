using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaDeVentas.DAOS;

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
                "ALMACEN, PRECIO)values('{0}','{1}','{2}','{3}')", add.nombre, add.descripcion, add.almacen, add.precio), Conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<ProductoDAO> mostrarProducto()
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
            List<ProductoDAO> lista = new List<ProductoDAO>();
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM PRODUCTOS"), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos
            while (reader.Read())
            {
                ProductoDAO c = new ProductoDAO();
                c.codigo = reader.GetInt32(0);
                c.nombre = reader.GetString(1);
                c.descripcion = reader.GetString(2);
                c.almacen = reader.GetInt32(3);
                c.precio = reader.GetDouble(4);
                lista.Add(c);
            }
            return lista;
        }

        public static ProductoDAO BuscarProducto(string codigo)
        {
            //Comando SQL que nos ayudará a buscar el registro en la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM PRODUCTOS WHERE IDPRODUCTO='{0}'", codigo), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            ProductoDAO c = new ProductoDAO();
            //Con este ciclo crearemos un objeto para despues mostrarle los datos al usuario
            while (reader.Read())
            {

                c.codigo = reader.GetInt32(0);
                c.nombre = reader.GetString(1);
                c.descripcion = reader.GetString(2);
                c.almacen = reader.GetInt32(3);
                c.precio = reader.GetDouble(4);

            }
            return c;
        }

        public static int EditarProducto(int id, string nombre, string descripcion, int almacen, double precio)
        {
            //Comando SQL que editara los datos que le mandemos al registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE PRODUCTOS SET NOMBRE='{0}', DESCRIPCION='{1}', ALMACEN='{2}', PRECIO='{3}' WHERE IDPRODUCTO='{4}';", nombre, descripcion, almacen, precio, id), Conexion.obtenerConexion());
            //La variable editado será retornada y nos ayudará a saber si se actualizarón los datos de la base de datos
            int editado = comando.ExecuteNonQuery();
            return editado;
        }


        public static int EliminarProducto(int id)
        {
            //Comando SQL que eliminará el registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("DELETE FROM PRODUCTOS WHERE IDPRODUCTO='{0}'", id), Conexion.obtenerConexion());
            //La variable eliminado sera retornada y nos indicará si se elimino de forma correcta de la base de datos
            int eliminado = comando.ExecuteNonQuery();
            return eliminado;
        }
    }
}
