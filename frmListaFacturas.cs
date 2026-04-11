using System;
using System.Data;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmListaFacturas : Form
    {
        public frmListaFacturas()
        {
            InitializeComponent();
        }

        private void frmListaFacturas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            AccesoDatos datos = new AccesoDatos();

            dgvFacturas.DataSource = datos.EjecutarConsulta(@"
            SELECT 
                f.IdFactura AS Numero,
                f.DtmFecha AS FechaRegistro,
                c.Nombre AS Cliente,
                e.Nombre AS Empleado,
                f.NumDescuento AS Descuento,
                f.NumImpuesto AS IVA,
                f.NumValorTotal AS TotalFactura,
                CASE 
                    WHEN f.IdEstado = 1 THEN 'Pendiente Pago'
                    WHEN f.IdEstado = 2 THEN 'Pagada'
                    WHEN f.IdEstado = 3 THEN 'Anulada'
                    WHEN f.IdEstado = 4 THEN 'Vencida'
                    ELSE 'Desconocido'
                END AS Estado
            FROM TBLFACTURA f
            INNER JOIN Clientes c ON f.IdCliente = c.IdCliente
            INNER JOIN Empleados e ON f.IdEmpleado = e.IdEmpleado
            ");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmFacturas frm = new frmFacturas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null) return;

            DataRowView row = (DataRowView)dgvFacturas.CurrentRow.DataBoundItem;

            int idFactura = Convert.ToInt32(row["Numero"]);

            frmFacturas frm = new frmFacturas();
            frm.IdFacturaEditar = idFactura;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null) return;

            DataRowView row = (DataRowView)dgvFacturas.CurrentRow.DataBoundItem;

            int idFactura = Convert.ToInt32(row["Numero"]);

            if (MessageBox.Show("¿Eliminar factura?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AccesoDatos datos = new AccesoDatos();

                string consulta = $"DELETE FROM TBLFACTURA WHERE IdFactura = {idFactura}";

                datos.EjecutarComando(consulta);

                CargarGrilla();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}