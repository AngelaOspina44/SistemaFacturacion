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
    public partial class frmAcerca : Form
    {
        public frmAcerca()
        {
            InitializeComponent();
        }

        private void frmAcerca_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Versión " + Application.ProductVersion;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void lblYear_Click(object sender, EventArgs e)
        {

        }

        private void lblCurso_Click(object sender, EventArgs e)
        {

        }

        private void lblAutor_Click(object sender, EventArgs e)
        {

        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
