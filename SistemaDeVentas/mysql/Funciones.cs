﻿using System;
using System.Collections.Generic;
using System.Data;
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
        }public static List<ProductoDAO> mostrarProductoVenta(String NOMBRE)
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
            List<ProductoDAO> lista = new List<ProductoDAO>();
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM PRODUCTOS WHERE NOMBRE = "+NOMBRE), Conexion.obtenerConexion());
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

        public static String ObtenerUsuario(String n, String a1, String a2) {
          

                //Aqui aplicamos un comando SQL que nos permitira comparar los datos ingresados por el usuario con la base de datos
                MySqlCommand cmd = new MySqlCommand("SELECT getUsuario(@nombre,@apellido1,@apellido2) ", Conexion.obtenerConexion());
                cmd.Parameters.AddWithValue("nombre", n);
                cmd.Parameters.AddWithValue("apellido1", a1);
                cmd.Parameters.AddWithValue("apellido2", a2);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //Aqui llenamos un DataTable con la informacion que nos devolvio el comando anterior

                DataTable dt = new DataTable();

                sda.Fill(dt);

                String usuario = Convert.ToString(dt.Rows[0][0].ToString());
                return usuario;
            
        }

        public static int AgregarEmpleado(EmpleadosDAO add)
        {
            //Creamos una variable llamada retorno que será la que nos indicara si se agrego a la base de datos
            int retorno = 0;
            //Utilizamos el siguiente comando SQL para agregarlo a la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO EMPLEADOS(NOMBRE, APELLIDOPATERNO, " +
                "APELLIDOMATERNO, EMAIL, PASSWORD, ENCARGADO, FECHANACIMIENTO, DIRECCION, TELEFONO)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", 
                add.Nombre, add.ApellidoPaterno, add.ApellidoMaterno, add.Usuario, "SHA1("+add.password+")", add.Encargado, add.Date, add.Direccion, add.Telefono), Conexion.obtenerConexion());
            MySqlCommand comando2 = new MySqlCommand("INSERT INTO EMPLEADOS (NOMBRE, APELLIDOPATERNO, APELLIDOMATERNO, USUARIO, PASSWORD, ENCARGADO, FECHANACIMIENTO, DIRECCION, TELEFONO) " +
                "VALUES('" + add.Nombre + "','" + add.ApellidoPaterno + "','" + add.ApellidoMaterno + "','" + add.Usuario + "',SHA1('" + add.password + "'),'" + add.Encargado + "'," +
                "'" + add.Date + "','" + add.Direccion + "','" + add.Telefono + "')", Conexion.obtenerConexion()); ;
            retorno = comando2.ExecuteNonQuery();
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
            
            while (reader.Read())
            {
                EmpleadosDAO c = new EmpleadosDAO();
                c.IdEmpleado = reader.GetInt32(0);
                c.Nombre = reader.GetString(1);
                c.ApellidoPaterno = reader.GetString(2);
                c.ApellidoMaterno = reader.GetString(3);
                c.Usuario = reader.GetString(4);
               // c.password = reader.GetString(5);
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
                c.Usuario = reader.GetString(4);
                c.password = reader.GetString(5);
                c.Encargado = reader.GetInt32(6);
                c.Date = reader.GetString(7);
                c.Direccion = reader.GetString(8);
                c.Telefono = reader.GetString(9);
            }
            return c;
        }

        public static int EditarEmpleados(int IdEmpleado, String Nombre, String ApellidoPaterno, String ApellidoMaterno, String Email, String password, int Encargado, String Date, String Direccion, String Telefono)
        {
            //Comando SQL que editara los datos que le mandemos al registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE EMPLEADOS SET NOMBRE='{0}', APELLIDOPATERNO='{1}', APELLIDOMATERNO='{2}', USUARIO='{3}',PASSWORD='{4}',ENCARGADO='{5}',DIRECCION='{6}',TELEFONO='{7}' WHERE IDEMPLEADO='{8}';", 
                Nombre, ApellidoPaterno, ApellidoMaterno, Email, password, Encargado,Direccion, Telefono, IdEmpleado), Conexion.obtenerConexion());
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
            
            while (reader.Read())
            {
                ClienteDAO c = new ClienteDAO();
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



        //VENTAS

        public static List<ProductoDAO> mostrarProductoVenta2(String NOMBRE)
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
            List<ProductoDAO> lista = new List<ProductoDAO>();
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IDPRODUCTO, NOMBRE, DESCRIPCION, PRECIO FROM PRODUCTOS WHERE NOMBRE = '{0}'", NOMBRE), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos
            ProductoDAO c = new ProductoDAO();
            while (reader.Read())
            {
                
                c.codigo = reader.GetInt32(0);
                c.nombre = reader.GetString(1);
                c.descripcion = reader.GetString(2);
              
                c.precio = reader.GetDouble(3);
                lista.Add(c);
            }
            return lista;
        }




        public static DataTable CargarCombo()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("CARGARPRODUCTO", Conexion.obtenerConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //Ventas
        public static int AgregarVenta(VentaDAO add)
        {
            //Creamos una variable llamada retorno que será la que nos indicara si se agrego a la base de datos
            int retorno = 0;
            //Utilizamos el siguiente comando SQL para agregarlo a la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO VENTAS(IDVENTAS,IDCLIENTE, IDEMPLEADO, " +
                "FECHAVENTA, TOTALVENTA)values('{0}','{1}','{2}','{3}','{4}')",add.idventa, add.idcliente, add.idempleado, add.fechaventa, add.totalventa), Conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }


        public static List<ClienteDAO> mostrarCliente2(String name)
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
            List<ClienteDAO> lista = new List<ClienteDAO>();
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM CLIENTES WHERE NOMBRE='{0}'",name), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos

            while (reader.Read())
            {
                ClienteDAO c = new ClienteDAO();
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

        //DETALLES DE VENTA
        public static int AgregarDetalle(DetallesDAO add)
        {
            //Creamos una variable llamada retorno que será la que nos indicara si se agrego a la base de datos
            int retorno = 0;
            //Utilizamos el siguiente comando SQL para agregarlo a la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO DETALLEVENTA(IDVENTAS, IDPRODUCTO, " +
                "PRECIO, CANTIDAD)values('{0}','{1}','{2}','{3}')", add.idVentas, add.idProducto, add.preio, add.cantidad), Conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }


        public static int Venta() {

            //Aqui aplicamos un comando SQL que nos permitira comparar los datos ingresados por el usuario con la base de datos
            MySqlCommand cmd = new MySqlCommand("SELECT NUMERO FROM IDE WHERE ID = @ide ", Conexion.obtenerConexion());
            cmd.Parameters.AddWithValue("ide", 1);
            
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            //Aqui llenamos un DataTable con la informacion que nos devolvio el comando anterior

            DataTable dt = new DataTable();

            sda.Fill(dt);

            int idempleado = Convert.ToInt32( dt.Rows[0][0].ToString());
            return idempleado;
        }

        public static int Editaride(int Idventa)
        {
            //Comando SQL que editara los datos que le mandemos al registro de la base de datos
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE IDE SET NUMERO='{0}' WHERE ID=1;",Idventa), Conexion.obtenerConexion());
            //La variable editado será retornada y nos ayudará a saber si se actualizarón los datos de la base de datos
            int editado = comando.ExecuteNonQuery();
            return editado;
        }

        //Reportes


        public static DataTable GenerarReporte(int anio, int mes)
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 
           
            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("CALL REPORTE1({0},{1})",anio,mes), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos
            DataTable dt = new DataTable();
            dt.Columns.Add("IDEMPLEADO");
            dt.Columns.Add("NOMBRE");
            dt.Columns.Add("USUARIO");
            dt.Columns.Add("VENTAS");
            dt.Columns.Add("MONTO");

            while (reader.Read())
            {
                dt.Rows.Add(reader.GetString(0),reader.GetString(1),reader.GetString(2), reader.GetString(3), reader.GetString(4));
            }

            
            return dt;
        }

        public static DataTable GenerarReporte2(String fecha1, String fecha2)
        {
            //Esté metodo nos regresa una lista con los datos que mostraremos 

            //Esté será el comando que utilizaremos para obtener los datos
            MySqlCommand comando = new MySqlCommand(String.Format("CALL REPORTE2('{0}','{1}')", fecha1, fecha2), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            //Con esté ciclo estaremos creando objetos para despues agregarlos a la lista y mostrarlos
            DataTable dt = new DataTable();
            dt.Columns.Add("IDVENTAS");
            dt.Columns.Add("FECHA");
            dt.Columns.Add("TOTAL");
            dt.Columns.Add("EMPLEADO");
           

            while (reader.Read())
            {
                dt.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }


            return dt;
        }

        public static int Transaccion(int cantidad,int id) {

            
          


            

            MySqlCommand comando2 = new MySqlCommand(String.Format("UPDATE PRODUCTOS SET ALMACEN = ALMACEN - {0} WHERE IDPRODUCTO = {1}",cantidad,id), Conexion.obtenerConexion());

            int n  = comando2.ExecuteNonQuery();

            return n;
        }

        public static int StartTransaccion()
        {
            String tran = "START TRANSACTION";

            MySqlCommand comando2 = new MySqlCommand(String.Format(tran), Conexion.obtenerConexion());

            int n = comando2.ExecuteNonQuery();

            return n;
        }

        public static int CommitTransaccion()
        {
            String tran = "COMMIT";

            MySqlCommand comando2 = new MySqlCommand(String.Format(tran), Conexion.obtenerConexion());

            int n = comando2.ExecuteNonQuery();

            return n;
        }

        public static int RollBackTransaccion()
        {
            String tran = "ROLLBACK";

            MySqlCommand comando2 = new MySqlCommand(String.Format(tran), Conexion.obtenerConexion());

            int n = comando2.ExecuteNonQuery();

            return n;
        }




    }
}
