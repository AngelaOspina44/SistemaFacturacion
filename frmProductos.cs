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
    public partial class frmProductos : Form
    {
        public Producto productoEditar { get; set; }
        public Producto productoCreado { get; set; }
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            cbCategoria.DataSource = DatosSistema.Categorias;
            cbCategoria.DisplayMember = "Nombre";

            if (productoEditar != null)
            {
                txtNombre.Text = productoEditar.Nombre;
                cbCategoria.SelectedItem = productoEditar.Categoria;
                txtPrecio.Text = productoEditar.Precio.ToString();
                txtStock.Text = productoEditar.Stock.ToString();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre");
                return;
            }

            if (cbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Stock inválido");
                return;
            }

            // CREAR PRODUCTO
            productoCreado = new Producto()
            {
                Nombre = txtNombre.Text,
                Categoria = (Categoria)cbCategoria.SelectedItem,
                Precio = precio,
                Stock = stock
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
