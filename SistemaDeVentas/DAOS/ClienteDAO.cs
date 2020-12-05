using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.DAOS
{
    public class ClienteDAO
    {
        public int IdCliente { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        public ClienteDAO(string nombre, string apellidoPaterno, string apellidoMaterno, string email, string direccion, string telefono)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Email = email;
            Direccion = direccion;
            Telefono = telefono;
        }

        public ClienteDAO(int idCliente, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string direccion, string telefono)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Email = email;
            Direccion = direccion;
            Telefono = telefono;
        }

        public ClienteDAO()
        {
        }
    }
}
