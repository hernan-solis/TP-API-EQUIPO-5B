﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Models;



namespace TP_API_EQUIPO_5B.Controllers
{
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public IEnumerable<Categoria> Get()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            return negocio.listar();
        }

        // GET: api/Categoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
        }
    }
}
