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
        AccesoDatos datos = new AccesoDatos();
        public Producto productoEditar { get; set; }

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            cbCategoria.DataSource = datos.EjecutarConsulta(
                "SELECT IdCategoria, StrDescripcion FROM TBLCATEGORIA_PROD");

            cbCategoria.DisplayMember = "StrDescripcion";
            cbCategoria.ValueMember = "IdCategoria";

            if (productoEditar != null)
            {
                txtNombre.Text = productoEditar.Nombre;
                txtPrecio.Text = productoEditar.Precio.ToString();
                cbCategoria.SelectedValue = productoEditar.IdCategoria;
            }
        }   
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (productoEditar == null)
            {

                int idCategoria = Convert.ToInt32(cbCategoria.SelectedValue);

                string sql = "INSERT INTO TBLPRODUCTO(StrNombre,StrCodigo,NumPrecioCompra,NumPrecioVenta,NumStock,IdCategoria,DtmFechaModifica,StrUsuarioModifica) VALUES('"
                            + txtNombre.Text + "','COD001',"
                            + txtPrecio.Text + ","
                            + txtPrecio.Text + ","
                            + txtStock.Text + ","
                            + cbCategoria.SelectedValue +
                            ",GETDATE(),'Sistema')";

                datos.EjecutarComando(sql);
                MessageBox.Show("Producto guardado");
            }
            else
            {
                string sql = "UPDATE TBLPRODUCTO SET StrNombre='" + txtNombre.Text +
                             "',IdCategoria=" + cbCategoria.SelectedValue +
                             ",NumPrecioVenta=" + txtPrecio.Text +
                             ",NumStock=" + txtStock.Text +
                             " WHERE IdProducto=" + productoEditar.IdProducto;

                datos.EjecutarComando(sql);
                MessageBox.Show("Producto actualizado");
            }

            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
