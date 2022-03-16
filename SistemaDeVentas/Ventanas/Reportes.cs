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
    public partial class Reportes : Form
    {
        String ene;
        String id;
        public Reportes(String n, String idempleado)
        {
            ene = n;
            id = idempleado;
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu(ene,id);
            m.Show();
            this.Hide();

        }

        private void btnReporte1_Click(object sender, EventArgs e)
        {
            ReporteVentas r = new ReporteVentas(ene,id);
            r.Show();
            this.Hide();


        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            ReporteVentas2 r = new ReporteVentas2(ene,id);
            r.Show();
            this.Hide();
        }
    }
}
