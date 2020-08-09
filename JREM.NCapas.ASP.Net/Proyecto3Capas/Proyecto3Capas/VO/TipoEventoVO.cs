using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Proyecto3Capas.VO
{
    public class TipoEventoVO
    {
        #region datos privados
        private int _IdTipoEvento;
        private string _Nombre;
        private double _Precio;
        private string _Descripcion;
        private string _UrlFoto;
        private bool _Disponibilidad;
        private string _Clave;
        #endregion

        #region Propiedades del objeto
        public int IdTipoEvento
        {
            get
            {
                return _IdTipoEvento;
            }

            set
            {
                _IdTipoEvento = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public double Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string UrlFoto
        {
            get
            {
                return _UrlFoto;
            }

            set
            {
                _UrlFoto = value;
            }
        }

        public bool Disponibilidad
        {
            get
            {
                return _Disponibilidad;
            }

            set
            {
                _Disponibilidad = value;
            }
        }

        public string Clave
        {
            get
            {
                return _Clave;
            }

            set
            {
                _Clave = value;
            }
        }
        #endregion

        #region Constructores
        public TipoEventoVO()
        {

            IdTipoEvento = 0;
            Nombre = "";
            Precio = 0;
            Descripcion = "";
            UrlFoto = "";
            Disponibilidad = false;
            Clave = "";

        }

        public TipoEventoVO(DataRow dr)
        {
            IdTipoEvento = int.Parse(dr["IdTipoEvento"].ToString());
            Nombre = dr["Nombre"].ToString();
            Precio = double.Parse(dr["Precio"].ToString());
            Descripcion = dr["Descripcion"].ToString();
            UrlFoto = dr["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
            Clave = dr["Clave"].ToString();
        }
        #endregion


    }
}