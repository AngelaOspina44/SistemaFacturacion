using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmClientes : Form
    {
        public Cliente clienteEditar { get; set; }
        public Cliente clienteCreado { get; set; }
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            if (clienteEditar != null)
            {
                txtNombre.Text = clienteEditar.Nombre;
                txtDocumento.Text = clienteEditar.Documento;
                txtDireccion.Text = clienteEditar.Direccion;
                txtTelefono.Text = clienteEditar.Telefono;
                txtEmail.Text = clienteEditar.Email;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (clienteEditar != null)
            {
                // EDITAR
                clienteEditar.Nombre = txtNombre.Text;
                clienteEditar.Documento = txtDocumento.Text;
                clienteEditar.Direccion = txtDireccion.Text;
                clienteEditar.Telefono = txtTelefono.Text;
                clienteEditar.Email = txtEmail.Text;
            }
            else
            {
                // NUEVO
                clienteCreado = new Cliente()
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
    }
}   