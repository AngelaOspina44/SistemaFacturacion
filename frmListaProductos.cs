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
        AccesoDatos datos = new AccesoDatos();
        int idProductoSeleccionado = 0;
        public frmListaProductos()
        {
            InitializeComponent();
        }

        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        void CargarProductos()
        {
            dgvProductos.DataSource = datos.EjecutarConsulta(
                "SELECT IdProducto,Nombre,Categoria,Precio,Stock FROM Productos");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            frmProductos frm = new frmProductos();

            frm.productoEditar = new Producto()
            {
                IdProducto = idProductoSeleccionado,
                Nombre = dgvProductos.CurrentRow.Cells["Nombre"].Value?.ToString(),
                Categoria = dgvProductos.CurrentRow.Cells["Categoria"].Value?.ToString(),
                Precio = dgvProductos.CurrentRow.Cells["Precio"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvProductos.CurrentRow.Cells["Precio"].Value),
                Stock = dgvProductos.CurrentRow.Cells["Stock"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvProductos.CurrentRow.Cells["Stock"].Value)
            };

            frm.ShowDialog();
            CargarProductos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            datos.EjecutarComando("DELETE FROM TBLPRODUCTO WHERE IdProducto=" + idProductoSeleccionado);

            MessageBox.Show("Producto eliminado");
            CargarProductos();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null &&
                dgvProductos.CurrentRow.Cells[0].Value != null &&
                dgvProductos.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                idProductoSeleccionado =
                    Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
            }
            else
            {
                idProductoSeleccionado = 0;
            }
        }
    }
}
