using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class Pet_TypeController : Controller
    {
        private UniversityEntities db = new UniversityEntities();

        // GET: Pet_Type
        public ActionResult Index()
        {
            return View(db.Pet_Types.ToList());
        }

        // GET: Pet_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Type pet_Type = db.Pet_Types.Find(id);
            if (pet_Type == null)
            {
                return HttpNotFound();
            }
            return View(pet_Type);
        }

        // GET: Pet_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet_Type/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pet_Type,Descript")] Pet_Type pet_Type)
        {
            if (ModelState.IsValid)
            {
                db.Pet_Types.Add(pet_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pet_Type);
        }

        // GET: Pet_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Type pet_Type = db.Pet_Types.Find(id);
            if (pet_Type == null)
            {
                return HttpNotFound();
            }
            return View(pet_Type);
        }

        // POST: Pet_Type/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pet_Type,Descript")] Pet_Type pet_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet_Type);
        }

        // GET: Pet_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Type pet_Type = db.Pet_Types.Find(id);
            if (pet_Type == null)
            {
                return HttpNotFound();
            }
            return View(pet_Type);
        }

        // POST: Pet_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet_Type pet_Type = db.Pet_Types.Find(id);
            db.Pet_Types.Remove(pet_Type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
