using System;
using System.Data;
using System.Data.SqlClient;

class AccesoDatos
{
    private SqlConnection conexion =
    new SqlConnection("Server=Angela;Database=[DBFACTURAS];User Id=sa;Password=Sa123456;TrustServerCertificate=True;");

    public DataTable EjecutarConsulta(string consulta)
    {
        SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public object EjecutarScalar(string consulta)
    {
        SqlCommand cmd = new SqlCommand(consulta, conexion);
        conexion.Open();
        object resultado = cmd.ExecuteScalar();
        conexion.Close();
        return resultado;
    }

    public void EjecutarComando(string consulta)
    {
        conexion.Open();
        SqlCommand cmd = new SqlCommand(consulta, conexion);
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    //MÉTODOS PARA EL SISTEMA

    public DataTable ObtenerClientes()
    {
        return EjecutarConsulta("SELECT * FROM Clientes");
    }

    public DataTable ObtenerProductos()
    {
        return EjecutarConsulta("SELECT * FROM Productos");
    }

    public DataTable ObtenerEmpleados()
    {
        return EjecutarConsulta("SELECT * FROM Empleados");
    }

    public DataTable ObtenerCategorias()
    {
        return EjecutarConsulta("SELECT * FROM Categorias");
    }
}