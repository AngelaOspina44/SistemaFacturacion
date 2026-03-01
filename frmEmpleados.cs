using System;
using System.Windows.Forms;

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
            if (empleadoEditar != null)
            {
                txtNombre.Text = empleadoEditar.Nombre;
                txtDocumento.Text = empleadoEditar.Documento;
                txtDireccion.Text = empleadoEditar.Direccion;
                txtTelefono.Text = empleadoEditar.Telefono;
                txtEmail.Text = empleadoEditar.Email;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (empleadoEditar != null)
            {
                // EDITAR
                empleadoEditar.Nombre = txtNombre.Text;
                empleadoEditar.Documento = txtDocumento.Text;
                empleadoEditar.Direccion = txtDireccion.Text;
                empleadoEditar.Telefono = txtTelefono.Text;
                empleadoEditar.Email = txtEmail.Text;
            }
            else
            {
                // NUEVO
                empleadoCreado = new Empleado()
                {
                    Nombre = txtNombre.Text,
                    Documento = txtDocumento.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text
                };
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