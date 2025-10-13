using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Models;
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
        public void Post([FromBody]ArticuloDto articulo)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo nuevo = new Articulo();
            nuevo.Codigo = articulo.Codigo;
            nuevo.Nombre = articulo.Nombre;
            nuevo.Descripcion = articulo.Descripcion;
            nuevo.Marca = new Marca { Id= articulo.IdMarca};
            nuevo.Categoria = new Categoria { Id= articulo.IdCategoria};

            //tengo dudas con esto, a chequear
            nuevo.Imagenes = new List<Imagen>();


            negocio.agregar(nuevo);
        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
