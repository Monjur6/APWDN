using StudentPortal.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        public ActionResult Index()
        {
            var db = new portalEntities();
            var student = db.Students.ToList();

            return View(student);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student st)
        {
            var db = new portalEntities();
            db.Students.Add(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new portalEntities();
            var ext = (from st in db.Students where st.Id == Id select st).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var db = new portalEntities();
            var ext = (from st in db.Students where st.Id == s.Id select st).SingleOrDefault();
            ext.Name = s.Name;
            ext.Cgpa = s.Cgpa;
            db.SaveChanges();

            return RedirectToAction("Intex");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var db = new portalEntities();
            var ext = (from st in db.Students where st.Id == Id select st).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var db = new portalEntities();
            var ext = (from st in db.Students where st.Id == s.Id select st).SingleOrDefault();
            db.Students.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}