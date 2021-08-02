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
    public class PetsController : Controller
    {
        private UniversityEntities db = new UniversityEntities();

        // GET: Pets
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.Owner).Include(p => p.Pet_Type);
            return View(pets.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.Id_Owners = new SelectList(db.Owners, "Id_Owners", "Names");
            ViewBag.Id_Pet_Type = new SelectList(db.Pet_Types, "Id_Pet_Type", "Descript");
            return View();
        }

        // POST: Pets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pets,Pet_Name,Birth_Date,Id_Pet_Type,Id_Owners")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Owners = new SelectList(db.Owners, "Id_Owners", "Names", pet.Id_Owners);
            ViewBag.Id_Pet_Type = new SelectList(db.Pet_Types, "Id_Pet_Type", "Descript", pet.Id_Pet_Type);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Owners = new SelectList(db.Owners, "Id_Owners", "Names", pet.Id_Owners);
            ViewBag.Id_Pet_Type = new SelectList(db.Pet_Types, "Id_Pet_Type", "Descript", pet.Id_Pet_Type);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pets,Pet_Name,Birth_Date,Id_Pet_Type,Id_Owners")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Owners = new SelectList(db.Owners, "Id_Owners", "Names", pet.Id_Owners);
            ViewBag.Id_Pet_Type = new SelectList(db.Pet_Types, "Id_Pet_Type", "Descript", pet.Id_Pet_Type);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
