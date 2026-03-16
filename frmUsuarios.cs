using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmUsuarios : Form
    {
        public Usuario usuarioEditar { get; set; }
        public Usuario usuarioCreado { get; set; }
        public int idRolSeleccionado { get; set; }

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            var dt = datos.EjecutarConsulta(
                "SELECT IdEmpleado, StrNombre FROM TBLEMPLEADO");

            cbEmpleado.DataSource = dt;
            cbEmpleado.DisplayMember = "StrNombre";
            cbEmpleado.ValueMember = "IdEmpleado";

            var roles = datos.EjecutarConsulta(
                "SELECT IdRolEmpleado, StrDescripcion FROM TBLROLES");

            cbRol.DataSource = roles;
            cbRol.DisplayMember = "StrDescripcion";
            cbRol.ValueMember = "IdRolEmpleado";
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idEmpleado = Convert.ToInt32(cbEmpleado.SelectedValue);
            idRolSeleccionado = Convert.ToInt32(cbRol.SelectedValue);

            MessageBox.Show("Rol seleccionado: " + idRolSeleccionado);


            if (usuarioEditar == null)
            {
                usuarioCreado = new Usuario()
                {
                    IdEmpleado = idEmpleado,
                    NombreUsuario = txtLogin.Text,
                    Password = txtClave.Text
                };
            }
            else
            {
                usuarioEditar.IdEmpleado = idEmpleado;
                usuarioEditar.NombreUsuario = txtLogin.Text;
                usuarioEditar.Password = txtClave.Text;
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