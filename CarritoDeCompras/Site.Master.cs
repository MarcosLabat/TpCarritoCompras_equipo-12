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
            if (!IsPostBack){
                MarcaNegocio marca = new MarcaNegocio();
                CategoriaNegocio categoria = new CategoriaNegocio();
                listaMarca = marca.listar();
                listaCategoria = categoria.listar();
                repMarcas.DataSource = listaMarca;
                repCategorias.DataSource = listaCategoria;
                repMarcas.DataBind();
                repCategorias.DataBind();


            }
            Carrito = Session["Carrito"] as CarritoNegocio;
            if (Carrito == null)
            {
                Carrito = new CarritoNegocio();
                Session["Carrito"] = Carrito;
            }
            MostrarCarritoEnModal(Carrito);
        }

        private void MostrarCarritoEnModal(CarritoNegocio carrito)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in carrito.ObtenerArticulos())
            {
                // Construir el HTML para mostrar cada elemento del carrito
                sb.Append("<div>");
                sb.Append(item);
                sb.Append("</div>");
            }

            // Asignar el HTML construido al cuerpo del modal
            pnlCarrito.Controls.Add(new LiteralControl(sb.ToString()));

        }
    }
}