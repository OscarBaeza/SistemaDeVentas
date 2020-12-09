using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.DAOS
{
    public class DetallesDAO
    {
        public int idVentas { get; set; }
        public int idProducto { get; set; }
        public double preio { get; set; }
        public int cantidad { get; set; }

        public DetallesDAO (int idVentas, int idProducto, double precio, int cantidad){
            this.idVentas=idVentas;
            this.idProducto = idProducto;
            this.preio = precio;
            this.cantidad = cantidad;
            }

        public DetallesDAO()
        {

        }


    }
}
