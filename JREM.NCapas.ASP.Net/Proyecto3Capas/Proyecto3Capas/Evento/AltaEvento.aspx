<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaEvento.aspx.cs" Inherits="Proyecto3Capas.Evento.AltaEvento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="//maps.googleapis.com/maps/api/js?key=AIzaSyCWeeateTaYGqsHhNcmoDfT7Us-vLDZVPs&amp;sensor=false&amp;language=en"></script>
    <style>
        .modalPanel{
            background-color:#fff;
        }
        .bgpanel{
            background-color:#0d0d0d;
            filter:alpha(opacity=70);
            opacity:0.70;
        }
    </style>
    
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <br /><br /><br />
                <br /><br /><br />
                <br /><br /><br />
                <h3>INICIAR EVENTO</h3>
                 <br /><br />
            </div>
            <%--<div style="display:block;">
                <asp:TextBox ID="txtEsOD" runat="server"></asp:TextBox>
            </div>--%>
        </div>
        <div class="row">
            <!--IZQUIERDA-->
            <div class="col-md-6">
                <%--<div class="form-group">
                    <label for="<%=DDLTipoEvento.ClientID%>">Tipo Evento</label>
                    <asp:DropDownList ID="DDLTipoEvento" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>--%>

                 <div class="form-group">
                    <label for="<%=DDLTipoEvento.ClientID%>">Tipo de Evento</label>
                    <asp:DropDownList ID="DDLTipoEvento" CssClass="form-control" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="DDLTipoEvento_SelectedIndexChanged"></asp:DropDownList>
                     <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="DDLTipoEvento" CssClass="text-danger" runat="server" ErrorMessage="Tipo Evento requerido"></asp:RequiredFieldValidator>
                    </div>
                </div>

               <div class="form-group">
                    <label for="<%=DDLComidas.ClientID%>">Tipo Comidas</label>
                    <asp:DropDownList ID="DDLComidas" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVComidas" ControlToValidate="DDLComidas" CssClass="text-danger" runat="server" ErrorMessage="Selecciona el tipo de comida"></asp:RequiredFieldValidator>
                </div>

            </div>
            <!--DERECHA-->
            <div class="col-md-6">
                <div class="form-group">
                    <label for="<%=DDLCliente.ClientID%>">Cliente</label>
                    <asp:DropDownList ID="DDLCliente" CssClass="form-control" runat="server"></asp:DropDownList>
                    <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DDLCliente" CssClass="text-danger" runat="server" ErrorMessage="Cliente requerido"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class="form-group">
                    <label for="<%=FEvento.ClientID%>">Fecha de Evento</label>
                    <input type="text" id="FEvento" name="FEvento" class="form-control" runat="server" />
                     <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FEvento" CssClass="text-danger" runat="server" ErrorMessage="Fecha requerida"></asp:RequiredFieldValidator>
                    </div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h4>Servicios</h4>
            </div>
        </div>
        <div class="row" id="FormaCarga" style="display:none">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtKaraoke.ClientID%>">Karaoke</label>
                    <asp:TextBox ID="txtKaraoke" CssClass="form-control" runat="server"></asp:TextBox>
                    <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtKaraoke" CssClass="text-danger" runat="server" ErrorMessage="Precio de Karaoke requerido ($0)"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtLicores.ClientID%>">Licores</label>
                    <asp:TextBox ID="txtLicores" CssClass="form-control" runat="server"></asp:TextBox>
                    <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtLicores" CssClass="text-danger" runat="server" ErrorMessage="Precio de Licores requerido ($0)"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtValetParking.ClientID%>">Valet Parking</label>
                    <asp:TextBox ID="txtValetParking" CssClass="form-control" runat="server"></asp:TextBox>
                    <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtValetParking" CssClass="text-danger" runat="server" ErrorMessage="Precio de Valet Parking requerido ($0)"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtDj.ClientID%>">Dj´s</label>
                    <asp:TextBox ID="txtDj" CssClass="form-control" runat="server"></asp:TextBox>
                    <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtDj" CssClass="text-danger" runat="server" ErrorMessage="Precio de Dj´s requerido ($0)"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtPayaso.ClientID%>">Payaso</label>
                    <asp:TextBox ID="txtPayaso" CssClass="form-control" runat="server"></asp:TextBox>
                    <div style="top:0;left:0">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtPayaso" CssClass="text-danger" runat="server" ErrorMessage="Precio de Payaso requerido ($0)"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <%--<asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Agregar Carga" Style="margin-top:25px;" OnClick="btnAddCarga_Click"  />--%>
                </div>
            </div>
        </div>
        <hr />
        <br />
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:GridView ID="GVCarga"
                    CssClass="table table-striped"
                    runat="server"></asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group pull-right">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Iniciar Evento" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
        <br /><br /><br /><br />
    </div>
    <script>
        $(document).ready(function () {
            //Declarar al time picker en español con momentjs
            $.datetimepicker.setLocale('es');
            //Asignamos el calendario a los input de fecha
            $("#<%=FEvento.ClientID%>").
                datetimepicker({
                    format: 'd/m/Y H:i',
                    minDate:'0'
                });
            $("#<%=FEvento.ClientID%>").
                datetimepicker({
                    format: 'd/m/Y H:i',
                    minDate: '0'
                });

            $("#<%=FEvento.ClientID%>").change(function () {
                CalcularDistancia();
            });

            if ($("#<%=DDLTipoEvento.ClientID%>").val() != "")
            {
                $("#FormaCarga").show();
            }
            else {
                $("#FormaCarga").hide();
            }

        });
    </script>

</asp:Content>


