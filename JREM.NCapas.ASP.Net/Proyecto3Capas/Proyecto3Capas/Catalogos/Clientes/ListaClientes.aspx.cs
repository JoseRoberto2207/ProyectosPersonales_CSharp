using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Proyecto3Capas.BLL;
using System.IO;

namespace Proyecto3Capas.Catalogos.Clientes
{
    public partial class ListaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RefrescaGrid();
                }
                catch (Exception ex)
                {
                    Util.Library.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
                }
            }
        } //del PageLoad

        private void RefrescaGrid()
        {
            //Llenar el grid con una lista de CamionVO
            GVClientes.DataSource = BLLClientes.GetLstClientes(null);
            GVClientes.DataBind();
        }  // del RefrescaGrid

        protected void GVClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Ponemos el renglón seleccionado en modo edición
            GVClientes.EditIndex = e.NewEditIndex;
            RefrescaGrid();
        }

        protected void GVClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Regrese mi renglón a modo normal
            GVClientes.EditIndex = -1;
            RefrescaGrid();
        }

        protected void GVClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string IdCliente = GVClientes.DataKeys[e.RowIndex].Values["IdCliente"].ToString();
            string Nombre = e.NewValues["Nombre"].ToString();
            string ApPaterno = e.NewValues["ApPaterno"].ToString();
            string ApMaterno = e.NewValues["ApMaterno"].ToString();
            string Telefono = e.NewValues["Telefono"].ToString();
            string Correo = e.NewValues["Correo"].ToString();

            //Disponibilidad
            CheckBox ChkAux = (CheckBox)GVClientes.Rows[e.RowIndex].FindControl("ChkEditDisponible");
            bool Disponibilidad = ChkAux.Checked;

            try
            {
                string resultado = BLLClientes.UpdCliente(int.Parse(IdCliente), Nombre, ApPaterno, ApMaterno, Telefono, Correo, null, Disponibilidad);
                GVClientes.EditIndex = -1;
                RefrescaGrid();
                Util.Library.UtilControls.SweetBox(resultado, "", "success", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.Library.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }// fin metodo

        protected void GVClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdCliente = GVClientes.DataKeys[e.RowIndex].Values["IdCliente"].ToString();
            try
            {
                string Resultado = BLLClientes.DelCliente(int.Parse(IdCliente));
                string mensaje = "";
                //string sub = "";
                string clase = "";


                if (Resultado == "Cliente eliminado")
                {
                    mensaje = "OK!";
                    clase = "success";
                    //sub = Resultado;
                }
                else
                {
                    mensaje = "Atención!";
                    clase = "warning";
                    //sub = Resultado;
                }

                //Creamos el log de borrado
                string[] args = new string[3];
                args[0] = mensaje;
                args[1] = Resultado;// sub;
                args[2] = DateTime.Now.ToShortDateString();
                WriteLog(args);

                RefrescaGrid();
                Util.Library.UtilControls.SweetBox(mensaje, Resultado, clase, this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.Library.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        } // fin de metodo

        private void WriteLog(string[] args)
        {
            StreamWriter log;
            string ServerUnc = Server.MapPath("Logs");
            if (!Directory.Exists(ServerUnc))
            {
                Directory.CreateDirectory(ServerUnc);
            }
            string FileLog = ServerUnc + @"\logfile.log";
            if (!File.Exists(FileLog))
            {
                log = new StreamWriter(FileLog);
            }
            else
            {
                log = File.AppendText(FileLog);
            }

            log.Write("\r\nLog Entry: ");
            log.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            log.WriteLine(" :");
            log.WriteLine(" :{0}", args[0]);
            log.WriteLine(" :{0}", args[1]);
            log.WriteLine(" :{0}", args[2]);
            log.WriteLine("----------------");
            log.Close();

        }

        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {  //Server.Transfer
                int index = int.Parse(e.CommandArgument.ToString());
                string IdCliente = GVClientes.DataKeys[index].Values["IdCliente"].ToString();
                Response.Redirect("EdicionCliente.aspx?Id=" + IdCliente);
            }
        }




    }
}