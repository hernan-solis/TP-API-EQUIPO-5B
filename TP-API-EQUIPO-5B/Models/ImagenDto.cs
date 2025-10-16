using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_API_EQUIPO_5B.Models
{
    public class ImagenDto
    {
        public int IdArticulo { get; set; }
        public List<string> Imagenes { get; set; }
    }
}