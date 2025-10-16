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
    public class ImagenDtoController : ApiController
    {
        // GET: api/ImagenDto
        public IEnumerable<Imagen> Get()
        {
            ImagenNegocio negocio = new ImagenNegocio();

            return negocio.listar();
        }

        // GET: api/ImagenDto/5
        public List<Imagen> Get(int id)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            return negocio.listarPorIdArticulo(id);
        }

        // POST: api/ImagenDto
        public void Post([FromBody]ImagenDto imagenDto)
        {
            ImagenNegocio negocio = new ImagenNegocio();

            foreach (string url in imagenDto.Imagenes) {

                Imagen nuevaImagen = new Imagen();

                nuevaImagen.IdArticulo = imagenDto.IdArticulo;
                nuevaImagen.Url = url;

                negocio.agregar(nuevaImagen);
            }
        }

        // PUT: api/ImagenDto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ImagenDto/5
        public void Delete(int id)
        {
        }
    }
}
