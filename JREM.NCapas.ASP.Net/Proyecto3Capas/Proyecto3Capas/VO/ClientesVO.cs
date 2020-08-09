using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Proyecto3Capas.VO
{
    public class ClientesVO
    {
        #region datos privados
        private int _IdCliente;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private string _Telefono;
        private string _Correo;
        private string _UrlFoto;
        private bool _Disponibilidad;
        #endregion

        #region Propiedades del objeto
        public int IdCliente
        {
            get
            {
                return _IdCliente;
            }

            set
            {
                _IdCliente = value;
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

        public string ApPaterno
        {
            get
            {
                return _ApPaterno;
            }

            set
            {
                _ApPaterno = value;
            }
        }

        public string ApMaterno
        {
            get
            {
                return _ApMaterno;
            }

            set
            {
                _ApMaterno = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return _Correo;
            }

            set
            {
                _Correo = value;
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
        #endregion

        #region Constructores
        public ClientesVO()
        {
            IdCliente = 0;
            Nombre = "";
            ApPaterno = "";
            ApMaterno = "";
            Telefono = "";
            Correo = "";
            UrlFoto = "";
            Disponibilidad = false;
        }

        public ClientesVO(DataRow dr)
        {
            IdCliente = int.Parse(dr["IdCliente"].ToString()); ;
            Nombre = dr["Nombre"].ToString();
            ApPaterno = dr["ApPaterno"].ToString();
            ApMaterno = dr["ApMaterno"].ToString();
            Telefono = dr["Telefono"].ToString();
            Correo = dr["Correo"].ToString();
            UrlFoto = dr["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }
        #endregion

    }
}