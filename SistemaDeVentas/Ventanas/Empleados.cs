﻿using SistemaDeVentas.mysql;
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
    }
}
