<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="Proyecto3Capas.Catalogos.Clientes.ListaClientes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div class="container">
       <div class="row">
            <div class="col-md-12">
                <br /><br /><br />
                <br /><br /><br />
                <h3>Lista Clientes</h3>
            </div>
        </div>
       <div class="row">
           <div class="col-md-12">
               <asp:GridView ID="GVClientes"
                    CssClass="table table-bordered table-striped"
                    AutoGenerateColumns="false"
                    OnRowEditing="GVClientes_RowEditing"
                    OnRowCancelingEdit="GVClientes_RowCancelingEdit"
                    OnRowUpdating="GVClientes_RowUpdating"
                    OnRowDeleting="GVClientes_RowDeleting"
                    OnRowCommand="GVClientes_RowCommand"
                    DataKeyNames="IdCliente"
                   runat="server">
                   <Columns>
                       <asp:ButtonField 
                            Text="Seleccionar"
                            CommandName="Select"
                            ButtonType ="Button"
                            ControlStyle-CssClass="btn btn-success btn-xs" />
                       <asp:CommandField
                            ShowEditButton="true"
                            ControlStyle-CssClass="btn btn-default btn-xs" />
                       <asp:CommandField
                            ShowDeleteButton="true"
                            ControlStyle-CssClass="btn btn-danger btn-xs" />
                       <asp:BoundField
                            HeaderText="Id"
                            DataField="IdCliente"
                            ReadOnly="true"
                           />
                       <asp:ImageField
                            HeaderText="Foto"
                            ReadOnly="true"
                            ItemStyle-Width="160px"
                            ControlStyle-Height="100px"
                            ControlStyle-Width="150px"
                            DataImageUrlField="UrlFoto">
                       </asp:ImageField>

                       <asp:BoundField
                            HeaderText="Nombre"
                            DataField="Nombre" />
                       <asp:BoundField
                            HeaderText="ApPaterno"
                            DataField="ApPaterno" />
                       <asp:BoundField
                            HeaderText="ApMaterno"
                            DataField="ApMaterno" />
                       <asp:BoundField
                            HeaderText="Telefono"
                            DataField="Telefono" />
                       <asp:BoundField
                            HeaderText="Correo"
                            DataField="Correo" />
                       
                        <asp:TemplateField
                         HeaderText="Disponible"
                         ItemStyle-Width="50px"
                         >
                        <ItemTemplate>
                            <div style="width:100%">
                                <div style="width:25%;margin:0 auto;">
                                    <asp:CheckBox ID="ChkDisponible" runat="server"
                                         Checked='<%#Eval("Disponibilidad")%>'
                                         Enabled="false"
                                         />
                                </div>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="width:100%">
                                <div style="width:25%;margin:0 auto;">
                                    <asp:CheckBox ID="ChkEditDisponible" runat="server"
                                         Checked='<%#Eval("Disponibilidad")%>'
                                         />
                                </div>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                   </Columns>
               </asp:GridView>
           </div>
       </div>
   </div>
</asp:Content>
