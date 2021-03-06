﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="Proyecto3Capas.Catalogos.Clientes.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <div class="container">
        <div class="row">
            <div class="col-md-12">
                <br /><br /><br />
                <br /><br /><br />
                <h3>Alta Cliente</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
               
                <div class="form-group">
                    <label for="<%=txtNombre.ClientID%>">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                      <div class="col-md-12" style="margin-bottom:30px">
                        <div style="position:absolute;top:0;left:0">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre requerido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="<%=txtApPaterno.ClientID%>">Apellido Paterno</label>
                    <asp:TextBox ID="txtApPaterno" CssClass="form-control" runat="server"></asp:TextBox>
                      <div class="col-md-12" style="margin-bottom:30px">
                        <div style="position:absolute;top:0;left:0">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtApPaterno" CssClass="text-danger" runat="server" ErrorMessage="Apellido paterno requerido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="<%=txtApMaterno.ClientID%>">Apellido Materno</label>
                    <asp:TextBox ID="txtApMaterno" CssClass="form-control" runat="server"></asp:TextBox>
                      <div class="col-md-12" style="margin-bottom:30px">
                        <div style="position:absolute;top:0;left:0">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtApMaterno" CssClass="text-danger" runat="server" ErrorMessage="Apellido materno requerido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="<%=txtTelefono.ClientID%>">Telefono</label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                      <div class="col-md-12" style="margin-bottom:30px">
                        <div style="position:absolute;top:0;left:0">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Teléfono requerido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="<%=txtCorreo.ClientID%>">Correo</label>
                    <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
                      <div class="col-md-12" style="margin-bottom:30px">
                        <div style="position:absolute;top:0;left:0">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtCorreo" CssClass="text-danger" runat="server" ErrorMessage="Correo requerido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                 <div class="form-group">
                    <label for="">Seleccionar Foto</label>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="input-group">
                                <label class="input-group-btn">
                                    <span class="btn btn-primary">
                                        Buscar <input type="file" id="SubeImagen" runat="server" class="btn btn-file" style="display:none;" />
                                    </span>
                                </label>
                                <input type="text" id="InfoImg" readonly style="background-color:transparent;border:0;margin-left:10px;" />
                            </div>
                        </div>
                         <div class="col-md-6">
                             <asp:Button ID="btnSubeImagen" runat="server" Text="Subir" CssClass="btn btn-primary btn-xs" OnClick="btnSubeImagen_Click" OnClientClick="MuestraFoto();" />
                        </div>
                    </div>
                </div>
                <div class="form-group" id="imgFoto" style="display:none;">
                    <label>Foto</label>
                    <asp:Image ID="imgFotoCamion" runat="server" Style="width:150px;"  />
                    <label id="UrlFoto" runat="server"></label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 col-md-offset-6">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            if ($("#<%=UrlFoto.ClientID%>").html() != "")
            {
                $("#imgFoto").show();
            }


            $("#<%=SubeImagen.ClientID%>").on('change', function () {
                var label = $(this)["0"].files["0"].name;
               
                $("#InfoImg").val(label);
            });
        });

    </script>
    <script>

        function MuestraFoto()
        {
            $("#imgFoto").show();
            return true;
        }
    </script>

</asp:Content>
