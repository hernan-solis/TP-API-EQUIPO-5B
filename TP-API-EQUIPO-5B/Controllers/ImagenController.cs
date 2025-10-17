using Business;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP_API_EQUIPO_5B.Models;

namespace TP_API_EQUIPO_5B.Controllers
{
    public class ImagenController : ApiController
    {
        // GET: api/Imagen
        public IEnumerable<Imagen> Get()
        {
            ImagenNegocio negocio = new ImagenNegocio();

            return negocio.listar();
        }

        // GET: api/Imagen/5
        public List<Imagen> Get(int id)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            return negocio.listarPorIdArticulo(id);
        }

        // POST: api/Imagen
        public HttpResponseMessage Post([FromBody] ImagenDto imagenDto)
        {
            ImagenNegocio negocio = new ImagenNegocio();

            if (imagenDto == null) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "imagenDto Null o erroneo");
            }

            if (imagenDto.Imagenes == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lista Url Null");
            }

            if (negocio.listarPorIdArticulo(imagenDto.IdArticulo).Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id Erroneo o No encontrado");
            }


            try
            {
                foreach (string url in imagenDto.Imagenes)
                {

                    Imagen nuevaImagen = new Imagen();

                    nuevaImagen.IdArticulo = imagenDto.IdArticulo;
                    nuevaImagen.Url = url;

                    negocio.agregar(nuevaImagen);
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Imagenes Agregadas Correctamente.");
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }

        }

        // PUT: api/Imagen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Imagen/5
        public void Delete(int id)
        {
        }
    }
}
