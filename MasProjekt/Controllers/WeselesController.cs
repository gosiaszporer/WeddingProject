using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasProjekt;

namespace MasProjekt.Controllers
{
    public class WeselesController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Weseles
        public ActionResult Index()
        {
            return View(db.Weseles.ToList());
        }

        // GET: Weseles/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wesele wesele = db.Weseles.Find(id);
            if (wesele == null)
            {
                return HttpNotFound();
            }
            return View(wesele);
        }

        // GET: Weseles/Create
        public ActionResult Create()
        {
            ViewBag.Lokalizacja_Lokalizacja_ID = new SelectList(db.Lokalizacjas, "Lokalizacja_ID", "Nazwa");
            ViewBag.Konsultant_Osoba_Osoba_ID = new SelectList(db.Konsultants, "Osoba_ID", "Nazwisko");
            ViewBag.Szablon_uroczystości_Szablon_uroczystości_ID = new SelectList(db.Szablon_uroczystości, "Szablon_uroczystości_ID", "Nazwa");

            return View();
        }

        // POST: Weseles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Wesele_ID,Nazwa,Ilosc_gosci,Data_wesela,Konsultant_Osoba_Osoba_ID,Szablon_uroczystości_Szablon_uroczystości_ID,Lokalizacja_Lokalizacja_ID")] Wesele wesele)
        {
            if (ModelState.IsValid)
            {
                db.Weseles.Add(wesele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wesele);
        }

        // GET: Weseles/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wesele wesele = db.Weseles.Find(id);
            if (wesele == null)
            {
                return HttpNotFound();
            }
            return View(wesele);
        }

        // POST: Weseles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Wesele_ID,Nazwa,Ilosc_gosci,Data_wesela,Konsultant_Osoba_Osoba_ID,Szablon_uroczystości_Szablon_uroczystości_ID,Lokalizacja_Lokalizacja_ID")] Wesele wesele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wesele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wesele);
        }

        // GET: Weseles/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wesele wesele = db.Weseles.Find(id);
            if (wesele == null)
            {
                return HttpNotFound();
            }
            return View(wesele);
        }

        // POST: Weseles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Wesele wesele = db.Weseles.Find(id);
            db.Weseles.Remove(wesele);
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
