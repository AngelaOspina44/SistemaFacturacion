using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DATOS DE PRUEBA
            DatosSistema.Categorias.Add(new Categoria { Nombre = "Aseo personal" });
            DatosSistema.Categorias.Add(new Categoria { Nombre = "Bebidas" });
            DatosSistema.Categorias.Add(new Categoria { Nombre = "Tecnología" });

            DatosSistema.Productos.Add(new Producto { Nombre = "Shampoo", Precio = 30000, Stock = 10 });
            DatosSistema.Productos.Add(new Producto { Nombre = "Gaseosa", Precio = 5000, Stock = 20 });

            // ADMIN POR DEFECTO
            DatosSistema.Usuarios.Add(new Usuario
            {
                NombreUsuario = "admin",
                Password = "1234"
            });

            Application.Run(new frmLogin());    
        }
    }
}
