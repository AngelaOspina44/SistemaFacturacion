using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_Sistema_facturacion1
{
    public class Producto
    {
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}