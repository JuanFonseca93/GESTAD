using GESTAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GESTAD.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Usuarios(Usuario obj)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View(obj);
            }
            
        }
    }
}