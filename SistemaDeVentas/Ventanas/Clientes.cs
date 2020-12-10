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
    public partial class Clientes : Form
    {
        String ene;
        String id;
        public Clientes(String n, String idempleado)
        {
            ene = n;
            id = idempleado;
            InitializeComponent();
            dtgvClientes.DataSource = Funciones.mostrarCliente();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            //Creamos un Objeto de tipo ClienteDAO y lo llenamos con los datos
            //de las cajas de texto para asi poderlo agregarlo a la base de datos
            ClienteDAO agregar = new ClienteDAO();
            int cont = 0;
            String errores = "";
            String pattern = "^[0-9][0-9]{0,2}$";
            String pattern2 = "[0-9]{2}[\\.]?[0-9]{2}";
            if (txtNombreCliente.Text.Length == 0)
            {
                errores += "-Agregue un nombre del cliente\n";
            }
            else
            {
                cont++;
            }

            if (txtApellidoP.Text.Length == 0)
            {
                errores += "-Agregue un apellido paterno\n";
            }
            else
            {
                cont++;
            }
            if (txtApellidoM.Text.Length == 0)
            {
                errores += "-Agregue un apellido materno\n";
            }
            else
            {
                cont++;
            }
            if (txtDireccion.Text.Length == 0)
            {
                errores += "-Agregue una direccion\n";
            }
            else
            {
                cont++;
            }
            if (txtEmail.Text.Length == 0)
            {
                errores += "-Agregue un Usuario\n";

            }
            else
            {
                cont++;
            }
            if (txtTelefono.Text.Length == 0)
            {
                errores += "-Agregue un telefono\n";
            }
            else
            {
                cont++;
            }


            if (cont == 6)
            {
                agregar.Nombre = txtNombreCliente.Text;
                agregar.ApellidoPaterno = txtApellidoP.Text;
                agregar.ApellidoMaterno = txtApellidoM.Text;
                agregar.Direccion = txtDireccion.Text;
                agregar.Email = txtEmail.Text;
                agregar.Telefono = txtTelefono.Text;

                //Variable retorno nos indicara si se agrego correctamente a la base de datos
                int retorno = Funciones.AgregarCliente(agregar);

                if (retorno > 0)
                {
                    //Si se agrego a la base de datos nos mandara un mensaje y despues se limpiaran los campos usados
                    MessageBox.Show("Cliente agregado con éxito");
                    dtgvClientes.DataSource = Funciones.mostrarCliente();
                    txtNombreCliente.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtEmail.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();

                }
                else
                {
                    //Si no se agrego mandara un mensaje 
                    MessageBox.Show("No se agregó el cliente, verifique los datos");
                }
            }
            else
            {
                MessageBox.Show("Verifique los siguientes campos:\n " + errores);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Para buscar un cliente primero tenemos que llenar el campo correspondiente de la caja de texto
            if (String.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                //Si damos click y la caja de texto está vacia, mandará el siguiente mensaje
                MessageBox.Show("Ingresa un código para buscar");
            }
            else
            {
                //Creamos un Cliente DAO que nos servirá para mostrarle al usuario lo que solicito
                ClienteDAO c = new ClienteDAO();
                c = Funciones.BuscarCliente(txtBuscar.Text);
                if (c != null)
                {
                    //En caso de que el código sea igual a 0 o que no este, significa que no existe ningun producto
                    //En caso contrario mostrara los datos correspondientes
                    if (c.IdCliente != 0)
                    {
                        MessageBox.Show("Código: " + c.IdCliente + "\n" +
                                    "Nombre: " + c.Nombre + "\n" +
                                    "Apellido Paterno: " + c.ApellidoPaterno + "\n" +
                                    "Apellido Materno: " + c.ApellidoMaterno + "\n" +
                                    "Domicilo: " + c.Direccion + "\n" +
                                    "Usuario: " + c.Email + "\n" +
                                    "Telefono: " + c.Telefono + "\n");
                        txtBuscar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe");
                        txtBuscar.Clear();
                    }

                }
                else
                {
                    //Cambioss
                    MessageBox.Show("El cliente no existe");
                    txtBuscar.Clear();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Para editar primero tenemos que seleccionar un empleado de la tabla
            if (dtgvClientes.SelectedRows.Count == 1)
            {
                //Guardamos el Codigo en la variable id para asi identificar el producto en la base de datos
                //Obtenemos los nuevos datos a modificar y se realiza el cambio.

                int id = Convert.ToInt32(dtgvClientes.CurrentRow.Cells[0].Value);
                String nombre = txtNombreCliente.Text;
                String apellidoPaterno = txtApellidoP.Text;
                String apellidoMaterno = txtApellidoM.Text;
                String direccion = txtDireccion.Text;
                String Email = txtEmail.Text;
                String telefono = txtTelefono.Text;


                //Si el Cliente se edita, nos mostrara un mensaje y de la misma manera en caso de que no.
                if (Funciones.EditarClientes(id, nombre, apellidoPaterno, apellidoMaterno, Email,  direccion, telefono) > 0)
                {
                    MessageBox.Show("Cliente editado con éxito");
                    dtgvClientes.DataSource = Funciones.mostrarCliente();
                    txtNombreCliente.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtEmail.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    btnAgregarCliente.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se edito el cliente");
                }


            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un cliente");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvClientes.SelectedRows.Count == 1)
            {
                //Guardamos el Codigo del cliente en la variable id para localizarlo en la base de datos.
                int id = Convert.ToInt32(dtgvClientes.CurrentRow.Cells[0].Value);
                //si se elimina nos mostrara un mensaje y de igual manera en caso de que no
                if (Funciones.EliminarClientes(id) > 0)
                {
                    MessageBox.Show("Cliente eliminado con éxito");
                    txtNombreCliente.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtEmail.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    dtgvClientes.DataSource = Funciones.mostrarCliente();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se elimino el cliente");
                }

            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un cliente");
            }
        }

        private void MostrarDatos(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregarCliente.Enabled = false;
            txtNombreCliente.Text = Convert.ToString(dtgvClientes.CurrentRow.Cells[1].Value);
            txtApellidoP.Text = Convert.ToString(dtgvClientes.CurrentRow.Cells[2].Value);
            txtApellidoM.Text = Convert.ToString(dtgvClientes.CurrentRow.Cells[3].Value);
            txtDireccion.Text = Convert.ToString(dtgvClientes.CurrentRow.Cells[4].Value);
            txtEmail.Text = Convert.ToString(dtgvClientes.CurrentRow.Cells[5].Value);
            txtTelefono.Text = Convert.ToString(dtgvClientes.CurrentRow.Cells[6].Value);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu log = new Menu(ene,id);
            log.Show();
            this.Hide();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }
    }
}
