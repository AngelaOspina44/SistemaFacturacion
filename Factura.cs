using System;
using System.Collections.Generic;

namespace Pantallas_Sistema_facturacion1
{
    public class Factura
    {
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Estado { get; set; }

        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }

        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();

        public decimal TotalFactura
        {
            get
            {
                decimal subtotal = 0;
                foreach (var d in Detalles)
                    subtotal += d.Subtotal;

                return subtotal - Descuento + IVA;
            }
        }
    }
}