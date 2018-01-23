using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESTAD.Models
{
    public class Documento
    {
        public int idDocumento { get; set; }

        public string nombreDocumento { get; set; }

        public string rutaDocumento { get; set; }

        public string descripccionDocumento { get; set; }

        public DateTime fechaSubidaDocumento { get; set; }

        public DateTime fechaModificiacionDocumento { get; set; }

        public string tipoDocumento { get; set; }

        public string categoriaDocumento { get; set; }

        public bool estadoDocumento { get; set; }
    }
}