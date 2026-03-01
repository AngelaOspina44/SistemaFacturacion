using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_Sistema_facturacion1
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Nombre;
        }

    }

}
