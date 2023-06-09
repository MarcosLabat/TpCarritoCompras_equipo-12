﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filtro.aspx.cs" Inherits="CarritoDeCompras.Filtro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" CssClass="h3 d-flex justify-content-center text-white mb-3 text-center" runat="server" Text=""></asp:Label>
      <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
          <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card mw-100">
                            <div class="card-body">
                                <%# cargarImagen(((Dominio.Articulo)Container.DataItem)?.Imagen?.LastOrDefault()?.ToString()) %>
                                <asp:Image CssClass="card-img-top" ID="imgArticulo" runat="server" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'"/>
                                <h4 class="card-title"><%# ((Dominio.Articulo)Container.DataItem).Nombre %></h4>
                                <p class="card-text"><%# ((Dominio.Articulo)Container.DataItem).Descripcion %></p>
                                <p class="card-text fw-semibold text-success"><%# ((Dominio.Articulo)Container.DataItem).Precio + "$" %></p>
                                <a href="Detalle.aspx?id=<%# ((Dominio.Articulo)Container.DataItem).Id %>" class="btn btn-primary w-100 mb-1">Ver más</a>
                                <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" OnClick="btnAgregar_Click" CommandArgument='<%# ((Dominio.Articulo)Container.DataItem).Id.ToString() %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
      </div>
</asp:Content>
