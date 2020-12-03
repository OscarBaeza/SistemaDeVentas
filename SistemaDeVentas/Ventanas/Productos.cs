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
using System.Text.RegularExpressions;


namespace SistemaDeVentas.Ventanas
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            dtgvProductos.DataSource = Funciones.mostrarProducto();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            //Creamos un Objeto de tipo ProductoDAO y lo llenamos con los datos
            //de las cajas de texto para asi poderlo agregarlo a la base de datos
            ProductoDAO agregar = new ProductoDAO();
            int cont = 0;
            String errores = "";
            String pattern = "^[0-9][0-9]{0,2}$";
            String pattern2 = "[0-9]{2}[\\.]?[0-9]{2}";
            if (txtNombreProducto.Text.Length == 0)
            {
                errores += "-Agregue un nombre del producto\n";
            }
            else {
                cont++;
            }

            if (txtAlmacen.Text.Length == 0)
            {
                errores += "-Agregue una cantidad de productos\n";
            }
            else if (!Regex.IsMatch(txtAlmacen.Text, pattern))
            {
                errores += "-Agregue una cantidad valida\n";
            }
            else {
                cont++;
            }

            if (txtPrecio.Text.Length == 0)
            {
                errores += "-Agregue un precio de productos\n";
            }
            else if (!Regex.IsMatch(txtPrecio.Text, pattern2) && !Regex.IsMatch(txtPrecio.Text, pattern))
            {
                errores += "-Agregue un precio valido\n";
                
            }
            else
            {
                cont++;
            }



            if (cont == 3)
            {
                agregar.nombre = txtNombreProducto.Text;
                if (txtDescripcion.Text.Length == 0)
                {
                    agregar.descripcion = "Sin descripción";
                }
                else
                {
                    agregar.descripcion = txtDescripcion.Text;
                }
                agregar.almacen = Convert.ToInt32(txtAlmacen.Text);
            }
            else {
                MessageBox.Show("Verifique los siguientes campos:\n " + errores);
            }


        }
    }
}
