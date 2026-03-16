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
    public partial class frmRoles : Form
    {
        public int IdRol = 0;
        public frmRoles()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            if (IdRol == 0)
            {
                string sql = "INSERT INTO TBLROLES(StrDescripcion) VALUES('" + txtRol.Text + "')";
                datos.EjecutarComando(sql);
            }
            else
            {
                string sql = "UPDATE TBLROLES SET StrDescripcion='" + txtRol.Text +
                             "' WHERE IdRolEmpleado=" + IdRol;

                datos.EjecutarComando(sql);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
