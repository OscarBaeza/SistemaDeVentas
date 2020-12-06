using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaDeVentas
{
    class Loginclass
    {
        
       
            MySqlConnection Conexion = new MySqlConnection("server=localhost; Uid=root; password=root123; Database=Molina; Port=3306");
            // ----------------------------------------------------------------------------------------------------------------------------------
            public String[] logear(TextBox txtUsername)
            {
                String vista = "SELECT NOMBRE from EMPLEADOS WHERE " + "NOMBRE='" + txtUsername.Text + "'";
                String[] user = new string[2];
                Conexion.Open();
                try
                {
                    MySqlCommand Comando = new MySqlCommand(vista, Conexion);
                    Comando.ExecuteNonQuery();
                    MySqlDataReader leer = Comando.ExecuteReader();
                    leer.Read();
                    user[0] = leer.GetString(0);
                    user[1] = leer.GetString(1);
                    Conexion.Close();
                    return user;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("El usuario no se encontro" + e.Message);
                    Conexion.Close();
                    return null;
                }
            }


            // -------------------------------------------------------------------------------------------------------------------------------------

            
        }
}
