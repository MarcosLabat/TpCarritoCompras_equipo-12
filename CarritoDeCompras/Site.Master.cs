﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoDeCompras
{
    public partial class SiteMaster : MasterPage
    {
        public List<Marca> listaMarca { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        public CarritoNegocio Carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Carrito = Session["Carrito"] as CarritoNegocio;
            if (Carrito == null)
            {
                Carrito = new CarritoNegocio();
                Session["Carrito"] = Carrito;
            }

            if (!IsPostBack){
                MarcaNegocio marca = new MarcaNegocio();
                CategoriaNegocio categoria = new CategoriaNegocio();
                listaMarca = marca.listar();
                listaCategoria = categoria.listar();
                repMarcas.DataSource = listaMarca;
                repCategorias.DataSource = listaCategoria;
                repMarcas.DataBind();
                repCategorias.DataBind();
                MostrarCarritoEnModal(Carrito);
            }
        }

        protected void MostrarCarritoEnModal(CarritoNegocio carrito)
        {
            lblCantidad.Text = carrito.ObtenerArticulos().Count().ToString();
            if (carrito.ObtenerArticulos().Count() > 0)
            {
                rptModal.DataSource = carrito.ObtenerArticulos();
                rptModal.DataBind();
            }
            /*StringBuilder sb = new StringBuilder();

            if (carrito.ObtenerArticulos().Count() > 0)
            {
                sb.Append("<table class=\"table\">");
                sb.Append("<thead class=\"thead-dark\">");
                sb.Append("<tr>");
                sb.Append("<th>Nombre</th>");
                sb.Append("<th>Precio</th>");
                sb.Append("<th></th>");
                sb.Append("</tr>");
                sb.Append("</thead>");
                sb.Append("<tbody>");

                foreach (var item in carrito.ObtenerArticulos())
                {
                    sb.Append("<tr id=\"filaArticulo_" + item.Id + "\">");
                    sb.Append("<td class=\"align-middle\">" + item.Nombre + "</td>");
                    sb.Append("<td class=\"align-middle\">" + item.Precio.ToString("C") + "</td>");
                    sb.Append("<td><button class=\"btn btn-danger\" onclick=\"EliminarArticulo(" + item.Id + ")\">Eliminar</button></td>");
                    sb.Append("</tr>");
                }

                sb.Append("</tbody>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<p>No hay items en el carrito.</p>");
            }

            pnlCarrito.Controls.Add(new LiteralControl(sb.ToString()));*/
        }

        public void ActualizarContenidoCarrito()
        {
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;
            MostrarCarritoEnModal(carrito);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;
            int idArticulo = int.Parse(btnAgregar.CommandArgument);
            Carrito.QuitarArticulo(idArticulo);
            Session["Carrito"] = Carrito;
            ActualizarContenidoCarrito();
        }
    }
}