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
    public partial class frmListaRoles : Form
    {
        public frmListaRoles()
        {
            InitializeComponent();
        }

        void CargarRoles()
        {
            AccesoDatos datos = new AccesoDatos();

            dgvRoles.DataSource = datos.EjecutarConsulta(
                "SELECT IdRolEmpleado, StrDescripcion FROM TBLROLES");
        }

        private void frmListaRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRoles frm = new frmRoles();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarRoles();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmRoles frm = new frmRoles();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarRoles();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null) return;

            frmRoles frm = new frmRoles();

            frm.IdRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRolEmpleado"].Value);
            frm.ShowDialog();

            CargarRoles();
        }
    }
}
