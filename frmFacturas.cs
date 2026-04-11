using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmFacturas : Form
    {
        public int IdFacturaEditar { get; set; } = 0;

        private bool facturaYaGuardada = false;
        private Factura facturaActual = new Factura();

        public frmFacturas()
        {
            InitializeComponent();
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

            DataRowView row = (DataRowView)cbProducto.SelectedItem;

            string nombre = row["Nombre"].ToString();
            decimal precio = Convert.ToDecimal(row["Precio"]);

            DetalleFactura det = new DetalleFactura()
            {
                Producto = new Producto { Nombre = nombre, Precio = precio },
                Cantidad = (int)nudCantidad.Value,
                Precio = precio
            };

            facturaActual.Detalles.Add(det);

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = facturaActual.Detalles;

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = facturaActual.Detalles.Sum(d => d.Subtotal);

            decimal descuento = 0;
            decimal.TryParse(txtDescuento.Text, out descuento);

            decimal iva = subtotal * 0.19m;
            decimal total = subtotal + iva - descuento;

            txtIVA.Text = iva.ToString("0.00");
            lblTotalFactura.Text = total.ToString("0.00");
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            facturaYaGuardada = false;

            AccesoDatos datos = new AccesoDatos();

            cbCliente.DataSource = datos.EjecutarConsulta("SELECT IdCliente, Nombre FROM Clientes");
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "IdCliente";

            cbEmpleado.DataSource = datos.EjecutarConsulta("SELECT IdEmpleado, Nombre FROM Empleados");
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.ValueMember = "IdEmpleado";

            cbProducto.DataSource = datos.EjecutarConsulta("SELECT IdProducto, Nombre, Precio FROM Productos");
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember = "IdProducto";

            cbEstado.DataSource = datos.EjecutarConsulta("SELECT IdEstadoFactura, StrDescripcion FROM TBLESTADO_FACTURA");
            cbEstado.DisplayMember = "StrDescripcion";
            cbEstado.ValueMember = "IdEstadoFactura";

            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.DataSource = facturaActual.Detalles;

            if (IdFacturaEditar > 0)
            {
                CargarFacturaParaEditar();
            }
        }

        private void CargarFacturaParaEditar()
        {
            AccesoDatos datos = new AccesoDatos();

            DataTable dt = datos.EjecutarConsulta($@"
                SELECT * FROM TBLFACTURA WHERE IdFactura = {IdFacturaEditar}");

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            dtpFecha.Value = Convert.ToDateTime(row["DtmFecha"]);
            cbCliente.SelectedValue = Convert.ToInt32(row["IdCliente"]);
            cbEmpleado.SelectedValue = Convert.ToInt32(row["IdEmpleado"]);
            cbEstado.SelectedValue = Convert.ToInt32(row["IdEstado"]);

            txtDescuento.Text = row["NumDescuento"].ToString();
            txtIVA.Text = row["NumImpuesto"].ToString();
            lblTotalFactura.Text = row["NumValorTotal"].ToString();
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

            int idCliente = (int)cbCliente.SelectedValue;
            int idEmpleado = (int)cbEmpleado.SelectedValue;
            int idEstado = (int)cbEstado.SelectedValue;

            decimal descuento = 0;
            decimal.TryParse(txtDescuento.Text, out descuento);

            decimal subtotal = facturaActual.Detalles.Sum(d => d.Subtotal);
            decimal iva = subtotal * 0.19m;
            decimal total = subtotal + iva - descuento;

            AccesoDatos datos = new AccesoDatos();

            string consulta;

            if (IdFacturaEditar == 0)
            {
                // INSERT
                consulta = $@"
                INSERT INTO TBLFACTURA
                (DtmFecha, IdCliente, IdEmpleado, NumDescuento, NumImpuesto, NumValorTotal, IdEstado, DtmFechaModifica, StrUsuarioModifica)
                VALUES
                ('{dtpFecha.Value:yyyy-MM-dd}',
                {idCliente},
                {idEmpleado},
                {descuento.ToString(CultureInfo.InvariantCulture)},
                {iva.ToString(CultureInfo.InvariantCulture)},
                {total.ToString(CultureInfo.InvariantCulture)},
                {idEstado},
                GETDATE(),
                'sistema')";
            }
            else
            {
                // UPDATE
                consulta = $@"
                UPDATE TBLFACTURA SET
                DtmFecha = '{dtpFecha.Value:yyyy-MM-dd}',
                IdCliente = {idCliente},
                IdEmpleado = {idEmpleado},
                NumDescuento = {descuento.ToString(CultureInfo.InvariantCulture)},
                NumImpuesto = {iva.ToString(CultureInfo.InvariantCulture)},
                NumValorTotal = {total.ToString(CultureInfo.InvariantCulture)},
                IdEstado = {idEstado},
                DtmFechaModifica = GETDATE(),
                StrUsuarioModifica = 'sistema'
                WHERE IdFactura = {IdFacturaEditar}";
            }

            datos.EjecutarComando(consulta);

            facturaYaGuardada = true;

            MessageBox.Show("Factura guardada correctamente");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}