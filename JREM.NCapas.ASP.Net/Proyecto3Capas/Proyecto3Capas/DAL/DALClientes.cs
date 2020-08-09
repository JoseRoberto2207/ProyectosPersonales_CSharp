using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Proyecto3Capas.VO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto3Capas.DAL
{
    public class DALClientes
    {
        static SqlConnection conn = new SqlConnection
        (ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public static void InsCliente(string Nombre, string ApPaterno, string ApMaterno, string Telefono, string Correo, string UrlFoto)
        {
            try
            {
                conn.Open();
                string Query = "InsCliente";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", ApMaterno);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }// del InsCliente

        public static void UpdCliente(int IdCliente, string Nombre, string ApPaterno, string ApMaterno, string Telefono, string Correo, string UrlFoto, bool? Disponibilidad)
        {
            try
            {
                conn.Open();
                string Query = "UpdCliente";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", ApMaterno);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }// del Updcliente

        public static void DelCliente(int IdCliente)
        {
            try
            {
                conn.Open();
                string Query = "DelCliente";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }// del Delcliente

        public static ClientesVO GetClienteById(int IdCliente)
        {
            try
            {
                string Query = "GetClienteById";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                DataSet dsCliente = new DataSet();
                adapter.Fill(dsCliente);

                if (dsCliente.Tables[0].Rows.Count > 0)
                {
                    //Encontro un registro
                    DataRow dr = dsCliente.Tables[0].Rows[0];
                    ClientesVO Cliente = new ClientesVO(dr);
                    return Cliente;
                }
                else
                {
                    //La tabla está vacía
                    ClientesVO Cliente = new ClientesVO();
                    return Cliente;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }// del GetClienteById

        public static List<ClientesVO> GetListClientes(bool? Disponibilidad)
        {
            string Query = "ListClientes";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dsClientes = new DataSet();

            try
            {
                if (Disponibilidad == null)
                {
                    //Traigo todos los camiones de la tabla
                    adapter.Fill(dsClientes);
                }
                else
                {
                    //Traigo todos los camiones según Disponibilidad
                    cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                    adapter.Fill(dsClientes);
                }
                List<ClientesVO> LstClientes = new List<ClientesVO>();

                foreach (DataRow dr in dsClientes.Tables[0].Rows)
                {
                    LstClientes.Add(new ClientesVO(dr));
                }

                return LstClientes;
            }
            catch
            {
                throw;
            }
        } // del GetListClientes








    }
}