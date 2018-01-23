using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTAD.Models
{
    public class Colaboracion
    {
        public int idColaboracion { get; set; }

        public bool propietarioColaboracion { get; set; }


        public bool tipoColaboracion  { get; set; }

        public TipoColaboracion TipoColaboracion { get; set; }

        public Documento documento { get; set; }

        public Usuario usuario { get; set; }

    }
}