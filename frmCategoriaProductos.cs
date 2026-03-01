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
    public partial class frmCategoriaProductos : Form
    {
        public Categoria categoriaCreada { get; set; }
        public Categoria categoriaEditar = null;
        public frmCategoriaProductos()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            if (categoriaEditar != null)
            {
                // EDITAR
                categoriaEditar.Nombre = txtNombre.Text;
                categoriaEditar.Descripcion = txtDescripcion.Text;
            }
            else
            {
                // NUEVO
                categoriaCreada = new Categoria()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmCategoriaProductos_Load(object sender, EventArgs e)
        {
            if (categoriaEditar != null)
            {
                txtNombre.Text = categoriaEditar.Nombre;
                txtDescripcion.Text = categoriaEditar.Descripcion;
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
