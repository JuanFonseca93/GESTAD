
using Core.Dominio;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GESTAD.Controllers
{
    public class UsuariosController : Controller
    {
        Usuario Uppd;
        UnitOfWork unitOfWork;
        BDContext _context;
        // GET: Usuarios
        public ActionResult Usuarios(List<Usuario> obj, int? pagina)
        {
            _context = new BDContext();
            unitOfWork = new UnitOfWork(_context);
            List<Usuario> usuario = new List<Usuario>();
            if (obj == null)
            {
                foreach (var nusuario in unitOfWork.Usuarios.GetAll())
                {
                    usuario.Add(nusuario);
                }
            }
            else
            {
                usuario = TempData["usuario"] as List<Usuario>;
            }
            int tamanoPagina = 5;
            int numeroPagina = (pagina ?? 1);
            
            return View(usuario.ToPagedList(numeroPagina, tamanoPagina));

        }

        [HttpPost]
        public ActionResult BuscarUsuario(string nombre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context = new BDContext();


                    var busqueda = from nombreUsu in _context.Usuarios select nombreUsu;

                    if (nombre != null || !nombre.Equals(""))
                    {

                        busqueda = from nombreUsu in _context.Usuarios where nombreUsu.nombreUsuario.Contains(nombre) select nombreUsu;
                    }
                    List<Usuario> usu = new List<Usuario>();

                    foreach (var item in busqueda)
                    {
                        usu.Add(item);
                    }

                    TempData["usuario"] = usu;

                    return RedirectToAction("Usuario", new { obj = usu });

                }
                else
                {
                    return RedirectToAction("Usuario");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Un error ha ocurrido '{0}'", ex);
                return View("Usuario");
            }
        }

        [HttpGet]
        public ActionResult CrearUsuario(Usuario obj)
        {
            _context = new BDContext();
            unitOfWork = new UnitOfWork(_context);
            List<Area> Areas = new List<Area>();
            foreach (var nusuario in unitOfWork.Area.GetAll())
            {
                Areas.Add(nusuario);
            }
            ViewBag.Areas = Areas;
            return View(obj);
        }

        [HttpPost]
        public ActionResult ActionCrearUsuario(Usuario obj)
        {

            if (ModelState.IsValid)
            {
                _context = new BDContext();
                unitOfWork = new UnitOfWork(_context);
                unitOfWork.Usuarios.Add(obj);
                unitOfWork.Complete();
                return RedirectToAction("Usuarios");
            }
            else
            {
                return RedirectToAction("CrearUsuario",obj);
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(int idUsuario)
        {
            _context = new BDContext();
            unitOfWork = new UnitOfWork(_context);
            List<Area> Areas = new List<Area>();
            foreach (var nusuario in unitOfWork.Area.GetAll())
            {
                Areas.Add(nusuario);
            }
            ViewBag.Areas = Areas;
            Uppd = unitOfWork.Usuarios.Get(idUsuario);
            return View(Uppd);
        }

        [HttpPost]
        public ActionResult ActionActualizarUsuario(Usuario obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context = new BDContext();
                    unitOfWork = new UnitOfWork(_context);
                    Uppd = unitOfWork.Usuarios.Get(obj.idUsuario);
                    unitOfWork.Usuarios.Update(Uppd);
                    Uppd.nombreUsuario = obj.nombreUsuario;
                    Uppd.curpUsuario = obj.curpUsuario;
                    Uppd.correoUsuario = obj.correoUsuario;
                    Uppd.passwordUsuario = obj.passwordUsuario;
                    Uppd.fechaNacimientoUsuario = obj.fechaNacimientoUsuario;
                    Uppd.generoUsuario = obj.generoUsuario;
                    Uppd.institucionUsuario = obj.institucionUsuario;
                    Uppd.telefonoUsuario = obj.telefonoUsuario;
                    Uppd.idArea = obj.idArea;

                    _context.Configuration.ValidateOnSaveEnabled = false;

                    unitOfWork.Complete();

                    return RedirectToAction("Usuario");
                }
                else
                {
                    return View("ActualizarUsuario", obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Un error ha ocurrido '{0}'", ex);
                return View("ActualizarUsuario");
            }

        }
    }
}