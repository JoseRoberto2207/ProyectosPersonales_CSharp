<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaTipoEventos.aspx.cs" Inherits="Proyecto3Capas.Catalogos.TipoEventos.ListaTipoEventos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div class="container">
       <div class="row">
            <div class="col-md-12">
                <br /><br /><br />
                <br /><br /><br />
                <h3>Lista Tipo de Eventos</h3>
            </div>
        </div>
       <div class="row">
           <div class="col-md-12">
               <asp:GridView ID="GVTipoEventos"
                    CssClass="table table-bordered table-striped"
                    AutoGenerateColumns="false"
                    OnRowEditing="GVTipoEventos_RowEditing"
                    OnRowCancelingEdit="GVTipoEventos_RowCancelingEdit"
                    OnRowUpdating="GVTipoEventos_RowUpdating"
                    OnRowDeleting="GVTipoEventos_RowDeleting"
                    OnRowCommand="GVTipoEventos_RowCommand"
                    DataKeyNames="IdTipoEvento"
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
                            DataField="IdTipoEvento"
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
                         
                       <%--<asp:TemplateField HeaderText="Tipo Evento"
                              ControlStyle-Width="150px" >
                             <ItemTemplate>
                                 <asp:Label ID="lblTipoCamion" Text='<%#Eval("TipoEvento")%>' runat="server"></asp:Label>
                             </ItemTemplate>
                             <EditItemTemplate>
                                 <asp:DropDownList ID="DDLTipoCamion" CssClass="form-control" runat="server"></asp:DropDownList>
                             </EditItemTemplate>
                         </asp:TemplateField>--%>
                       <asp:BoundField
                            HeaderText="Precio"
                            DataField="Precio" />
                        <asp:BoundField
                            HeaderText="Descripcion"
                            DataField="Descripcion" />
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
                       <asp:BoundField
                            HeaderText="Clave"
                            DataField="Clave" />
                   </Columns>
               </asp:GridView>
           </div>
       </div>
   </div>
</asp:Content>
