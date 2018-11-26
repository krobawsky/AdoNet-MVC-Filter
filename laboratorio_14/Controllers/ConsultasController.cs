using laboratorio_14.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laboratorio_14.Models;

namespace laboratorio_14.Controllers
{
    public class ConsultasController : Controller
    {

        Lab14Entities db = new Lab14Entities();

        public ActionResult Conuslta1()
        {
            AlumnoRepository ar = new AlumnoRepository();
            ModelState.Clear();

            return View(ar.GetAllAlumnos());            
        }

        public ActionResult Consulta2()
        {
            ViewBag.list = new SelectList(db.Carreras, "codcar", "nomcar");
            return View();
        }

        public ActionResult Consulta3()
        {
            ViewBag.list = new SelectList(db.Carreras, "codcar", "nomcar");
            return View();
        }

        public ActionResult Consulta4()
        {
            AlumnoRepository ar = new AlumnoRepository();
            var list = ar.GetAllAlumnos();
            ViewBag.list = new SelectList(list, "codalu", "nomalu");
            return View();
        }

        public PartialViewResult ListadoAlumnoCarrera(int cod_car)
        {
            AlumnoRepository ar = new AlumnoRepository();
            var list = ar.GetAllAlumnos();
            var listado = list.Where(p => p.codcar > cod_car);
            
            List<AlumnoModel> coleccion = new List<AlumnoModel>();
            foreach (AlumnoModel alumno in listado)
            {
                AlumnoModel al = new AlumnoModel();

                al.codalu = alumno.codalu;
                al.nomalu = alumno.nomalu;
                al.email = alumno.email;
                al.telefono = alumno.telefono;
                al.codcar = alumno.codcar;
                al.fecha_ins = alumno.fecha_ins;
                al.estado = alumno.estado;
                al.Fotoalu = alumno.Fotoalu;
                coleccion.Add(al);

            }
            return PartialView("Listado", coleccion);
        }

        public PartialViewResult ListadoAlumnoCarreraAño(DateTime fecha_inicio, int cod_car)
        {
            AlumnoRepository ar = new AlumnoRepository();
            var list = ar.GetAllAlumnos();
            var listado = list.Where(p => p.codcar == cod_car && p.fecha_ins > fecha_inicio);

            List<AlumnoModel> coleccion = new List<AlumnoModel>();
            foreach (AlumnoModel alumno in listado)
            {
                AlumnoModel al = new AlumnoModel();

                al.codalu = alumno.codalu;
                al.nomalu = alumno.nomalu;
                al.email = alumno.email;
                al.telefono = alumno.telefono;
                al.codcar = alumno.codcar;
                al.fecha_ins = alumno.fecha_ins;
                al.estado = alumno.estado;
                al.Fotoalu = alumno.Fotoalu;
                coleccion.Add(al);

            }
            return PartialView("Listado", coleccion);
        }

        public PartialViewResult ListadoNotasAlumno(string cod_alu)
        {
            AlumnoRepository ar = new AlumnoRepository();
            var list = ar.GetAllAlumnos();
            var listado = db.Notas.Where(p => p.codalu == cod_alu);

            List<Notas> coleccion = new List<Notas>();
            foreach (Notas notas in listado)
            {
                Notas nt = new Notas();
                nt.codalu = notas.codalu;
                nt.codcur = notas.codcur;
                nt.semestre = notas.semestre;
                nt.codcur = notas.codcur;
                nt.pp = notas.pp;
                nt.pt = notas.pt;
                nt.ex = notas.ex;
                coleccion.Add(nt);

            }
            return PartialView("Listado2", coleccion);
        }
    }
}