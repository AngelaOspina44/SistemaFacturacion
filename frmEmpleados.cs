using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmEmpleados : Form
    {
        public Empleado empleadoEditar { get; set; }
        public Empleado empleadoCreado { get; set; }

        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            // Asegura que el textbox solo permita números
            txtDocumento.KeyPress += txtDocumento_KeyPress;

            if (empleadoEditar != null)
            {
                txtNombre.Text = empleadoEditar.Nombre;
                txtDocumento.Text = empleadoEditar.Documento.ToString();
                txtDireccion.Text = empleadoEditar.Direccion;
                txtTelefono.Text = empleadoEditar.Telefono;
                txtEmail.Text = empleadoEditar.Email;
            }
        }

        // Solo permite números en documento
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();
            string docTexto = txtDocumento.Text.Trim();

            if (nombre == "")
            {
                MessageBox.Show("Ingrese el nombre del empleado");
                return;
            }

            if (docTexto == "")
            {
                MessageBox.Show("Ingrese el documento");
                return;
            }

            long documento;

            if (!long.TryParse(docTexto, out documento))
            {
                MessageBox.Show("El documento debe ser numérico");
                return;
            }

            if (empleadoEditar != null)
            {
                string sql = "UPDATE TBLEMPLEADO SET " +
                             "StrNombre='" + nombre + "'," +
                             "NumDocumento=" + documento + "," +
                             "StrDireccion='" + direccion + "'," +
                             "StrTelefono='" + telefono + "'," +
                             "StrEmail='" + email + "' " +
                             "WHERE IdEmpleado=" + empleadoEditar.IdEmpleado;

                datos.EjecutarComando(sql);
                MessageBox.Show("Empleado actualizado correctamente");
            }
            else
            {
                string sql = "INSERT INTO TBLEMPLEADO(StrNombre,NumDocumento,StrDireccion,StrTelefono,StrEmail) VALUES('"
                            + nombre + "',"
                            + documento + ",'"
                            + direccion + "','"
                            + telefono + "','"
                            + email + "')";

                datos.EjecutarComando(sql);
                MessageBox.Show("Empleado guardado correctamente");
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