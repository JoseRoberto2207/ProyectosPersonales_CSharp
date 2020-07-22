using System;
using System.Data;
using Sydn.CRUD.DataEngine;

namespace Sydn.CRUD.LogicEngine
{
    public class Logic
    {
        Data data = new Data();
        public DataTable MostrarProd()
        {            
            DataTable table;
            try
            {                
                table = data.Mostrar();                
            }
            catch (Exception ex)
            {

                throw;
            }
            return table;
        }
        public void InsertProduct(string nombre, string descrip, string marca, string precio, string stock)
        {
            data.InsertaProducto(nombre, descrip, marca, double.Parse(precio), int.Parse(stock));
        }

        public void EditProduct(string nombre, string descrip, string marca, string precio, string stock, string id)
        {
            data.EditarProducto(nombre, descrip, marca, double.Parse(precio), int.Parse(stock), int.Parse(id));
        }

        public void EliminarProduct(string id)
        {
            data.EliminarProducto(int.Parse(id));
        }


    }
}
