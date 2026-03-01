using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmFacturas : Form
    {
        public Factura facturaEditar { get; set; }
        public frmFacturas()
        {
            InitializeComponent();
        }
        private void CargarProductos()
        {
            cbProducto.DataSource = null;
            cbProducto.DataSource = DatosSistema.Productos;
            cbProducto.DisplayMember = "Nombre";
        }

        private bool facturaYaGuardada = false;

        private Factura facturaActual = new Factura();

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("Ingrese cantidad válida");
                return;
            }

            Producto prod = (Producto)cbProducto.SelectedItem;

            DetalleFactura det = new DetalleFactura()
            {
                Producto = prod,
                Cantidad = (int)nudCantidad.Value,
                Precio = prod.Precio
            };

            facturaActual.Detalles.Add(det);

            dgvDetalle.Refresh();

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = facturaActual.Detalles.Sum(d => d.Subtotal);
            decimal iva = subtotal * 0.19m;

            txtIVA.Text = iva.ToString("0.00");
            lblTotalFactura.Text = (subtotal + iva - facturaActual.Descuento).ToString("0.00");
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            CargarProductos();

            facturaYaGuardada = false;

            // Clientes
            cbCliente.DataSource = DatosSistema.Clientes;

            // Empleados
            cbEmpleado.DataSource = DatosSistema.Empleados;

            // Productos
            cbProducto.DataSource = DatosSistema.Productos;

            // Estados
            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Pagada");
            cbEstado.SelectedIndex = 0;

            // Tabla detalle

            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.DataSource = facturaActual.Detalles;
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (facturaYaGuardada)
            {
                MessageBox.Show("Esta factura ya fue guardada.");
                return;
            }

            if (cbCliente.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            if (cbEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado");
                return;
            }

            if (facturaActual.Detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto");
                return;
            }

            facturaActual.Cliente = (Cliente)cbCliente.SelectedItem;
            facturaActual.Empleado = (Empleado)cbEmpleado.SelectedItem;
            facturaActual.FechaRegistro = dtpFecha.Value;
            facturaActual.Estado = cbEstado.Text;

            decimal descuento = 0;
            decimal.TryParse(txtDescuento.Text, out descuento);
            facturaActual.Descuento = descuento;

            facturaActual.Numero = DatosSistema.Facturas.Count + 1;

            DatosSistema.Facturas.Add(facturaActual);

            facturaYaGuardada = true;

            MessageBox.Show("Factura guardada correctamente");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
