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
        String encargado;
        String id;
        public Menu(String n,String idempleado)
        {
            InitializeComponent();
             encargado = n;
             id = idempleado;
            if (!encargado.Equals("True")) {
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
            Empleados fm = new Empleados(encargado,id);
            this.Hide();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas(encargado,id);
            ven.Show();
            this.Hide();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos(encargado,id);
            prod.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes cl = new Clientes(encargado,id);
            cl.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes r = new Reportes(encargado,id);
            r.Show();
            this.Hide();
        }
    }
}
