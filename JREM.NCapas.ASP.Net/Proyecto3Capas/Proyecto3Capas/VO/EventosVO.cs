using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Proyecto3Capas.VO
{
    public class EventosVO
    {
        private int _IdEvento;
        private string _Nombre;
        private string _FotoTipoEvento;
        private string _Clave;
        private string _FotoComida;
        private DateTime _FechaEvento;
        private bool _ETiempo;

        public int IdEvento
        {
            get
            {
                return _IdEvento;
            }

            set
            {
                _IdEvento = value;
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

        public string FotoTipoEvento
        {
            get
            {
                return _FotoTipoEvento;
            }

            set
            {
                _FotoTipoEvento = value;
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

        public string FotoComida
        {
            get
            {
                return _FotoComida;
            }

            set
            {
                _FotoComida = value;
            }
        }

        public DateTime FechaEvento
        {
            get
            {
                return _FechaEvento;
            }

            set
            {
                _FechaEvento = value;
            }
        }

        public bool ETiempo
        {
            get
            {
                return _ETiempo;
            }

            set
            {
                _ETiempo = value;
            }
        }

        public EventosVO()
        {
            IdEvento = 0;
            Nombre = "";
            FotoTipoEvento = "";
            Clave = "";
            FotoComida = "";
            FechaEvento = DateTime.Now;
            ETiempo = false;
        }

        public EventosVO(DataRow dr)
        {
            IdEvento = int.Parse(dr["IdEvento"].ToString());
            Nombre = dr["Nombre"].ToString();
            FotoTipoEvento = dr["FotoTipoEvento"].ToString();
            Clave = dr["Clave"].ToString();
            FotoComida = dr["FotoComida"].ToString();
            FechaEvento = DateTime.Parse(dr["FechaEvento"].ToString());
            ETiempo = bool.Parse(dr["ETiempo"].ToString());
        }

    }
}