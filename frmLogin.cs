using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

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
            var usuario = DatosSistema.Usuarios
                .FirstOrDefault(u =>
                    u.Login == txtUsuario.Text &&
                    u.Clave == txtClave.Text);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                return;
            }

            // guardamos quien inició sesión
            DatosSistema.UsuarioActual = usuario;

            frmMenuNuevo menu = new frmMenuNuevo();
            menu.Show();
            this.Hide();
        }
    }
}
