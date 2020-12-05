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
                agregar.precio = Convert.ToDouble(txtPrecio.Text);

                //Variable retorno nos indicara si se agrego correctamente a la base de datos
                int retorno = Funciones.AgregarProducto(agregar);

                if (retorno > 0)
                {
                    //Si se agrego a la base de datos nos mandara un mensaje y despues se limpiaran los campos usados
                    MessageBox.Show("Producto agregado con éxito");
                    dtgvProductos.DataSource = Funciones.mostrarProducto();
                    txtNombreProducto.Clear();
                    txtAlmacen.Clear();
                    txtPrecio.Clear();
                    txtDescripcion.Clear();
                    
                }
                else
                {
                    //Si no se agrego mandara un mensaje 
                    MessageBox.Show("No se agregó el producto, verifique los datos");
                }
            }
            else {
                MessageBox.Show("Verifique los siguientes campos:\n " + errores);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Para buscar un producto primero tenemos que llenar el campo correspondiente de la caja de texto
            if (String.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                //Si damos click y la caja de texto está vacia, mandará el siguiente mensaje
                MessageBox.Show("Ingresa un código para buscar");
            }
            else {
                //Creamos un Producto DAO que nos servirá para mostrarle al usuario lo que solicito
                ProductoDAO c = new ProductoDAO();
                c = Funciones.BuscarProducto(txtBuscar.Text);
                if (c != null)
                {
                    //En caso de que el código sea igual a 0 o que no este, significa que no existe ningun producto
                    //En caso contrario mostrara los datos correspondientes
                    if (c.codigo != 0)
                    {
                        MessageBox.Show("Código: " + c.codigo + "\n" +
                                    "Nombre: " + c.nombre + "\n" +
                                    "Descripción: " + c.descripcion + "\n" +
                                    "Precio: " + c.precio + "\n" +
                                    "Cantidad: " + c.almacen + "\n");
                        txtBuscar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe");
                        txtBuscar.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("El producto no existe");
                    txtBuscar.Clear();
                }
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            //Para editar primero tenemos que seleccionar un producto de la tabla
            if (dtgvProductos.SelectedRows.Count == 1)
            {
                //Guardamos el Codigo en la variable id para asi identificar el producto en la base de datos
                //Obtenemos los nuevos datos a modificar y se realiza el cambio.
              
                int id = Convert.ToInt32(dtgvProductos.CurrentRow.Cells[0].Value);
                String nombre = txtNombreProducto.Text;
                String descripcion = txtDescripcion.Text;
                int almacen = Convert.ToInt32(txtAlmacen.Text);
                double precio = Convert.ToDouble(txtPrecio.Text);

                //Si el producto se edita, nos mostrara un mensaje y de la misma manera en caso de que no.
                if (Funciones.EditarProducto(id, nombre, descripcion, almacen, precio) > 0)
                {
                    MessageBox.Show("Producto editado con éxito");
                    dtgvProductos.DataSource = Funciones.mostrarProducto();
                    txtNombreProducto.Clear();
                    txtDescripcion.Clear();
                    txtAlmacen.Clear();
                    txtPrecio.Clear();
                    btnAgregarProducto.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se edito el producto");
                }

            
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un producto");
            }
        }

        private void MostarDatos(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregarProducto.Enabled = false;
            txtNombreProducto.Text = Convert.ToString(dtgvProductos.CurrentRow.Cells[1].Value);
            txtDescripcion.Text = Convert.ToString(dtgvProductos.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dtgvProductos.CurrentRow.Cells[3].Value);
            txtAlmacen.Text = Convert.ToString(dtgvProductos.CurrentRow.Cells[4].Value);
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dtgvProductos.SelectedRows.Count == 1)
            {
                //Guardamos el Codigo del producto en la variable id para localizarlo en la base de datos.
                int id = Convert.ToInt32(dtgvProductos.CurrentRow.Cells[0].Value);
                //si se elimina nos mostrara un mensaje y de igual manera en caso de que no
                if (Funciones.EliminarProducto(id) > 0)
                {
                    MessageBox.Show("Producto eliminado con éxito");
                    txtNombreProducto.Clear();
                    txtDescripcion.Clear();
                    txtAlmacen.Clear();
                    txtPrecio.Clear();
                    dtgvProductos.DataSource = Funciones.mostrarProducto();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se elimino el producto");
                }

            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un producto");
            }
        }
    }
}
