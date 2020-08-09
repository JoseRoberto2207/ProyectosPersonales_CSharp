using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Util.Library;
using Proyecto3Capas.BLL;
using Proyecto3Capas.VO;
using System.Data;

namespace Proyecto3Capas.Evento
{
    public partial class AltaEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // es la primer carga de la pagina
            {
                //Llena las lista del formulario
                Util.Library.UtilControls.EnumToListBox(typeof(Comidas), DDLComidas, true);
                //Util.Library.UtilControls.EnumToListBox(typeof(Comidas), DDLComidas, false);

                DDLComidas.Items.Insert(0, new ListItem("Selecciona Comida", ""));
                DDLComidas.SelectedIndex = 0;

                //Llenamos los combos de camión y chofer
                UtilControls.FillDropDownList(DDLTipoEvento, "IdTipoEvento", "Nombre",BLLTipoEventos.GetLstTipoEventos(true), "", "Selecciona Tipo Evento");
                UtilControls.FillDropDownList(DDLCliente, "IdCliente", "Nombre", BLLClientes.GetLstClientes(true), "", "Selecciona Cliente");
                Session["CargaRuta"] = null;
            }
        }

        protected void DDLTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtenemos la capacidad del camión seleccionado
            if (DDLTipoEvento.SelectedValue != "")
            {
                //Traemos la capacidad y la asignamos a txtCapCamion
                //EventosVO Camion = BLLEvento.GetEvById(int.Parse(DDLCamion.SelectedValue));
                //txtCapCamion.Text = Camion.Capacidad.ToString();
            }
            else
            {
                //txtCapCamion.Text = "";

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            double Karaoke = double.Parse(txtKaraoke.Text);
            double Licores = double.Parse(txtLicores.Text);
            double ValetParking = double.Parse(txtValetParking.Text);
            double Dj = double.Parse(txtDj.Text);
            double Payaso = double.Parse(txtPayaso.Text);

            //ToDo: DESCOMENTAR WS y Comentar int IdOrigenDestino = 1
            ////Instanciar nuestro servicio web
            WSInsServicios.WebServiceSoapClient WSServicio = new WSInsServicios.WebServiceSoapClient(); 
            string IdServicios = WSServicio.InsertarServicio(Karaoke, Licores, ValetParking, Dj, Payaso);
            int IdServicio = 1;

            try
            {
                int IdTipoEvento = int.Parse(DDLTipoEvento.SelectedValue);
                //int IdComida = int.Parse(DDLComidas.SelectedValue);
                int IdComida = int.Parse(DDLComidas.SelectedValue);
                int IdCliente = int.Parse(DDLCliente.SelectedValue);
                DateTime fEvento = DateTime.Parse(FEvento.Value);
            
                //Insertamos el evento y obtenemos el id del mismo
                long idEvento = BLLEvento.InsEvento(IdTipoEvento, IdComida, IdCliente, IdServicio, fEvento);

 
                Util.Library.UtilControls.SweetBoxConfirm("Ok!", "Evento generado", "success", "ListaEvento.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.Library.UtilControls.SweetBox("Error!", ex.ToString(), "error", this.Page, this.GetType());
            }
        }

        /*private void InsertarServicio(long idServicio)
        {
            
        }*/
    }
}