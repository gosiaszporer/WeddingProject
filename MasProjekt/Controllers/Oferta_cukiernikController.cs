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
    public class Oferta_cukiernikController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Oferta_cukiernik
        public ActionResult Index()
        {
            var oferta_cukiernik = db.Oferta_cukiernik.Include(o => o.Podwykonawca);
            return View(oferta_cukiernik.ToList());
        }

        // GET: Oferta_cukiernik/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_cukiernik oferta_cukiernik = db.Oferta_cukiernik.Find(id);
            if (oferta_cukiernik == null)
            {
                return HttpNotFound();
            }
            return View(oferta_cukiernik);
        }

        // GET: Oferta_cukiernik/Create
        public ActionResult Create()
        {
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa");
            return View();
        }

        // POST: Oferta_cukiernik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,Dominujace_smaki,Cena,Oferta_cukiernik_ID,Podwykonawca_Podwykonawca_ID")] Oferta_cukiernik oferta_cukiernik)
        {
            if (ModelState.IsValid)
            {
                db.Oferta_cukiernik.Add(oferta_cukiernik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_cukiernik.Podwykonawca_Podwykonawca_ID);
            return View(oferta_cukiernik);
        }

        // GET: Oferta_cukiernik/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_cukiernik oferta_cukiernik = db.Oferta_cukiernik.Find(id);
            if (oferta_cukiernik == null)
            {
                return HttpNotFound();
            }
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_cukiernik.Podwykonawca_Podwykonawca_ID);
            return View(oferta_cukiernik);
        }

        // POST: Oferta_cukiernik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwa,Dominujace_smaki,Cena,Oferta_cukiernik_ID,Podwykonawca_Podwykonawca_ID")] Oferta_cukiernik oferta_cukiernik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta_cukiernik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_cukiernik.Podwykonawca_Podwykonawca_ID);
            return View(oferta_cukiernik);
        }

        // GET: Oferta_cukiernik/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_cukiernik oferta_cukiernik = db.Oferta_cukiernik.Find(id);
            if (oferta_cukiernik == null)
            {
                return HttpNotFound();
            }
            return View(oferta_cukiernik);
        }

        // POST: Oferta_cukiernik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Oferta_cukiernik oferta_cukiernik = db.Oferta_cukiernik.Find(id);
            db.Oferta_cukiernik.Remove(oferta_cukiernik);
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
