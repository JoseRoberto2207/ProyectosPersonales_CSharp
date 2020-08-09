using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using Proyecto3Capas.BLL;
using Proyecto3Capas.VO;

namespace Proyecto3Capas.Catalogos.TipoEventos
{
    public partial class EdicionTipoEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Primera carga de la página
            {
                //Obtenemos la información del Camión seleccionado
                string Id = Request.QueryString["Id"];
                if ((Id == null) || (!IsNumeric(Id)))
                {
                    Response.Redirect("ListaTipoEventos.aspx");
                }
                else
                {
                    //Verificamos que el camion exista
                    TipoEventoVO TipoEvento = BLLTipoEventos.GetTipoEventoById(int.Parse(Id));
                    if (TipoEvento.IdTipoEvento == int.Parse(Id))
                    {
                        //Desplegamos la información del camion
                        lblIdTipoEvento.Text = TipoEvento.IdTipoEvento.ToString();

                        txtNombre.Text = TipoEvento.Nombre;
                        txtPrecio.Text = TipoEvento.Precio.ToString();
                        txtDescripcion.Text = TipoEvento.Descripcion;
                        chkDisponibilidad.Checked = TipoEvento.Disponibilidad;
                        txtClave.Text = TipoEvento.Clave;
                        UrlFoto.InnerText = TipoEvento.UrlFoto;
                    }
                    else
                    {
                        Response.Redirect("ListaTipoEventos.aspx");
                    }
                }
            }
        }

        private bool IsNumeric(string id)
        {
            float output;
            return float.TryParse(id, out output);
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //Guardar foto.
            try
            {
                //Validar que el usuario haya seleccionado un archivo
                if (SubeImagen.Value != "")
                {
                    //Subimos el archivo
                    string FileName =
                        Path.GetFileName(SubeImagen.PostedFile.FileName);
                    //Validamos que el archivo sea .jpg o .png
                    string FileExt = Path.GetExtension(FileName).ToLower();
                    if ((FileExt != ".jpg") && (FileExt != ".png"))
                    {
                        //Informamos al usuario que el archivo no es válido
                        Util.Library.UtilControls.SweetBox("Atención!", "Seleccione un archivo válido", "warning", this.Page, this.GetType());
                    }
                    else
                    {
                        //Verificar que el directorio destino exista
                        string PathDir =
                            Server.MapPath("~/Imagenes/Camiones/");
                        if (!Directory.Exists(PathDir))
                        {
                            //Creamos el directorio
                            Directory.CreateDirectory(PathDir);
                        }
                        //Guardamos el archivo 
                        SubeImagen.PostedFile.SaveAs(PathDir + FileName);
                        string urlfoto = "/Imagenes/Camiones/" + FileName;
                        UrlFoto.InnerText = urlfoto;
                        imgFotoCamion.ImageUrl = urlfoto;
                        btnGuardar.Visible = true;
                    }
                }
                else
                {
                    //Informamos al usuario que el archivo no es válido
                    Util.Library.UtilControls.SweetBox("Atención!", "Seleccione un archivo válido", "warning", this.Page, this.GetType());
                }

            }
            catch (Exception ex)
            {
                //Enviar mensaje de error al usuario
                Util.Library.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdTipoEvento = int.Parse(lblIdTipoEvento.Text);
                string Nombre = txtNombre.Text;
                double Precio = double.Parse(txtPrecio.Text);
                string Descripcion = txtDescripcion.Text;
                string urlfoto = UrlFoto.InnerText;
                bool Disponibilidad = chkDisponibilidad.Checked;
                string Clave = txtClave.Text;
                string Resultado =
                BLLTipoEventos.UpdTipoEvento(IdTipoEvento, Nombre, Precio, Descripcion, urlfoto, Disponibilidad, Clave);
                //BLLCamiones.UpdCamion(IdCamion, Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad, urlfoto);
                if (Resultado.IndexOf("Tipo Evento actualizado correctamente") > -1)
                {
                    Util.Library.UtilControls.SweetBoxConfirm("OK!", Resultado, "success", "ListaTipoEventos.aspx", this.Page, this.GetType());
                }
                else
                {
                    //Mensaje de error
                    Util.Library.UtilControls.SweetBox("Atención!", Resultado, "warning", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {
                //Enviar mensaje de error
                Util.Library.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        } // del btnGuardar_Click

    }
}