using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Util.Library.Database;

namespace Proyecto3Capas.DAL
{
    public class DALEvento
    {
        public static long InsEvento(int IdTipoEvento, int IdComida, int IdCliente, int IdServicios, DateTime FechaEvento)
        {
            try
            {
                return
                    DBConnection.ExecuteNonQueryGetIdentity
                        ("InsEvento", "@IdTipoEvento", IdTipoEvento,
                                    "@IdComida", IdComida,
                                    "@IdCliente", IdCliente,
                                    "@IdServicios", IdServicios,
                                    "@FechaEvento", FechaEvento);
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}