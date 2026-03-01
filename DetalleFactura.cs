namespace Pantallas_Sistema_facturacion1
{
    public class DetalleFactura
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Subtotal
        {
            get { return Cantidad * Precio; }
        }
    }
}