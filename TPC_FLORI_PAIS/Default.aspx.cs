using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_PAIS_FLORI
{
    public partial class _Default : Page
    {
        public List<ProductoPreCargado> listaProductoPreCargado;
        public List<Producto> listaProducto;
        public List<Color> listaColores;

        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioProductoPreCargado NegocioProductoPreCargado = new NegocioProductoPreCargado();
            NegocioColores NegocioColores = new NegocioColores();
            NegocioCategorias NegocioCategorias = new NegocioCategorias();
            NegocioEstampado NegocioEstampado = new NegocioEstampado();

            try
            {
                this.listaProducto = new List<Producto>();
            //    listaProductoPreCargado = NegocioProductoPreCargado.listar();

                //foreach(ProductoPreCargado item in listaProductoPreCargado)
                //{
                //    listaProducto.Add(new Producto() {
                //        ID = item.ID,
                //        Color = NegocioColores.descripcionxid(item.IDColor),
                //        Estampado = NegocioEstampado.descripcionxid(item.IDEstampado),
                //        Categoria = " Estampado " + NegocioEstampado.descripcionxid(item.IDEstampado),
                //        ImagenColor = "../recursos/Remera/" + NegocioColores.descripcionxid(item.IDColor) + ".jpg",
                //        ImagenEstampado = "../recursos/estampado/" + NegocioEstampado.imagenxid(item.IDEstampado),
                //        Precio = NegocioCategorias.getprecioxid(item.IDCategoria) + NegocioEstampado.getprecioxid(item.IDEstampado)
                //    });
                    
                //}
                
              //  Session.Add("listadoProducto", listaProducto);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {

            NegocioProductoPreCargado NegocioProductoPreCargado = new NegocioProductoPreCargado();
            NegocioColores NegocioColores = new NegocioColores();
            NegocioCategorias NegocioCategorias = new NegocioCategorias();
            NegocioEstampado NegocioEstampado = new NegocioEstampado();

            this.listaProducto = new List<Producto>();
            listaProductoPreCargado = NegocioProductoPreCargado.listar();

            foreach (ProductoPreCargado item in listaProductoPreCargado)
            {
                listaProducto.Add(new Producto()
                {
                    ID = item.ID,
                    Color = NegocioColores.descripcionxid(item.IDColor),
                    Estampado = NegocioEstampado.descripcionxid(item.IDEstampado),
                    Categoria = " Estampado " + NegocioEstampado.descripcionxid(item.IDEstampado),
                    ImagenColor = "../recursos/Remera/" + NegocioColores.descripcionxid(item.IDColor) + ".jpg",
                    ImagenEstampado = "../recursos/estampado/" + NegocioEstampado.imagenxid(item.IDEstampado),
                    Precio = NegocioCategorias.getprecioxid(item.IDCategoria) + NegocioEstampado.getprecioxid(item.IDEstampado)
                });

            }

            listaProducto = listaProducto.FindAll(x => x.Color.ToUpper().Contains(Request["search"].ToUpper()) || x.Estampado.ToUpper().Contains(Request["search"].ToUpper()));

        }
    }
}