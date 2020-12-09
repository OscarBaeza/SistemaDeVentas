using MySql.Data.MySqlClient;
using SistemaDeVentas.mysql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeVentas.Ventanas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Creamos un metodo llamado logear, que será el encargado en validar los datos.
        public void logear(string usuario, string contrasena)
        {

            try
            {

                //Aqui aplicamos un comando SQL que nos permitira comparar los datos ingresados por el usuario con la base de datos
                MySqlCommand cmd = new MySqlCommand("SELECT IDEMPLEADO, NOMBRE, ENCARGADO FROM EMPLEADOS WHERE EMAIL = @usuario AND PASSWORD = @pas", Conexion.obtenerConexion());
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pas", contrasena);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //Aqui llenamos un DataTable con la informacion que nos devolvio el comando anterior

                DataTable dt = new DataTable();
                
                sda.Fill(dt);

                
                String idempleado = dt.Rows[0][0].ToString();

                String encargado = dt.Rows[0][2].ToString();

                //En caso de que la DataTable no esté vacia, significará que tuvimos coincidencia en ambos datos de usuario y contrasena
                if (dt.Rows.Count == 1)
                {
                    //Mandamos un mensaje de bienvenida concatenado al nombre de usuario que ingreso
                    MessageBox.Show("Bienvenido " + usuario);
                    
                    Menu fm = new Menu(encargado,idempleado);
                    fm.Show();
                    Login log = new Login();
                    log.Close();
                    
                }
                else
                {
                    //Mandamos un mensaje sobre el error.
                    MessageBox.Show("Usuario y/o contraseña incorrecta");
                }
            }
            catch (Exception e)
            {
                //Atrapamos cualquier error a la hora de la conexion con la base de datos.
                MessageBox.Show(e.Message);
            }


        }



        private void btnregistro_Click(object sender, EventArgs e)
        {
            Registro res = new Registro();
            res.Show();
            this.Hide();
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            logear(txtusername.Text, txtpassword.Text);
            Login LOG = new Login();
            LOG.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
