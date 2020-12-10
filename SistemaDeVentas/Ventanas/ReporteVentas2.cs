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
    public partial class ReporteVentas2 : Form
    {
        String ene;
        String id;
        public ReporteVentas2(String n, String idempleado)
        {
            ene = n;
            id = id = idempleado;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgvReporte.DataSource = Funciones.GenerarReporte2(txtFechaInicio.Text,txtFechaFin.Text);
        }

        private void ReporteVentas2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reportes r = new Reportes(ene,id);
            r.Show();
            this.Hide();
        }
    }
}
