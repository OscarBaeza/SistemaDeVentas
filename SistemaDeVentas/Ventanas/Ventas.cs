using MySql.Data.MySqlClient;
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
        String idem;
        String ene;
        public Ventas(String n, String idempleado)
        {
            ene = n;
            InitializeComponent();
            btnConfirmar.Enabled = false;
            idem = idempleado;
           // EnumerableExecutor = n;
            textBox1.Text = "0";
            lblTotal.Text = "0";
            List<ProductoDAO> lista = new List<ProductoDAO>();
            lista = Funciones.mostrarProducto();

            List<String> listaProductos = new List<String>();
            //listaProductos.Add("Selecciona el producto");
            for (int i=0;i<lista.Count;i++) {
                listaProductos.Add(lista[i].nombre);
            }
            List<ClienteDAO> list = new List<ClienteDAO>();
            list = Funciones.mostrarCliente();
            List<String> listClientes = new List<String>();
            for (int j = 0; j < list.Count; j++) {
                listClientes.Add(list[j].Nombre);
               }
            cbmClientes.DataSource = listClientes;
            comboProductos.DataSource = listaProductos;
            

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.HeaderText = "Id";
            DataGridViewTextBoxColumn Nombre = new DataGridViewTextBoxColumn();
            Nombre.HeaderText = "Nombre";
            DataGridViewTextBoxColumn descripcion = new DataGridViewTextBoxColumn();
            descripcion.HeaderText = "Descripcion";
            DataGridViewTextBoxColumn precio = new DataGridViewTextBoxColumn();
            precio.HeaderText = "Precio";
            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();
            cantidad.HeaderText = "Cantidad";
            dataGridView1.Columns.Add(id);
            dataGridView1.Columns.Add(Nombre);
            dataGridView1.Columns.Add(descripcion);
            dataGridView1.Columns.Add(precio);
            dataGridView1.Columns.Add(cantidad);

        }
        String[] detalles = new string[5];
        List<String> cantidades = new List<string>();
        public void Agregardtgv(String nombre) {

            ProductoDAO n = new ProductoDAO();
            n = Funciones.mostrarProductoVenta2(nombre).ElementAt(0);
            listaVentas.Add(n);
            dataGridView1.Rows.Add(n.codigo,n.nombre,n.descripcion,n.precio,textBox1.Text);
            detalles[0] = Convert.ToString(n.codigo);
            detalles[1] = Convert.ToString(n.nombre);
            detalles[2] = Convert.ToString(n.descripcion);
            detalles[3] = Convert.ToString(n.precio);
            detalles[4] = Convert.ToString(textBox1.Text);
            cantidades.Add(textBox1.Text);
            textBox1.Text = "0";
        }
        

        private void Ventas_Load(object sender, EventArgs e)
        {
           
        }
        List<ProductoDAO> listaVentas = new List<ProductoDAO>();
        double total = 0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int contador = listaVentas.Count();
            //Agregardtgv(comboProductos.SelectedItem.ToString());
            Agregardtgv(comboProductos.SelectedItem.ToString());
            btnConfirmar.Enabled = true;
            total += Convert.ToDouble(detalles[3]) * Convert.ToInt32(detalles[4]);
         

            lblTotal.Text = total + "";



            
            





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu log = new Menu(ene,idem);
            log.Show();
            this.Hide();
        }
        int idVenta = Funciones.Venta();
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            int resultado = -1;

            try
            {
                VentaDAO venta = new VentaDAO();
                ClienteDAO cliente = new ClienteDAO();
                cliente = Funciones.mostrarCliente2(cbmClientes.SelectedItem.ToString()).ElementAt(0);

                DateTime today = DateTime.UtcNow.Date;
                MessageBox.Show(idem);
                venta.idventa = idVenta;
                venta.idempleado = Convert.ToInt32(idem);
                venta.idcliente = cliente.IdCliente;
                venta.fechaventa = today.ToString("yyyy-MM-dd");
                venta.totalventa = Convert.ToDouble(lblTotal.Text);

                int retorno = Funciones.AgregarVenta(venta);

                if (retorno > 0)
                {
                    //Si se agrego a la base de datos nos mandara un mensaje y despues se limpiaran los campos usados



                    dataGridView1.Rows.Clear();
                    btnConfirmar.Enabled = false;
                    lblTotal.Text = "0";
                    total = 0;


                    for (int i = 0; i < listaVentas.Count; i++)
                    {
                        DetallesDAO detalle = new DetallesDAO(venta.idventa, listaVentas.ElementAt(i).codigo, listaVentas.ElementAt(i).precio, Convert.ToInt32(cantidades.ElementAt(i)));
                        Funciones.AgregarDetalle(detalle);
                    }

                    cantidades = new List<string>();
                    listaVentas = new List<ProductoDAO>();
                    idVenta++;
                    int edit = Funciones.Editaride(idVenta);

                }
                else
                {
                    //Si no se agrego mandara un mensaje 
                    MessageBox.Show("No se generó la venta, verifique los datos");
                }
                resultado = Funciones.StartTransaccion();

            }
            catch (MySqlException ex)
            {
                resultado = Funciones.RollBackTransaccion();
                MessageBox.Show("Ocurrio un error en la base de datos");
            }
            finally
            {
                resultado = Funciones.CommitTransaccion();

            }
            if (resultado>0) {
                MessageBox.Show("Proceso correcto");
            }

           
        }
    }
}
