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
    public partial class frmListaProductos : Form
    {
        public frmListaProductos()
        {
            InitializeComponent();
        }

        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = DatosSistema.Productos;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            Producto seleccionado = dgvProductos.CurrentRow.DataBoundItem as Producto;
            if (seleccionado == null) return;

            frmProductos frm = new frmProductos();
            frm.productoEditar = seleccionado;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvProductos.Refresh();
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos.DataSource = DatosSistema.Productos;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DatosSistema.Productos.Add(frm.productoCreado);
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = DatosSistema.Productos;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            Producto seleccionado = dgvProductos.CurrentRow.DataBoundItem as Producto;
            if (seleccionado == null) return;

            frmProductos frm = new frmProductos();
            frm.productoEditar = seleccionado;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvProductos.Refresh();
            }
        }
    }
}
