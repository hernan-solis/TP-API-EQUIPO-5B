using Business;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using TP_API_EQUIPO_5B.Models;

namespace TP_API_EQUIPO_5B.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public IEnumerable<Articulo> Get()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            return negocio.listar();
        }

        // GET: api/Articulo/5
        public Articulo Get(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista = negocio.listar();
            return lista.Find(x => x.Id == id);
        }

        // POST: api/Articulo
        public HttpResponseMessage Post([FromBody] ArticuloDto articulo)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                MarcaNegocio negocioMarca = new MarcaNegocio();
                CategoriaNegocio negocioCategoria = new CategoriaNegocio();

                Marca marca = negocioMarca.listar().Find(x => x.Id == articulo.IdMarca);
                Categoria cateogiria = negocioCategoria.listar().Find(x => x.Id == articulo.IdCategoria);

                if (marca == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca no existe.");

                if (cateogiria == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La cateogria no existe.");


                Articulo nuevo = new Articulo();
                nuevo.Codigo = articulo.Codigo;
                nuevo.Nombre = articulo.Nombre;
                nuevo.Descripcion = articulo.Descripcion;
                nuevo.Marca = new Marca { Id = articulo.IdMarca };
                nuevo.Categoria = new Categoria { Id = articulo.IdCategoria };
                nuevo.Precio = articulo.Precio;
                nuevo.Imagenes = new List<Imagen>();


                negocio.agregar(nuevo);

                return Request.CreateResponse(HttpStatusCode.OK, "Articulo agregado correctamente.");
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }
            
        }

        // PUT: api/Articulo/5
        public HttpResponseMessage Put(int id, [FromBody]ArticuloDto articulo)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = negocio.listar();

                Articulo articuloExistente = listaArticulos.Find(x => x.Id == id);

                if (articuloExistente == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El articulo no existe.");

 


                Articulo nuevo = new Articulo();
                nuevo.Codigo = articulo.Codigo;
                nuevo.Nombre = articulo.Nombre;
                nuevo.Descripcion = articulo.Descripcion;
                nuevo.Marca = new Marca { Id = articulo.IdMarca };
                nuevo.Categoria = new Categoria { Id = articulo.IdCategoria };
                nuevo.Precio = articulo.Precio;
                nuevo.Imagenes = new List<Imagen>();
                nuevo.Id = id;

                negocio.modificar(nuevo);
                return Request.CreateResponse(HttpStatusCode.OK, "Articulo modificado correctamente.");

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");

            }


        }

        // DELETE: api/Articulo/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                List<Articulo> listaArticulos = negocio.listar();
                Articulo articuloExistente = listaArticulos.Find(x => x.Id == id);


                if (articuloExistente == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El articulo no existe.");

                negocio.eliminar(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Articulo eliminado correctamente.");

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }

        }
    }
}
