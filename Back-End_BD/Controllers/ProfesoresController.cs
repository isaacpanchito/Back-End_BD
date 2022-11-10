using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        public ActionResult Index()
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                //select * from alumnos;
                return View(dbProfesores.Profesores.ToList());
            }
        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbProfesoress = new AlumnoDbContext())
            {
                Profesores profe = dbProfesoress.Profesores.Find(id);
                if (profe == null)
                {
                    return HttpNotFound();
                }
                return View(profe);


            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Profesores profe)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                dbProfesores.Profesores.Add(profe);
                dbProfesores.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {

                return View(dbProfesores.Profesores.Where(x => x.Matricula == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Edit(Profesores profe)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {

                dbProfesores.Entry(profe).State = EntityState.Modified;
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {

                return View(dbProfesores.Profesores.Where(x => x.Matricula == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(Profesores profe, int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                Profesores prof = dbProfesores.Profesores.Where(x => x.Matricula == id).FirstOrDefault();
                dbProfesores.Profesores.Remove(prof);
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}