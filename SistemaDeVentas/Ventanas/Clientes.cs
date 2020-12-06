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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            dtgvClientes.DataSource = Funciones.mostrarCliente();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
