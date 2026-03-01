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
    public partial class frmMenuNuevo : Form
    {
        public frmMenuNuevo()
        {
            InitializeComponent();
        }

        private Form formularioActivo = null;

        private void AbrirFormulario(Form formulario)
        {
            // Cerrar el formulario anterior correctamente
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Clear();
            pnlContenedor.Controls.Add(formulario);
            pnlContenedor.Tag = formulario;

            formulario.BringToFront();
            formulario.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaClientes());
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaProductos());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaCategorias());
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaFacturas());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaEmpleados());
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaUsuarios());
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInformes());
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAyuda());
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
            frmAcerca f = (new frmAcerca());
            f.ShowDialog();
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaClientes());
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaProductos());
        }

        private void btnCategorias_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaCategorias());
        }

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaEmpleados());
        }

        private void btnFacturas_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaFacturas());
        }

        private void btnSeguridad_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaUsuarios());
        }

        private void btnInformes_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInformes());
        }

        private void btnAyuda_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAyuda());
        }

        private void btnAcerca_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAcerca());
        }
    }
}