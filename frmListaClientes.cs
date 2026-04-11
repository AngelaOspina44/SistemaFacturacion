using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmListaClientes : Form
    {
        int idClienteSeleccionado = 0;
        AccesoDatos datos = new AccesoDatos();
        public frmListaClientes()
        {
            InitializeComponent();
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        void CargarClientes()
        {
            AccesoDatos datos = new AccesoDatos();

            dgvClientes.DataSource = datos.EjecutarConsulta(
                "SELECT * FROM Clientes");
        }

        // NUEVO CLIENTE    
        private void button1_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            // VALIDAR SI TIENE FACTURAS
            int tieneFacturas = Convert.ToInt32(
                datos.EjecutarScalar("SELECT COUNT(*) FROM TBLFACTURA WHERE IdCliente=" + idClienteSeleccionado));

            if (tieneFacturas > 0)
            {
                MessageBox.Show("No se puede eliminar el cliente porque tiene facturas registradas");
                return;
            }

            // eliminar cliente
            datos.EjecutarComando("DELETE FROM TBLCLIENTES WHERE IdCliente=" + idClienteSeleccionado);

            MessageBox.Show("Cliente eliminado correctamente");
            CargarClientes();
        }

        // EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            frmClientes frm = new frmClientes();

            frm.clienteEditar = new Cliente()
            {
                IdCliente = idClienteSeleccionado,
                Nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString(),
                Documento = dgvClientes.CurrentRow.Cells[2].Value.ToString(),
                Direccion = dgvClientes.CurrentRow.Cells[3].Value.ToString(),
                Telefono = dgvClientes.CurrentRow.Cells[4].Value.ToString(),  
                Email = dgvClientes.CurrentRow.Cells[5].Value.ToString()
            };

            frm.ShowDialog();
            CargarClientes();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null &&
                dgvClientes.CurrentRow.Cells[0].Value != null &&
                dgvClientes.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                idClienteSeleccionado =
                    Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            }
            else
            {
                idClienteSeleccionado = 0;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}