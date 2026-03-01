using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public partial class frmInformes : Form
    {
        public frmInformes()
        {
            InitializeComponent();
        }

        private void frmInformes_Load(object sender, EventArgs e)
        {
            cbTipo.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvInformes.DataSource = null;

            switch (cbTipo.Text)
            {
                case "Facturas":
                    dgvInformes.DataSource = DatosSistema.Facturas;
                    break;

                case "Clientes":
                    dgvInformes.DataSource = DatosSistema.Clientes;
                    break;

                case "Productos":
                    dgvInformes.DataSource = DatosSistema.Productos;
                    break;

                case "Empleados":
                    dgvInformes.DataSource = DatosSistema.Empleados;
                    break;
            }
        }
    }
}