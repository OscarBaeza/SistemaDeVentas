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


        //Funciones de empleados

        public static int AgregarEmpleado(EmpleadosDAO add)
        {
            //Creamos una variable llamada retorno que será la que nos indicara si se agrego a la base de datos
            int retorno = 0;
            //Utilizamos el siguiente comando SQL para agregarlo a la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO EMPLEADOS(NOMBRE, APELLIDOPATERNO, " +
                "APELLIDOMATERNO, EMAIL, PASSWORD, ENCARGADO, FECHANACIMIENTO, DIRECCION, TELEFONO)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", 
                add.Nombre, add.ApellidoPaterno, add.ApellidoMaterno, add.Email, add.password, add.Encargado, add.Date, add.Direccion, add.Telefono), Conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<EmpleadosDAO> mostrarEmpleado()
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
            List<EmpleadosDAO> lista = new List<EmpleadosDAO>();
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM EMPLEADOS"), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos
            EmpleadosDAO c = new EmpleadosDAO();
            while (reader.Read())
            {

                c.IdEmpleado = reader.GetInt32(0);
                c.Nombre = reader.GetString(1);
                c.ApellidoPaterno = reader.GetString(2);
                c.ApellidoMaterno = reader.GetString(3);
                c.Email = reader.GetString(4);
                c.password = reader.GetString(5);
                c.Encargado = reader.GetInt32(6);
                c.Date = reader.GetString(7);
                c.Direccion = reader.GetString(8);
                c.Telefono = reader.GetString(9);
                lista.Add(c);
            }
            return lista;
        }

        public static EmpleadosDAO BuscarEmpleado(string codigo)
        {
            //Comando SQL que nos ayudará a buscar el registro en la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM EMPLEADOS WHERE IDEMPLEADO='{0}'", codigo), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            EmpleadosDAO c = new EmpleadosDAO();
            //Con este ciclo crearemos un objeto para despues mostrarle los datos al usuario
            while (reader.Read())
            {
                c.IdEmpleado = reader.GetInt32(0);
                c.Nombre = reader.GetString(1);
                c.ApellidoPaterno = reader.GetString(2);
                c.ApellidoMaterno = reader.GetString(3);
                c.password = reader.GetString(4);
                c.Encargado = reader.GetInt32(5);
                c.Date = reader.GetString(6);
                c.Direccion = reader.GetString(7);
                c.Telefono = reader.GetString(8);
            }
            return c;
        }

        public static int EditarEmpleados(int IdEmpleado, String Nombre, String ApellidoPaterno, String ApellidoMaterno, String Email, String password, int Encargado, String Date, String Direccion, String Telefono)
        {
            //Comando SQL que editara los datos que le mandemos al registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE EMPLEADOS SET NOMBRE='{0}', APELLIDOPATERNO='{1}', APELLIDOMATERNO='{2}', EMAIL='{3}',PASSWORD='{4}',ENCARGADO='{5}',FECHANACIMIENTO='{6}',DIRECCION='{7}',TELEFONO='{8}' WHERE IDEMPLEADO='{9}';", 
                Nombre, ApellidoPaterno, ApellidoMaterno, Email, password, Encargado, Date, Direccion, Telefono, IdEmpleado), Conexion.obtenerConexion());
            //La variable editado será retornada y nos ayudará a saber si se actualizarón los datos de la base de datos
            int editado = comando.ExecuteNonQuery();
            return editado;
        }
        public static int EliminarEmpleados(int id)
        {
            //Comando SQL que eliminará el registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("DELETE FROM EMPLEADOS WHERE IDEMPLEADO='{0}'", id), Conexion.obtenerConexion());
            //La variable eliminado sera retornada y nos indicará si se elimino de forma correcta de la base de datos
            int eliminado = comando.ExecuteNonQuery();
            return eliminado;
        }


        //Funciones clientes

        public static int AgregarCliente(ClienteDAO add)
        {
            //Creamos una variable llamada retorno que será la que nos indicara si se agrego a la base de datos
            int retorno = 0;
            //Utilizamos el siguiente comando SQL para agregarlo a la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO CLIENTES(NOMBRE, APELLIDOPATERNO, " +
                "APELLIDOMATERNO, DIRECCION, EMAIL, TELEFONO)values('{0}','{1}','{2}','{3}','{4}','{5}')", add.Nombre, add.ApellidoPaterno, add.ApellidoMaterno, add.Direccion, add.Email, add.Telefono), Conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<ClienteDAO> mostrarCliente()
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
            List<ClienteDAO> lista = new List<ClienteDAO>();
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM CLIENTES"), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos
            ClienteDAO c = new ClienteDAO();
            while (reader.Read())
            {

                c.IdCliente = reader.GetInt32(0);
                c.Nombre = reader.GetString(1);
                c.ApellidoPaterno = reader.GetString(2);
                c.ApellidoMaterno = reader.GetString(3);
                c.Direccion = reader.GetString(4);
                c.Email = reader.GetString(5);
                c.Telefono = reader.GetString(6);     
               
                lista.Add(c);
            }
            return lista;
        }

        public static ClienteDAO BuscarCliente(string codigo)
        {
            //Comando SQL que nos ayudará a buscar el registro en la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM CLIENTES WHERE IDCLIENTE='{0}'", codigo), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            ClienteDAO c = new ClienteDAO();
            //Con este ciclo crearemos un objeto para despues mostrarle los datos al usuario
            while (reader.Read())
            {
                c.IdCliente = reader.GetInt32(0);
                c.Nombre = reader.GetString(1);
                c.ApellidoPaterno = reader.GetString(2);
                c.ApellidoMaterno = reader.GetString(3);
                c.Direccion = reader.GetString(4);
                c.Email = reader.GetString(5);
                c.Telefono = reader.GetString(6);
            }
            return c;
        }

        public static int EditarClientes(int IdCliente, String Nombre, String ApellidoPaterno, String ApellidoMaterno, String Direccion, String Email, String Telefono)
        {
            //Comando SQL que editara los datos que le mandemos al registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE CLIENTES SET NOMBRE='{0}', APELLIDOPATERNO='{1}', APELLIDOMATERNO='{2}', DIRECCION='{3}',EMAIL='{4}',TELEFONO='{5}' WHERE IDCLIENTE='{6}';", 
                Nombre, ApellidoPaterno, ApellidoMaterno, Direccion, Email, Telefono, IdCliente), Conexion.obtenerConexion());
            //La variable editado será retornada y nos ayudará a saber si se actualizarón los datos de la base de datos
            int editado = comando.ExecuteNonQuery();
            return editado;
        }
        public static int EliminarClientes(int id)
        {
            //Comando SQL que eliminará el registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("DELETE FROM CLIENTES WHERE IDCLIENTE='{0}'", id), Conexion.obtenerConexion());
            //La variable eliminado sera retornada y nos indicará si se elimino de forma correcta de la base de datos
            int eliminado = comando.ExecuteNonQuery();
            return eliminado;
        }


    }
}
