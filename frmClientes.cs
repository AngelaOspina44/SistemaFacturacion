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
        AccesoDatos datos = new AccesoDatos();

        int idClienteSeleccionado = 0;
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
                if (clienteEditar == null)
                {
                    // INSERT (NUEVO)
                    string sql = "INSERT INTO Clientes(Nombre,Documento,Telefono,Direccion,Email) VALUES('"
                    + txtNombre.Text + "','"
                    + txtDocumento.Text + "','"
                    + txtTelefono.Text + "','"
                    + txtDireccion.Text + "','"
                    + txtEmail.Text + "')";

                    datos.EjecutarComando(sql);
                    MessageBox.Show("Cliente guardado correctamente");
                }
                else
                {
                    // UPDATE (EDITAR)
                    string sql = "UPDATE Clientes SET Nombre='" + txtNombre.Text +
                                  "',Documento='" + txtDocumento.Text +
                                  "',Telefono='" + txtTelefono.Text +
                                  "',Direccion='" + txtDireccion.Text +
                                  "',Email='" + txtEmail.Text +
                                  "' WHERE IdCliente=" + clienteEditar.IdCliente;

                    datos.EjecutarComando(sql);
                    MessageBox.Show("Cliente actualizado correctamente");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
