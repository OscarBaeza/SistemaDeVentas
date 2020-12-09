using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.DAOS
{
    public class VentaDAO
    {
        public int idventa { get; set; }
        public int idcliente { get; set; }
        public int idempleado { get; set; }
        public string fechaventa { get; set; }
        public double totalventa { get; set; }

        public VentaDAO(int idventa, int idcliente, int idempleado, string fechaventa, double totalventa)
        {
            this.idventa = idventa;
            this.idcliente = idcliente;
            this.idempleado = idempleado;
            this.fechaventa = fechaventa;
            this.totalventa = totalventa;
        }

        public VentaDAO(int idcliente, int idempleado, string fechaventa, double totalventa)
        {
            this.idcliente = idcliente;
            this.idempleado = idempleado;
            this.fechaventa = fechaventa;
            this.totalventa = totalventa;
        }

        public VentaDAO()
        {
        }
    }
}
