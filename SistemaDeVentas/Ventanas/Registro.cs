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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (cmbOp.SelectedItem.ToString().Equals("Cliente"))
            {
                Clientes cl = new Clientes();
                cl.Show();
                this.Hide();
            }
            else {
                Empleados em = new Empleados();
                em.Show();
                this.Hide();
            }
                         
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
