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
    AccesoDatos datos = new AccesoDatos();

    if (categoriaEditar == null)
    {
        string sql = "INSERT INTO TBLCATEGORIA_PROD(StrDescripcion, DtmFechaModifica, StrUsuarioModifico) VALUES('"
                     + txtDescripcion.Text +
                     "', GETDATE(), 'Sistema')";

        datos.EjecutarComando(sql);
    }
    else
    {
        string sql = "UPDATE TBLCATEGORIA_PROD SET StrDescripcion='"
                     + txtDescripcion.Text +
                     "' WHERE IdCategoria=" + categoriaEditar.IdCategoria;

        datos.EjecutarComando(sql);
    }

    this.DialogResult = DialogResult.OK;
    this.Close();
}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                txtDescripcion.Text = categoriaEditar.Descripcion;
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
