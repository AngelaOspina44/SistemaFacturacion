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
    public partial class frmListaCategorias : Form
    {
        public frmListaCategorias()
        {
            InitializeComponent();
        }

        private void frmListaCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }
        void CargarCategorias()
        {
            AccesoDatos datos = new AccesoDatos();

            dgvCategorias.DataSource = datos.EjecutarConsulta(
                "SELECT IdCategoria, StrDescripcion FROM TBLCATEGORIA_PROD");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriaProductos frm = new frmCategoriaProductos();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCategorias();   // refrescar el grid
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["IdCategoria"].Value);

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.EjecutarComando("DELETE FROM TBLCATEGORIA_PROD WHERE IdCategoria=" + id);
                MessageBox.Show("Categoría eliminada correctamente");

                CargarCategorias();
            }
            catch
            {
                MessageBox.Show(
                "No se puede eliminar esta categoría porque tiene productos asociados.",
                "Categoria en uso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SI hace clic en  el encabezado o espacio vacío, no hacer nada
            if (e.RowIndex < 0) return;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["IdCategoria"].Value);
            string descripcion = dgvCategorias.CurrentRow.Cells["StrDescripcion"].Value.ToString();

            frmCategoriaProductos frm = new frmCategoriaProductos();

            frm.categoriaEditar = new Categoria()
            {
                IdCategoria = id,
                Descripcion = descripcion
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCategorias();
            }
        }
    }
}