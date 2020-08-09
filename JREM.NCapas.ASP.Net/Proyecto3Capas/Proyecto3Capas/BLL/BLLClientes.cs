using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Proyecto3Capas.DAL;
using Proyecto3Capas.VO;

namespace Proyecto3Capas.BLL
{
    public class BLLClientes
    {
        public static string InsCliente(string Nombre, string ApPaterno, string ApMaterno, string Telefono, string Correo, string UrlFoto)
        {
            try
            {
                List<ClientesVO> LstClientes = DALClientes.GetListClientes(null);//Se llena lista
                bool Existe = false;

                foreach (ClientesVO item in LstClientes)//Recorre lista
                {
                    if (item.Nombre == Nombre & item.ApPaterno == ApPaterno && item.ApMaterno == ApMaterno)
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El nombre de cliente ya fue utilizado con anterioridad";
                }
                else
                {
                    DALClientes.InsCliente(Nombre, ApPaterno, ApMaterno, Telefono, Correo, UrlFoto);
                    return "Cliente agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }// del InsertCliente

        public static string UpdCliente(int idCliente, string Nombre, string ApPaterno, string ApMaterno, string Telefono, string Correo,string UrlFoto, bool Disponibilidad)
        {
            try
            {
                List<ClientesVO> LstClientes = DALClientes.GetListClientes(null);//Se llena lista
                bool Existe = false;

                foreach (ClientesVO item in LstClientes)//Recorre lista
                {
                    if ((item.IdCliente != idCliente) && (item.Nombre == Nombre) && (item.ApPaterno == ApPaterno) && (item.ApMaterno == ApMaterno))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El nombre del cliente ya fue utilizado con anterioridad";
                }
                else
                {
                    DALClientes.UpdCliente(idCliente, Nombre, ApPaterno, ApMaterno, Telefono, Correo, UrlFoto, Disponibilidad);
                    return "Cliente actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }// del UpdCliente

        public static string DelCliente(int IdCliente)
        {
            try
            {
                ClientesVO Cliente = DALClientes.GetClienteById(IdCliente);

                if (Cliente.Disponibilidad)
                {
                    DALClientes.DelCliente(IdCliente);
                    return "Cliente eliminado";
                }
                else
                {
                    return "El Cliente se encuentra en un evento o no está disponible";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del DeleteCliente

        public static ClientesVO GetClienteById(int IdCliente)
        {
            try
            {
                return DALClientes.GetClienteById(IdCliente);
            }
            catch (Exception)
            {
                return new ClientesVO();
            }
        } //del GetClienteId

        public static List<ClientesVO> GetLstClientes(bool? Disponibilidad)
        {
            List<ClientesVO> LstClientes = new List<ClientesVO>();
            try
            {
                return DALClientes.GetListClientes(Disponibilidad);
            }
            catch (Exception)
            {
                return LstClientes;
            }
        } // del GetLstClientes

    }
}