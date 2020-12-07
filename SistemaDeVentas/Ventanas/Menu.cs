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
            lbEncargado.Text = n;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
