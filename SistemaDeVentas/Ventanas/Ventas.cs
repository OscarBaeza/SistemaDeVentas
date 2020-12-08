using SistemaDeVentas.DAOS;
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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            
            List<ProductoDAO> lista = new List<ProductoDAO>();
            lista = Funciones.mostrarProducto();

            List<String> listaProductos = new List<String>();
            listaProductos.Add("Selecciona el producto");
            for (int i=0;i<lista.Count;i++) {
                listaProductos.Add(lista[i].nombre);
            }

            comboProductos.DataSource = listaProductos;

           
        }
        List<ProductoDAO> listaVentas = new List<ProductoDAO>();

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Funciones.mostrarProductoS(comboProductos.SelectedItem.ToString());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
