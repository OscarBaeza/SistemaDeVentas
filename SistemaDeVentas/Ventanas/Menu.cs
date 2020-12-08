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

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.Show();
            this.Hide();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos();
            prod.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes cl = new Clientes();
            cl.Show();
            this.Hide();
        }
    }
}
