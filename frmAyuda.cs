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
    public partial class frmAyuda : Form
    {
        public frmAyuda()
        {
            InitializeComponent();
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;

            txtAyuda.Text = "Este módulo permite consultar la documentación del sistema de facturación.\r\n" +
                            "Para más información visite la página oficial.";
            webBrowser1.Navigate("https://www.microsoft.com");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAyuda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
