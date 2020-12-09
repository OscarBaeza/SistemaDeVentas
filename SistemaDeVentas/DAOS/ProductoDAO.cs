using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.DAOS
{
    public class ProductoDAO
    {
        
            public int codigo { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public int almacen { get; set; }
            public double precio { get; set; }

            public ProductoDAO(object toString)
            {

            }

            public ProductoDAO(string nombre, string descripcion, int almacen, double precio)
            {
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.almacen = almacen;
                this.precio = precio;
            }

            public ProductoDAO(int codigo, string nombre, string descripcion, int almacen, double precio)
            {
                this.codigo = codigo;
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.almacen = almacen;
                this.precio = precio;
            }

        public ProductoDAO()
        {
        }
    }
    
}
