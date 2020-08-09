using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Proyecto3Capas.DAL;
using Proyecto3Capas.VO;

namespace Proyecto3Capas.BLL
{
    public class BLLTipoEventos
    {
        public static string InsTipoEvento(string Nombre, double Precio, string Descripcion,string UrlFoto, string Clave)
        {
            try
            {
                List<TipoEventoVO> LstTipoEventos = DALTipoEventos.GetListTipoEvento(null);//Se llena lista
                bool Existe = false;

                foreach (TipoEventoVO item in LstTipoEventos)//Recorre lista
                {
                    if (item.Clave == Clave)
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El tipo de evento ya fue utilizado con anterioridad";
                }
                else
                {
                    DALTipoEventos.InsTipoEvento(Nombre, Precio, Descripcion , UrlFoto, Clave);
                    return "Tipo de evento agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }// del InsertTipoEvento


        public static string UpdTipoEvento(int idTipoEvento, string Nombre, double Precio, string Descripcion, string UrlFoto, bool Disponibilidad, string Clave)
        {
            try
            {
                List<TipoEventoVO> LstTipoEventos = DALTipoEventos.GetListTipoEvento(null);//Se llena lista
                bool Existe = false;

                foreach (TipoEventoVO item in LstTipoEventos)//Recorre lista
                {
                    if ((item.IdTipoEvento != idTipoEvento) && (item.Clave == Clave))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "La clave del tipo de evento ya fue utilizada con anterioridad";
                }
                else
                {
                    DALTipoEventos.UpdTipoEvento(idTipoEvento, Nombre, Precio, Descripcion, UrlFoto, Disponibilidad, Clave);
                    //DALCamiones.UpdCamion(idCamion, Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad, UrlFoto);
                    return "Tipo Evento actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }// del UpdTipoEvento

        public static string DelTipoEvento(int IdTipoEvento)
        {
            try
            {
                TipoEventoVO TipoEvento = DALTipoEventos.GetTipoEventoById(IdTipoEvento);

                if (TipoEvento.Disponibilidad)
                {
                    DALTipoEventos.DelTipoEvento(IdTipoEvento);
                    return "Tipo Evento eliminado";
                }
                else
                {
                    return "El Tipo de Evento se encuentra en un evento o no está disponible";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del DeleteTipoEvento

        public static TipoEventoVO GetTipoEventoById(int IdTipoEvento)
        {
            try
            {
                return DALTipoEventos.GetTipoEventoById(IdTipoEvento);
            }
            catch (Exception)
            {
                return new TipoEventoVO();
            }
        } //del GetTipoEventoId


        public static List<TipoEventoVO> GetLstTipoEventos(bool? Disponibilidad)
        {
            List<TipoEventoVO> LstTipoEventos = new List<TipoEventoVO>();
            try
            {
                return DALTipoEventos.GetListTipoEvento(Disponibilidad);
            }
            catch (Exception)
            {
                return LstTipoEventos;
            }
        } // del GetLstTipoEventos


    }
}