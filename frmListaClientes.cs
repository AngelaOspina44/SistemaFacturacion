using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmListaClientes : Form
    {
        public frmListaClientes()
        {
            InitializeComponent();
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = DatosSistema.Clientes;
        }

        // NUEVO CLIENTE
        private void button1_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DatosSistema.Clientes.Add(frm.clienteCreado);
            }
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente seleccionado = GridHelper.ObtenerFilaActual<Cliente>(dgvClientes);
            if (seleccionado == null) return;

            DatosSistema.Clientes.Remove(seleccionado);
        }

        // EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente seleccionado = GridHelper.ObtenerFilaActual<Cliente>(dgvClientes);
            if (seleccionado == null) return;

            frmClientes frm = new frmClientes();
            frm.clienteEditar = seleccionado;
            frm.ShowDialog();
        }
    }
}