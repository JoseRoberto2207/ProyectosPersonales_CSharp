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
    public class DALTipoEventos
    {
        static SqlConnection conn = new SqlConnection
        (ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public static void InsTipoEvento(string Nombre, double Precio, string Descripcion, string UrlFoto, string Clave)
        {
            try
            {
                conn.Open();
                string Query = "InsTipoEvento";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Precio", Precio);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                cmd.Parameters.AddWithValue("@Clave", Clave);
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
        }// del InsTipoEvento

        public static void UpdTipoEvento(int IdTipoEvento, string Nombre, double? Precio, string Descripcion, string UrlFoto, bool? Disponibilidad, string Clave)
        {
            try
            {
                conn.Open();
                string Query = "UpdTipoEvento";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoEvento", IdTipoEvento);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Precio", Precio);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                cmd.Parameters.AddWithValue("@Clave", Clave);
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
        }// del UpdTipoEvento

        public static void DelTipoEvento(int IdTipoEvento)
        {
            try
            {
                conn.Open();
                string Query = "DelTipoEvento";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoEvento", IdTipoEvento);
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
        }// del DelTipoEvento

        public static TipoEventoVO GetTipoEventoById(int IdTipoEvento)
        {
            try
            {
                string Query = "GetTipoEventoById";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoEvento", IdTipoEvento);
            
                DataSet dsTipoEvento = new DataSet();
                adapter.Fill(dsTipoEvento);

                if (dsTipoEvento.Tables[0].Rows.Count > 0)
                {
                    //Encontro un registro
                    DataRow dr = dsTipoEvento.Tables[0].Rows[0];
                    TipoEventoVO TipoEvento = new TipoEventoVO(dr);
                    return TipoEvento;
                }
                else
                {
                    //La tabla está vacía
                    TipoEventoVO TipoEvento = new TipoEventoVO();
                    return TipoEvento;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }// del GetTipoEventoById

        public static List<TipoEventoVO> GetListTipoEvento(bool? Disponibilidad)
        {
            string Query = "ListTipoEventos";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dsTipoEventos = new DataSet();

            try
            {
                if (Disponibilidad == null)
                {
                    //Traigo todos los camiones de la tabla
                    adapter.Fill(dsTipoEventos);
                }
                else
                {
                    //Traigo todos los camiones según Disponibilidad
                    cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                    adapter.Fill(dsTipoEventos);
                }
                List<TipoEventoVO> LstTipoEventos = new List<TipoEventoVO>();

                foreach (DataRow dr in dsTipoEventos.Tables[0].Rows)
                {
                    LstTipoEventos.Add(new TipoEventoVO(dr));
                }

                return LstTipoEventos;
            }
            catch
            {
                throw;
            }
        } // del GetListCamiones
    }
}