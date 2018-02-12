using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Dominio
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

        public int idUsuario { get; set; }

        public virtual Usuario usuario { get; set; }

        public virtual ICollection<Colaboracion> colaboraciones { get; set; }
    }
}