using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESTAD.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string nombreUsuario { get; set; }

        public int nivelUsuario { get; set; }

        [EmailAddress]
        public string correoUsuario { get; set; }

        public string passwordUsuario { get; set; }

        public string generoUsuario { get; set; }

        public string curpUsuario { get; set; }

        public DateTime fechaNacimientoUsuario { get; set; }

        public string institucionUsuario { get; set; }

        public string telefonoUsuario { get; set; }

        public Area area { get; set; }
    }
}