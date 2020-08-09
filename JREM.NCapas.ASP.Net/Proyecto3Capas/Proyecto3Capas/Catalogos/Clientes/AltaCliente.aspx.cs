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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que el usuario haya seleccionado un archivo
                if (SubeImagen.Value != "")
                {
                    //Subimos el archivo
                    string FileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
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
                        string PathDir = Server.MapPath("~/Imagenes/TipoEventos/");
                        if (!Directory.Exists(PathDir))
                        {
                            //Creamos el directorio
                            Directory.CreateDirectory(PathDir);
                        }
                        //Guardamos el archivo 
                        SubeImagen.PostedFile.SaveAs(PathDir + FileName);
                        string urlfoto = "/Imagenes/TipoEventos/" + FileName;
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
        } //btnSubeImagen

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string ApPaterno = txtApPaterno.Text;
                string ApMaterno = txtApMaterno.Text;
                string Telefono = txtTelefono.Text;
                string Correo = txtCorreo.Text;
                string urlfoto = UrlFoto.InnerText;
                string Resultado =
                BLLClientes.InsCliente(Nombre, ApPaterno, ApMaterno, Telefono, Correo, urlfoto);

                if (Resultado.IndexOf("Cliente agregado") > -1)
                {
                    Util.Library.UtilControls.SweetBoxConfirm("OK!", Resultado, "success", "ListaClientes.aspx", this.Page, this.GetType());
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
        }
    }
}