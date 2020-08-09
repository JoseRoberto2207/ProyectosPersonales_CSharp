using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using Proyecto3Capas.BLL;
using Proyecto3Capas.VO;

namespace Proyecto3Capas.Catalogos.Clientes
{
    public partial class EdicionCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Primera carga de la página
            {
                //Obtenemos la información del Camión seleccionado
                string Id = Request.QueryString["Id"];
                if ((Id == null) || (!IsNumeric(Id)))
                {
                    Response.Redirect("ListaClientes.aspx");
                }
                else
                {
                    //Verificamos que el camion exista
                    ClientesVO Cliente = BLLClientes.GetClienteById(int.Parse(Id));
                    if (Cliente.IdCliente == int.Parse(Id))
                    {
                        //Desplegamos la información del camion
                        lblIdCliente.Text = Cliente.IdCliente.ToString();

                        txtNombre.Text = Cliente.Nombre;
                        txtApPaterno.Text = Cliente.ApPaterno;
                        txtApMaterno.Text = Cliente.ApMaterno;
                        txtTelefono.Text = Cliente.Telefono;
                        txtCorreo.Text = Cliente.Correo;
                        UrlFoto.InnerText = Cliente.UrlFoto;
                        chkDisponibilidad.Checked = Cliente.Disponibilidad;
                    }
                    else
                    {
                        Response.Redirect("ListaClientes.aspx");
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
                            Server.MapPath("~/Imagenes/Clientes/");
                        if (!Directory.Exists(PathDir))
                        {
                            //Creamos el directorio
                            Directory.CreateDirectory(PathDir);
                        }
                        //Guardamos el archivo 
                        SubeImagen.PostedFile.SaveAs(PathDir + FileName);
                        string urlfoto = "/Imagenes/Clientes/" + FileName;
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
                int IdCliente = int.Parse(lblIdCliente.Text);
                string Nombre = txtNombre.Text;
                string ApPaterno = txtApPaterno.Text;
                string ApMaterno = txtApMaterno.Text;
                string Telefono = txtTelefono.Text;
                string Correo = txtCorreo.Text;
                string urlfoto = UrlFoto.InnerText;
                bool Disponibilidad = chkDisponibilidad.Checked;

                string Resultado =
                    BLLClientes.UpdCliente(IdCliente, Nombre, ApPaterno, ApMaterno, Telefono, Correo, urlfoto, Disponibilidad);
                if (Resultado.IndexOf("Cliente actualizado correctamente") > -1)
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
        } // del btnGuardar_Click


    }
}