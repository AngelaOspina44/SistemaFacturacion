using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion1
{
    public static class GridHelper
    {
        public static T ObtenerFilaActual<T>(DataGridView dgv) where T : class
        {
            if (dgv == null)
                return null;

            if (dgv.CurrentRow == null)
                return null;

            if (dgv.CurrentRow.Index < 0)
                return null;

            if (dgv.CurrentRow.DataBoundItem == null)
                return null;

            return dgv.CurrentRow.DataBoundItem as T;
        }
    }
}