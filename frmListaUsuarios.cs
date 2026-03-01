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
        }

        private void Cargar()
        {
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = DatosSistema.Usuarios;
        }

        // =========================
        // NUEVO
        // =========================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DatosSistema.Usuarios.Add(frm.usuarioCreado);
                Cargar();
            }
        }

        // =========================
        // EDITAR
        // =========================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            Usuario seleccionado = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

            frmUsuarios frm = new frmUsuarios();
            frm.usuarioEditar = seleccionado;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvUsuarios.Refresh();
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            Usuario seleccionado = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

            var r = MessageBox.Show("¿Eliminar usuario?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                DatosSistema.Usuarios.Remove(seleccionado);
                Cargar();
            }
        }
    }
}