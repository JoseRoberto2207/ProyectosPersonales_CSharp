using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Proyecto3Capas.DAL;

namespace Proyecto3Capas.BLL
{
    public class BLLEvento
    {
        public static long InsEvento(int IdTipoEvento, int IdComida, int IdCliente, int IdServicios, DateTime FechaEvento)
        {
            //Cambiar la disponibilidad del TipoEvento, Comida y del Cliente
            //DALTipoEventos.UpdTipoEvento(IdTipoEvento, null, null, null, null, false, null);

            //DAL.UpdComida(IdComida, null, null, null, null, null, null, null, false);

            DALClientes.UpdCliente(IdCliente, null, null, null, null, null, null, false);

            return DALEvento.InsEvento(IdTipoEvento, IdComida, IdCliente, IdServicios, FechaEvento);

        }
    }
}