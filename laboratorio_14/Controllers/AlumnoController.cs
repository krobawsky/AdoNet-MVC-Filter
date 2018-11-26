using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laboratorio_14.Models;
using laboratorio_14.Repository;

namespace laboratorio_14.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            AlumnoRepository ar = new AlumnoRepository();
            ModelState.Clear();

            return View(ar.GetAllAlumnos());
        }

        public ActionResult AddAlumno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAlumno(AlumnoModel al)
        {
            try
            {
                AlumnoRepository ar = new AlumnoRepository();
                if (ar.AddAlumno(al))
                {
                    ViewBag.message = "Almacenado correctamente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult EditAlumno(string id)
        {
            AlumnoRepository ar = new AlumnoRepository();
            return View(ar.GetAllAlumnos().Find(Prod => Prod.codalu == id));
        }

        [HttpPost]
        public ActionResult EditAlumno(AlumnoModel al)
        {
            try
            {
                AlumnoRepository ar = new AlumnoRepository();
                ar.UpdateAlumno(al);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteAlumno(string id)
        {
            try
            {
                AlumnoRepository ar = new AlumnoRepository();
                if (ar.DeleteAlumno(id))
                {
                    ViewBag.message = "Eliminado correctamente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}