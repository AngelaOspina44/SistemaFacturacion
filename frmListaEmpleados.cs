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

        void CargarEmpleados()
        {
            AccesoDatos datos = new AccesoDatos();

            dgvEmpleados.DataSource = datos.EjecutarConsulta(
                "SELECT IdEmpleado, StrNombre AS Nombre, NumDocumento AS Documento, StrDireccion AS Direccion, StrTelefono AS Telefono, StrEmail AS Email FROM TBLEMPLEADO");
        }

        private void frmListaEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarGrid()
        {
            AccesoDatos datos = new AccesoDatos();
            dgvEmpleados.DataSource = datos.EjecutarConsulta("SELECT * FROM Empleados");
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
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado");
                return;
            }

            frmEmpleados frm = new frmEmpleados();

            frm.empleadoEditar = new Empleado()
            {
                IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value),
                Nombre = dgvEmpleados.CurrentRow.Cells["Nombre"].Value.ToString(),
                Documento = Convert.ToInt64(dgvEmpleados.CurrentRow.Cells["Documento"].Value),
                Direccion = dgvEmpleados.CurrentRow.Cells["Direccion"].Value.ToString(),
                Telefono = dgvEmpleados.CurrentRow.Cells["Telefono"].Value.ToString(),
                Email = dgvEmpleados.CurrentRow.Cells["Email"].Value.ToString()
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarEmpleados();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null) return;

            if (MessageBox.Show("¿Eliminar empleado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idEmpleado = Convert.ToInt32(
                    dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);

                AccesoDatos datos = new AccesoDatos();

                // Primero eliminar en seguridad
                datos.EjecutarComando("DELETE FROM TBLSEGURIDAD WHERE IdEmpleado=" + idEmpleado);

                // Luego eliminar el empleado
                datos.EjecutarComando("DELETE FROM TBLEMPLEADO WHERE IdEmpleado=" + idEmpleado);

                CargarGrid();
            }
        }
    }
}