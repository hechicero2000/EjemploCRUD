using EjemploCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploCRUD.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<ListaUsuarioViewModel> lst;

            using(RegistroEntities db = new RegistroEntities())
            {
                lst = (from lista in db.Usuario
                      select new ListaUsuarioViewModel
                      {
                          Id = lista.Id,
                          Nombre = lista.Nombre,
                          Correo = lista.Correo,
                          Usuario = lista.Usuario1,
                          Contrasena = lista.Contrasena
                      }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(RegistroEntities db = new RegistroEntities())
                    {
                        var oUsuario = new Usuario();
                        oUsuario.Nombre = model.Nombre;
                        oUsuario.Correo = model.Correo;
                        oUsuario.Usuario1 = model.Usuario;
                        oUsuario.Contrasena = model.Contrasena;

                        db.Usuario.Add(oUsuario);
                        db.SaveChanges();
                    }                    
                }
                return Redirect("/Usuario");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            UsuarioViewModel model = new UsuarioViewModel();

            using(RegistroEntities db = new RegistroEntities())
            {
                var oUsuario = db.Usuario.Find(id);
                model.Nombre = oUsuario.Nombre;
                model.Correo = oUsuario.Correo;
                model.Usuario = oUsuario.Usuario1;
                model.Contrasena = oUsuario.Contrasena;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(RegistroEntities db = new RegistroEntities())
                    {
                        var oUsuario = db.Usuario.Find(model.Id);
                        oUsuario.Nombre = model.Nombre;
                        oUsuario.Correo = model.Correo;
                        oUsuario.Usuario1 = model.Usuario;
                        oUsuario.Contrasena = model.Contrasena;

                        db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("/Usuario");
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using(RegistroEntities db = new RegistroEntities())
            {
                var oUsuario = db.Usuario.Find(Id);
                db.Usuario.Remove(oUsuario);
                db.SaveChanges();
            }

            return Redirect("/Usuario");
        }
    }
}