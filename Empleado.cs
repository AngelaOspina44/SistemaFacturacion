namespace Pantallas_Sistema_facturacion1
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public long Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}