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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
            dtgvEmpleados.DataSource = Funciones.mostrarEmpleado();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Creamos un Objeto de tipo ProductoDAO y lo llenamos con los datos
            //de las cajas de texto para asi poderlo agregarlo a la base de datos
            EmpleadosDAO agregar = new EmpleadosDAO();
            int cont = 0;
            String errores = "";
            String pattern = "^[0-9][0-9]{0,2}$";
            String pattern2 = "[0-9]{2}[\\.]?[0-9]{2}";
            if (txtNombre.Text.Length == 0)
            {
                errores += "-Agregue un nombre del empleado\n";
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
            if (txtEmail.Text.Length == 0)
            {
                errores += "-Agregue un Email\n";

            }
            else
            {
                cont++;
            }
            if (txtPassword.Text.Length == 0)
            {
                errores += "-Agregue un Passsword\n";
            }
            else
            {
                cont++;
            }
            if (txtEncargado.Text.Length == 0)
            {
                errores += "-Agregue un encargado\n";
            }
            else
            {
                cont++;
            }
            if (txtFecha.Text.Length == 0)
            {
                errores += "-Agregue una fecha de nacimiento\n";
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
            if (txtTelefono.Text.Length == 0)
            {
                errores += "-Agregue un telefono\n";
            }
            else
            {
                cont++;
            }


            if (cont == 9)
            {
                agregar.Nombre = txtNombre.Text;
                agregar.ApellidoPaterno = txtApellidoP.Text;
                agregar.ApellidoMaterno = txtApellidoM.Text;
                agregar.Email = txtEmail.Text;
                agregar.password = txtPassword.Text;
                agregar.Encargado = Convert.ToInt32(txtEncargado.Text);
                agregar.Date = txtFecha.Text;
                agregar.Direccion = txtDireccion.Text;
                agregar.Telefono = txtTelefono.Text;

                //Variable retorno nos indicara si se agrego correctamente a la base de datos
                int retorno = Funciones.AgregarEmpleado(agregar);

                if (retorno > 0)
                {
                    //Si se agrego a la base de datos nos mandara un mensaje y despues se limpiaran los campos usados
                    MessageBox.Show("Empleado agregado con éxito");
                    dtgvEmpleados.DataSource = Funciones.mostrarEmpleado();
                    txtNombre.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtEncargado.Clear();
                    txtFecha.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();

                }
                else
                {
                    //Si no se agrego mandara un mensaje 
                    MessageBox.Show("No se agregó el empleado, verifique los datos");
                }
            }
            else
            {
                MessageBox.Show("Verifique los siguientes campos:\n " + errores);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Para editar primero tenemos que seleccionar un empleado de la tabla
            if (dtgvEmpleados.SelectedRows.Count == 1)
            {
                //Guardamos el Codigo en la variable id para asi identificar el producto en la base de datos
                //Obtenemos los nuevos datos a modificar y se realiza el cambio.

                int id = Convert.ToInt32(dtgvEmpleados.CurrentRow.Cells[0].Value);
                String nombre = txtNombre.Text;
                String apellidoPaterno = txtApellidoP.Text;
                String apellidoMaterno = txtApellidoM.Text;
                String Email = txtEmail.Text;
                String Password = txtPassword.Text;
                int Encargado = Convert.ToInt32(txtEncargado.Text);
                String Fecha = txtFecha.Text;
                String direccion = txtDireccion.Text;
                String telefono = txtTelefono.Text;


                //Si el empleado se edita, nos mostrara un mensaje y de la misma manera en caso de que no.
                if (Funciones.EditarEmpleados(id, nombre, apellidoPaterno, apellidoMaterno, Email, Password, Encargado, Fecha, direccion, telefono) > 0)
                {
                    MessageBox.Show("Empleado editado con éxito");
                    dtgvEmpleados.DataSource = Funciones.mostrarEmpleado();
                    txtNombre.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtEncargado.Clear();
                    txtFecha.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    btnAgregar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se edito el empleado");
                }


            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un empleado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvEmpleados.SelectedRows.Count == 1)
            {
                //Guardamos el Codigo del empleado en la variable id para localizarlo en la base de datos.
                int id = Convert.ToInt32(dtgvEmpleados.CurrentRow.Cells[0].Value);
                //si se elimina nos mostrara un mensaje y de igual manera en caso de que no
                if (Funciones.EliminarEmpleados(id) > 0)
                {
                    MessageBox.Show("Empleado eliminado con éxito");
                    txtNombre.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtEncargado.Clear();
                    txtFecha.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    dtgvEmpleados.DataSource = Funciones.mostrarEmpleado();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se elimino el empleado");
                }

            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un empleado");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Para buscar un producto primero tenemos que llenar el campo correspondiente de la caja de texto
            if (String.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                //Si damos click y la caja de texto está vacia, mandará el siguiente mensaje
                MessageBox.Show("Ingresa un código para buscar");
            }
            else
            {
                //Creamos un Producto DAO que nos servirá para mostrarle al usuario lo que solicito
                EmpleadosDAO c = new EmpleadosDAO();
                c = Funciones.BuscarEmpleado(txtBuscar.Text);
                if (c != null)
                {
                    //En caso de que el código sea igual a 0 o que no este, significa que no existe ningun producto
                    //En caso contrario mostrara los datos correspondientes
                    if (c.IdEmpleado != 0)
                    {
                        MessageBox.Show("Código: " + c.IdEmpleado + "\n" +
                                    "Nombre: " + c.Nombre + "\n" +
                                    "Apellido Paterno: " + c.ApellidoPaterno + "\n" +
                                    "Apellido Materno: " + c.ApellidoMaterno + "\n" +
                                    "Email: " + c.Email + "\n" +
                                    "Password: " + "**********" + "\n" +
                                    "Encagado: " + c.Encargado + "\n" +
                                    "Fecha de nacimiento: " + c.Date + "\n" +
                                    "Domicilo: " + c.Direccion + "\n" +
                                    "Telefono: " + c.Telefono + "\n");
                        txtBuscar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El empleado no existe");
                        txtBuscar.Clear();
                    }

                }
                else
                {
                    //Cambioss
                    MessageBox.Show("El empleado no existe");
                    txtBuscar.Clear();
                }
            }
        }

        private void MostrarDatos(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregar.Enabled = false;
            txtNombre.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[1].Value);
            txtApellidoP.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[2].Value);
            txtApellidoM.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[3].Value);
            txtEmail.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[4].Value);
            txtPassword.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[5].Value);
            txtEncargado.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[6].Value);
            txtFecha.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[7].Value);
            txtDireccion.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[8].Value);
            txtTelefono.Text = Convert.ToString(dtgvEmpleados.CurrentRow.Cells[9].Value);
        }
    }
}
