﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.DAOS
{ 
    //Aqui vanm a ir todos los empleados
    public class EmpleadosDAO
    {
        public int IdEmpleado { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Email { get; set; }
        public String password { get; set; }
        public Boolean Encargado { get; set; }
        public String Date { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        public EmpleadosDAO(String Nombre, String ApellidoPaterno, String ApellidoMaterno, String Email, String password, Boolean Encargado, String Date, String Direccion, String Telefono)
        {
            this.Nombre = Nombre;
            this.ApellidoPaterno = ApellidoPaterno;
            this.ApellidoMaterno = ApellidoMaterno;
            this.Email = Email;
            this.password = password;
            this.Encargado = Encargado;
            this.Date = Date;
            this.Direccion = Direccion;
            this.Telefono = Telefono;

        }

        public EmpleadosDAO(int IdEmpleado, String Nombre, String ApellidoPaterno, String ApellidoMaterno, String Email, String password, Boolean Encargado, String Date, String Direccion, String Telefono)
        {
            this.IdEmpleado = IdEmpleado;
            this.Nombre = Nombre;
            this.ApellidoPaterno = ApellidoPaterno;
            this.ApellidoMaterno = ApellidoMaterno;
            this.Email = Email;
            this.password = password;
            this.Encargado = Encargado;
            this.Date = Date;
            this.Direccion = Direccion;
            this.Telefono = Telefono;

        }

        public EmpleadosDAO()
        {

        }



    }
}
