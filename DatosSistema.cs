using System.Collections.Generic;
using System.ComponentModel;

namespace Pantallas_Sistema_facturacion1
{
    public static class DatosSistema
    {
        public static Usuario UsuarioActual;
        public static BindingList<Cliente> Clientes = new BindingList<Cliente>();
        public static BindingList<Producto> Productos = new BindingList<Producto>();
        public static BindingList<Categoria> Categorias = new BindingList<Categoria>();
        public static BindingList<Empleado> Empleados = new BindingList<Empleado>();
        public static BindingList<Factura> Facturas = new BindingList<Factura>();
        public static BindingList<Usuario> Usuarios = new BindingList<Usuario>();
    }
}