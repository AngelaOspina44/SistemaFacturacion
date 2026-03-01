using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmUsuarios : Form
    {
        public Usuario usuarioEditar { get; set; }
        public Usuario usuarioCreado { get; set; }

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cbRol.Items.Clear();
            cbRol.Items.Add("Administrador");
            cbRol.Items.Add("Cajero");

            if (usuarioEditar != null)
            {
                txtNombre.Text = usuarioEditar.Nombre;
                txtLogin.Text = usuarioEditar.Login;
                txtClave.Text = usuarioEditar.Clave;
                cbRol.Text = usuarioEditar.Rol;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usuarioEditar != null)
            {
                // EDITAR
                usuarioEditar.Nombre = txtNombre.Text;
                usuarioEditar.Login = txtLogin.Text;
                usuarioEditar.Clave = txtClave.Text;
                usuarioEditar.Rol = cbRol.Text;
            }
            else
            {
                // NUEVO
                usuarioCreado = new Usuario()
                {
                    Nombre = txtNombre.Text,
                    Login = txtLogin.Text,
                    Clave = txtClave.Text,
                    Rol = cbRol.Text
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}