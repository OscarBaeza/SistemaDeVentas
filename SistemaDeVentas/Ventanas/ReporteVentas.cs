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
    public partial class ReporteVentas : Form
    {
        String ene;
        String id;
        public ReporteVentas(String n, String idempleado)
        {
            ene = n;
            id = idempleado;
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dtgvReporte1.DataSource = Funciones.GenerarReporte(Convert.ToInt32(txtAnio.Text),Convert.ToInt32(txtMes.Text));
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reportes r = new Reportes(ene,id);
            r.Show();
            this.Hide();
        }
    }
}
