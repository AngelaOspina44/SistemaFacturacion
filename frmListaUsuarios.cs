using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmListaUsuarios : Form
    {
        public frmListaUsuarios()
        {
            InitializeComponent();
        }

        private void frmListaUsuarios_Load(object sender, EventArgs e)
        {
            Cargar();
            dgvUsuarios.ColumnHeadersVisible = true;
        }

        private void Cargar()
        {
            AccesoDatos datos = new AccesoDatos();

            var dt = datos.EjecutarConsulta(
                "SELECT IdSeguridad, StrUsuario, StrClave FROM TBLSEGURIDAD ORDER BY StrUsuario");

            dgvUsuarios.DataSource = dt;

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                AccesoDatos datos = new AccesoDatos();

                int idEmpleado = frm.usuarioCreado.IdEmpleado;
                int idRol = frm.idRolSeleccionado;

                string sql = "INSERT INTO TBLSEGURIDAD (IdEmpleado,StrUsuario,StrClave) VALUES ("
                             + idEmpleado + ",'"
                             + frm.usuarioCreado.NombreUsuario + "','"
                             + frm.usuarioCreado.Password + "')";

                string sqlRol = "UPDATE TBLEMPLEADO SET IdRolEmpleado=" + idRol +
                                " WHERE IdEmpleado=" + idEmpleado;

                datos.EjecutarComando(sql);
                datos.EjecutarComando(sqlRol);

                Cargar();
            }
        }

        // EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            Usuario seleccionado = new Usuario()
            {
                IdUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdSeguridad"].Value),
                NombreUsuario = dgvUsuarios.CurrentRow.Cells["StrUsuario"].Value.ToString(),
                Password = dgvUsuarios.CurrentRow.Cells["StrClave"].Value.ToString()
            };

            frmUsuarios frm = new frmUsuarios();
            frm.usuarioEditar = seleccionado;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                AccesoDatos datos = new AccesoDatos();

                string sql = "UPDATE TBLSEGURIDAD SET " +
                             "StrUsuario='" + seleccionado.NombreUsuario + "'," +
                             "StrClave='" + seleccionado.Password + "' " +
                             "WHERE IdSeguridad=" + seleccionado.IdUsuario;

                datos.EjecutarComando(sql);

                MessageBox.Show("Usuario actualizado");

                Cargar();
            }
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdSeguridad"].Value);

            var r = MessageBox.Show("¿Eliminar usuario?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                AccesoDatos datos = new AccesoDatos();

                datos.EjecutarComando("DELETE FROM TBLSEGURIDAD WHERE IdSeguridad=" + idUsuario);

                MessageBox.Show("Usuario eliminado");

                Cargar();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}