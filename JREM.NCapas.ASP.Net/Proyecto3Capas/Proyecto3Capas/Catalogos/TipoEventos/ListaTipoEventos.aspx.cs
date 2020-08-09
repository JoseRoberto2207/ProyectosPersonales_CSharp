using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Proyecto3Capas.BLL;
using System.IO;


namespace Proyecto3Capas.Catalogos.TipoEventos
{
    public partial class ListaTipoEventos : System.Web.UI.Page
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
            GVTipoEventos.DataSource = BLLTipoEventos.GetLstTipoEventos(null);
            GVTipoEventos.DataBind();
        }  // del RefrescaGrid


        protected void GVTipoEventos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            /*Label lbltipoC = (Label)GVTipoEventos.Rows[e.NewEditIndex].FindControl("lblTipoEvento");
            string tipoC = lbltipoC.Text;*/
            //Ponemos el renglón seleccionado en modo edición
            GVTipoEventos.EditIndex = e.NewEditIndex;
            RefrescaGrid();
            /*DropDownList DDLTipoCamionAux = (DropDownList)GVTipoEventos.Rows[e.NewEditIndex].FindControl("DDLTipoCamion");
            Util.Library.UtilControls.EnumToListBox(typeof(TipoEvento), DDLTipoCamionAux, false);
            DDLTipoCamionAux.SelectedValue = tipoC;*/
        }

        protected void GVTipoEventos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Regrese mi renglón a modo normal
            GVTipoEventos.EditIndex = -1;
            RefrescaGrid();
        }

        protected void GVTipoEventos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string IdTipoEvento = GVTipoEventos.DataKeys[e.RowIndex].Values["IdTipoEvento"].ToString();
            string Nombre = e.NewValues["Nombre"].ToString();
            double Precio = double.Parse(e.NewValues["Precio"].ToString());
            string Descripcion = e.NewValues["Descripcion"].ToString();
            //Disponibilidad
            CheckBox ChkAux = (CheckBox)GVTipoEventos.Rows[e.RowIndex].FindControl("ChkEditDisponible");
            bool Disponibilidad = ChkAux.Checked;
            string Clave = e.NewValues["Clave"].ToString();
            
            //DropDownList TipoCamionAux = (DropDownList)GVTipoEventos.Rows[e.RowIndex].FindControl("DDLTipoCamion");

            //string TipoCamion = TipoCamionAux.SelectedValue;

            //bool Disponibilidad = bool.Parse(e.NewValues["Disponibilidad"].ToString());

            try
            {
                string resultado = BLLTipoEventos.UpdTipoEvento(int.Parse(IdTipoEvento), Nombre, Precio, Descripcion, null, Disponibilidad, Clave);
                GVTipoEventos.EditIndex = -1;
                RefrescaGrid();
                Util.Library.UtilControls.SweetBox(resultado, "", "success", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.Library.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }// fin metodo

        protected void GVTipoEventos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdTipoEvento = GVTipoEventos.DataKeys[e.RowIndex].Values["IdTipoEvento"].ToString();
            try
            {
                string Resultado = BLLTipoEventos.DelTipoEvento(int.Parse(IdTipoEvento));
                string mensaje = "";
                //string sub = "";
                string clase = "";


                if (Resultado == "Tipo Evento eliminado")
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

        protected void GVTipoEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {  //Server.Transfer
                int index = int.Parse(e.CommandArgument.ToString());
                string IdTipoEvento = GVTipoEventos.DataKeys[index].Values["IdTipoEvento"].ToString();
                Response.Redirect("EdicionTipoEvento.aspx?Id=" + IdTipoEvento);
            }
        }




    }
}