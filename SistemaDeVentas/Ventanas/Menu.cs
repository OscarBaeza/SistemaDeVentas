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
    public partial class Menu : Form
    {
        public Menu(String n)
        {
            InitializeComponent();
            String encargado = n;
            if (!n.Equals("True")) {
                btnClientes.Enabled = false;
                btnEmpleados.Enabled = false;
                btnProductos.Enabled = false;
                btnReportes.Enabled = false;
            }
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Empleados fm = new Empleados();
            this.Hide();
            fm.Show();
        }
    }
}
