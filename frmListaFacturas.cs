using System;
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
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = DatosSistema.Facturas;
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

            Factura factura = (Factura)dgvFacturas.CurrentRow.DataBoundItem;

            frmFacturas frm = new frmFacturas();
            frm.facturaEditar = factura;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null) return;

            Factura factura = (Factura)dgvFacturas.CurrentRow.DataBoundItem;

            if (MessageBox.Show("¿Eliminar factura?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatosSistema.Facturas.Remove(factura);
                CargarGrilla();
            }
        }
    }
}