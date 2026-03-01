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
            dgvCategorias.AutoGenerateColumns = true;
            dgvCategorias.DataSource = DatosSistema.Categorias;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriaProductos frm = new frmCategoriaProductos();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DatosSistema.Categorias.Add(frm.categoriaCreada);

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = DatosSistema.Categorias;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = GridHelper.ObtenerFilaActual<Categoria>(dgvCategorias);
            if (seleccionado == null) return;

            DatosSistema.Categorias.Remove(seleccionado);

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = DatosSistema.Categorias;
        } 
        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SI hace clic en  el encabezado o espacio vacío, no hacer nada
            if (e.RowIndex < 0) return;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            {
                Categoria seleccionado = GridHelper.ObtenerFilaActual<Categoria>(dgvCategorias);
                if (seleccionado == null) return;

                frmCategoriaProductos frm = new frmCategoriaProductos();
                frm.categoriaEditar = seleccionado;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvCategorias.DataSource = null;
                    dgvCategorias.DataSource = DatosSistema.Categorias;
                }
            }
        }
    }
}