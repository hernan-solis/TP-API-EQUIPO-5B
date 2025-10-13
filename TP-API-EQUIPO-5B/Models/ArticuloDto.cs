﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_API_EQUIPO_5B.Models
{
    public class ArticuloDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public float Precio { get; set; }
        public List<Imagen> Imagenes { get; set; }
    }
}