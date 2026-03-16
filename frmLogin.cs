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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pnlIzquierdo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña");
                return;
            }

            AccesoDatos datos = new AccesoDatos();

            string sql = "SELECT S.IdSeguridad, S.StrUsuario, R.StrDescripcion " +
                         "FROM TBLSEGURIDAD S " +
                         "INNER JOIN TBLEMPLEADO E ON S.IdEmpleado = E.IdEmpleado " +
                         "INNER JOIN TBLROLES R ON E.IdRolEmpleado = R.IdRolEmpleado " +
                         "WHERE S.StrUsuario='" + txtUsuario.Text +
                         "' AND S.StrClave='" + txtClave.Text + "'";

            DataTable dt = datos.EjecutarConsulta(sql);

            if (dt.Rows.Count > 0)
            {
                Sesion.IdUsuario = Convert.ToInt32(dt.Rows[0]["IdSeguridad"]);
                Sesion.Usuario = dt.Rows[0]["StrUsuario"].ToString();
                Sesion.Rol = dt.Rows[0]["StrDescripcion"].ToString();

                MessageBox.Show("Bienvenido " + Sesion.Usuario);

                frmMenuNuevo menu = new frmMenuNuevo();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
