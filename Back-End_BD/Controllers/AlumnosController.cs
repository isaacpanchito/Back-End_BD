using Back_End_BD.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Back_End_BD.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                //select * from alumnos;
                return View(dbAlumnos.Alumno.ToList());
            }
        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Alumno alumno = dbAlumnos.Alumno.Find(id);
                if (alumno == null)
                {
                    return HttpNotFound();
                }
                    return View(alumno);
                
               
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alumno alum)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Alumno.Add(alum);
                dbAlumnos.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                
                return View(dbAlumnos.Alumno.Where(x=>x.Id==id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Edit(Alumno alum)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {

                dbAlumnos.Entry(alum).State=EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {

                return View(dbAlumnos.Alumno.Where(x => x.Id == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(Alumno alum, int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Alumno al = dbAlumnos.Alumno.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Alumno.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}