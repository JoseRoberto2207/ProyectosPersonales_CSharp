using System;
using System.Data;
using System.Data.SqlClient;

namespace Sydn.CRUD.DataEngine
{
    public class Data
    {
        SqlCommand command = new SqlCommand();
        static SqlConnection cntn = new SqlConnection("Server=LAPTOP-3NQVU8F1\\SQLEXPRESS;DataBase= Store;Integrated Security=true");
        
        public DataTable Mostrar()
        {
            SqlDataReader read;
            DataTable table = new DataTable();            

            try
            {
                cntn.Open();
                command.Connection = cntn;                
                command.CommandText = "spMostrarProductos";
                command.CommandType = CommandType.StoredProcedure;
                read = command.ExecuteReader();
                table.Load(read);
                cntn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }            
            return table;
        }
        public void InsertaProducto(string nombre, string descrip, string marca, double precio, int stock)
        {
            cntn.Open();
            command.Connection = cntn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spInsetarProductos";
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descrip", descrip);
            command.Parameters.AddWithValue("@marca", marca);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", stock);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cntn.Close();
        }
        public void EditarProducto(string nombre, string descrip, string marca, double precio, int stock, int id)
        {
            cntn.Open();
            command.Connection = cntn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spEditarProductos";
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descrip", descrip);
            command.Parameters.AddWithValue("@marca", marca);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", stock);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cntn.Close();
        }
        public void EliminarProducto(int id)
        {
            cntn.Open();
            command.Connection = cntn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spEliminarProducto";
            command.Parameters.AddWithValue("@idpro", id);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cntn.Close();
        }

    }
}
