using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmListaEmpleados : Form
    {
        public frmListaEmpleados()
        {
            InitializeComponent();
        }

        private void frmListaEmpleados_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = DatosSistema.Empleados;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = new frmEmpleados();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DatosSistema.Empleados.Add(frm.empleadoCreado);
                CargarGrid();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null) return;

            Empleado emp = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            frmEmpleados frm = new frmEmpleados();
            frm.empleadoEditar = emp;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrid();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null) return;

            Empleado emp = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            if (MessageBox.Show("¿Eliminar empleado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatosSistema.Empleados.Remove(emp);
                CargarGrid();
            }
        }
    }
}